using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DigitalCaesar.ServerSilencer.Service.Validation;

public static class Ensure
{
    public static void NotNull([NotNull]string? value, [CallerArgumentExpression("value")]string? paraName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(paraName);
    }
}