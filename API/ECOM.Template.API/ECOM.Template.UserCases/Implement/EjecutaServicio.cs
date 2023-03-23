using ECOM.Template.DataBase.Interfaces;
using ECOM.Template.Models.ECOM;
using ECOM.Template.Services.Interfaces;
using ECOM.Template.UserCases.Interfaces;
using ECOM.Utils.Nuget.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;

namespace ECOM.Template.UserCases.Implement
{
    public class EjecutaServicio : IEjecutaServicio
    {
        private readonly ICallService _callService;
        private readonly IECOM _iECOM;
        private readonly IConfiguration _configuration;
        public EjecutaServicio(ICallService callService,
                               IECOM iECOM,
                               IConfiguration configuration)
        {
            _callService = callService;
            _iECOM = iECOM;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> GeneraPeticion(object requestOrder, string pathExecute, int httpVerb, Dictionary<string, IEnumerable<string>> Headers)
        {
            return await GeneraPeticion(requestOrder, pathExecute, (HttpVerb)httpVerb, Headers);
        }

        public async Task<HttpResponseMessage> GeneraPeticion(object requestOrder, string pathBase, HttpVerb httpVerb, Dictionary<string, IEnumerable<string>> Headers)
        {
            HttpResponseMessage resp;
            try
            {
                ECPathGateway oECPathGateway = await _iECOM.GetUrlPath(pathBase).ConfigureAwait(false);
                
                if (oECPathGateway == null)
                    return resp = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Content = new StringContent($"url origen {pathBase} no generó resultados", Encoding.UTF8, "application/json")
                    };

                if (string.IsNullOrEmpty(oECPathGateway.fcPathDestiny))
                    return resp = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Content = new StringContent($"Error: La opción seleccionada, no se ha configurado correctamente", Encoding.UTF8, "application/json")
                    };

                //Llama al HTTP de forma asíncrona
                if (httpVerb == HttpVerb.Get)
                    oECPathGateway.fcPathDestiny += requestOrder;

                resp = await _callService.CallService(requestOrder, oECPathGateway.fcPathDestiny, httpVerb, Headers).ConfigureAwait(false);
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
