namespace ECOM.Template.Models.Exeptions
{
    public class FtpExeption : Exception
    {
        public string DirectoryName { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Action { get; set; }

        public readonly string TypeFtpExcepcion;

        /// <summary>
        /// Retorna una excepcion para un error al conectarse a un FTP
        /// </summary>
        /// <param name="implementation"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="innerException"></param>
        public FtpExeption(ImplementationException implementation, string directoryName, string fileName, string user, string password, string host, string port, string action, string traceDirectory, Exception innerException)
            : base($"Impletation: {implementation} \n " +
                  $"Ftp Name : {directoryName}" +
                  $"FileName: {fileName} \n " +
                  $"User: {user ?? "ESTE VALOR NO FUE PASADO"} \n " +
                  $"Password: {password ?? "ESTE VALOR NO FUE PASADO"} \n " +
                  $"Host: {host ?? "ESTE VALOR NO FUE PASADO"} \n " +
                  $"Port: {port} \n" +
                  $"Action: {action}" +
                  $"TraceDirectory: {traceDirectory}", innerException)
        {
            this.TypeFtpExcepcion = implementation.NameImplementationExepcition();
            this.DirectoryName = directoryName;
            this.FileName = fileName;
            this.User = user;
            this.Password = password;
            this.Host = host;
            this.Port = port;
            this.Action = action;
        }

    }
}