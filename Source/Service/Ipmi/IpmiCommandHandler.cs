using System.Diagnostics;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiCommandHandler
{
    private int RetryCount { get; }
    private int InitialDelay { get; }
    private double Factor { get; }
    private IpmiPath Path { get; }
    private IpmiConnection Args { get; }
    private readonly IpmiLogger _logger;
    
    public IpmiCommandHandler(IpmiCommandSettings commandSettings, ILogger? logger = null)
    {
        Args = new(commandSettings.Connection);
        RetryCount = commandSettings.RetryCount;
        InitialDelay = commandSettings.InitialDelayInSeconds * 1000;
        Factor = commandSettings.Factor;
        Path = new(commandSettings.Tool);
        _logger = new(logger);
    }
    
    public async Task<IpmiCommandResult> Execute(string command, CancellationToken cancellationToken)
    {
        IEnumerable<TimeSpan> delay = Backoff.ExponentialBackoff(
            TimeSpan.FromMilliseconds(InitialDelay),
            RetryCount,
            Factor);

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = Path,
                Arguments = string.Concat(Args," ", command),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        
        PolicyResult<string> policyExecutionResult = await Policy 
            .HandleResult<string>(string.IsNullOrWhiteSpace)
            .WaitAndRetryAsync(
                delay,
                (exception, span, iteration, _) =>
                {
                    _logger.LogError(
                        process.StartInfo.FileName,
                        process.StartInfo.Arguments,
                        RetryCount - iteration + 1,
                        span);
                })
            .ExecuteAndCaptureAsync(
                async token =>
                {
                    process.Start();
                    await process.WaitForExitAsync(token);

                    return await process.StandardOutput.ReadToEndAsync(cancellationToken);
                }, cancellationToken);
        if (policyExecutionResult.Outcome == OutcomeType.Failure)
        {
            _logger.LogError(policyExecutionResult.FinalException, command);
            return new(false, policyExecutionResult.Result);
        }
        return new(true, policyExecutionResult.Result);
    } 
}