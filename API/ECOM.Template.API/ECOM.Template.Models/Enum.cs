namespace ECOM.Template.Models
{
    public enum TipoError
    {
        SinError = 0,
        Error = 1,
        Warning = 2
    }

    [Flags]
    public enum ImplementationException
    {
        Azure = 1,
        Rackspace = 2,
        FTP = 3,
        SFTP = 4
    }

    public static class TypeImplementationException
    {
        public static string NameImplementationExepcition(this ImplementationException implementation)
        {
            switch (implementation)
            {
                case ImplementationException.Azure:
                    return "Azure";
                case ImplementationException.Rackspace:
                    return "Rackspace";
                case ImplementationException.FTP:
                    return "FTP";
                case ImplementationException.SFTP:
                    return "SFTP";
                default:
                    return "";
            }
        }
    }
}
