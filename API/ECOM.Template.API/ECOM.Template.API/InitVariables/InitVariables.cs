namespace ECOM.Template.API
{
    internal class InitVariables
    {
        public static string? Parameters { get; set; }
        public static Dictionary<string, IEnumerable<string>>? Headers { get; set; }
        public static string? PathBase { get; set; }
        public static string? RawRequest { get; set; }
    }
}
