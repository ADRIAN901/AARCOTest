using ECOM.Template.Services.Interfaces;
using ECOM.Utils.Nuget.Logic.Interfaces;
using ECOM.Utils.Nuget.Models;
using System.Net;
using System.Text;

namespace ECOM.Template.Services.Implement
{
    public class CallServiceImplement : ICallService
    {
        private readonly ICallHttpServices _callHttpServices;

        public CallServiceImplement(ICallHttpServices callHttpServices)
        {
            _callHttpServices = callHttpServices;
        }

        public async Task<HttpResponseMessage> CallService(object requestOrder, string pathExecute, HttpVerb httpVerb, Dictionary<string, IEnumerable<string>> Headers)
        {
            HttpResponseMessage resp;
            try { 
                resp = await _callHttpServices.HttpCallAsync(requestOrder, new Uri(pathExecute), Headers, httpVerb, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //Excepción controlada
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent($"Error: {ex.Message}", Encoding.UTF8, "application/json")
                };
            }
            //Resultado de la operación
            return resp;
        }
    }
}
