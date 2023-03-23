using Newtonsoft.Json;

namespace ECOM.Template.Models.Exeptions
{
    public class WebServiceException : Exception
    {
        public string Url { get; set; }

        public string Headers { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public string StatusCode { get; set; }

        public string Method { get; set; }

        public string EndPoint { get; set; }

        public string Parameters { get; set; }

        public string FriendlyMessage { get; set; }

        public readonly string TypeWebService;


        /// <summary>
        /// Constructor for Web service Rest type
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="innerException"></param>
        public WebServiceException(string url, Dictionary<string, string> headers, string request, string response, string statusCode, string method, Exception innerException)
            : base($"Url: {url} \n Method: {method} \n Headers: {headers} \n Request: {request} \n Response: {response} \n StatusCode: {statusCode}", innerException)
        {
            TypeWebService = "REST";
            Url = url;
            Headers = JsonConvert.SerializeObject(headers);
            Request = request;
            Response = response;
            StatusCode = statusCode;
            Method = method;

        }

        /// <summary>
        /// Constructor for web service WCF type
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parametersInput"></param>
        /// <param name="binding"></param>
        /// <param name="response"></param>
        /// <param name="innerException"></param>
        public WebServiceException(string endPoint, Exception innerException, params object[] parametersMethod)
            : base($"EndPoint: {endPoint} \n" +
                  $"Parameters: {JsonConvert.SerializeObject(parametersMethod)}", innerException)
        {
            TypeWebService = "WCF";
            EndPoint = endPoint;
            Parameters = JsonConvert.SerializeObject(parametersMethod);
        }

        /// <summary>
        /// Constructor for web service WCF type with friendly message.
        /// </summary>
        /// <param name="endPoint">URL del servicio.</param>
        /// <param name="friendlyMessage">Mensaje para usuario.</param>
        /// <param name="innerException">Excepcion.</param>
        /// <param name="parametersMethod">Parametros enviados.</param>
        public WebServiceException(string endPoint, string friendlyMessage, Exception innerException, params object[] parametersMethod)
            : base($"EndPoint: {endPoint} \n" +
                  $"Parameters: {JsonConvert.SerializeObject(parametersMethod)}", innerException)
        {
            TypeWebService = "WCF";
            EndPoint = endPoint;
            Parameters = JsonConvert.SerializeObject(parametersMethod);
            FriendlyMessage = friendlyMessage;
        }

    }
}
