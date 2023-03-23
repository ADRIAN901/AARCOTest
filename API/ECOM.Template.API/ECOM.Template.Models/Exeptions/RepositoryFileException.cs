using Newtonsoft.Json;

namespace ECOM.Template.Models.Exeptions
{
    public class RepositoryFileException : Exception
    {
        public string ObjectRequest { get; set; }
        public string BasePath { get; set; }
        public string Connection { get; set; }
        public string Action { get; set; }

        public readonly string TypeException;


        /// <summary>
        /// Retorna una exepcion para una conexion de la clase de repositoryFile
        /// </summary>
        /// <param name="implementation"></param>
        /// <param name="Objetec"></param>
        /// <param name="user"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <param name="innerException"></param>
        public RepositoryFileException(ImplementationException implementation, object Objetec,
            string stringConnection, string action, Exception innerException)
            : base($"Implementation: {implementation} \n " +
                  $"Request : {JsonConvert.SerializeObject(Objetec)} \n " +
                  $"Accion : {action} \n" +
                  $"DirecctionPaht: {stringConnection ?? "ESTE VALOR NO FUE PASADO"}", innerException)
        {
            this.TypeException = implementation .NameImplementationExepcition();
            this.ObjectRequest = JsonConvert.SerializeObject(Objetec);
            this.Connection = stringConnection;
            this.Action = action;
        }

        /// <summary>
        /// Retorna una exepcion para una conexion de la clase de repositoryFile
        /// </summary>
        /// <param name="implementation"></param>
        /// <param name="basePath"></param>
        /// <param name="user"></param>
        /// <param name="key"></param>
        /// <param name="path"></param>
        /// <param name="innerException"></param>
        public RepositoryFileException(ImplementationException implementation, string basePath,
            string conexion, string action, Exception innerException)
            : base($"Implemetation {implementation} \n " +
                  $"BasePath: {basePath} \n" +
                  $"Accion : {action} \n" +
                  $"DirecctionPaht: {conexion ?? "ESTE VALOR NO FUE PASADO"}", innerException)
        {
            this.TypeException = implementation.NameImplementationExepcition();
            this.BasePath = basePath;
            this.Connection = conexion;
            this.Action = action;
        }

    }
}
