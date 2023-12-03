namespace DigitalCaesar.ServerSilencer.Service.Converters;

public class HexConverter
{
    public static int FromHex(string value)
    {
        bool hasPrefix = value.StartsWith("0x");
        bool hasSuffix = value.EndsWith("h");
        int start = hasPrefix ? 2 : 0;
        int end = hasSuffix ? value.Length - 1 : value.Length;
        int length = end - start;
        string trimmedValueInHex = value.Substring(start, length);

        return int.Parse(trimmedValueInHex, System.Globalization.NumberStyles.HexNumber);
    }

    public static string ToHex(int value) => string.Format($"{value:X2}");
    //public static string ToHex(string value) => string.Format($"{value:X2}");
    public static string ToHexId(int value) => string.Format($"{value:X2}h");
    //public static string ToHexId(string value) => string.Format($"{value:X2}h");
    public static string ToHexCommand(int value) => string.Format($"0x{value:X2}");
    //public static string ToHexCommand(string value) => string.Format($"0x{value:X2}");
}