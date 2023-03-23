namespace ECOM.Template.MinAPI.InitVariables
{
    internal class InitVariables
    {
        public static string Parameters { get; set; } = string.Empty;
        public static Dictionary<string, IEnumerable<string>> Headers { get; set; } = new Dictionary<string, IEnumerable<string>>();
        public static string? PathBase { get; set; } = string.Empty;
        public static string? RawRequest { get; set; } = string.Empty;
    }
}
