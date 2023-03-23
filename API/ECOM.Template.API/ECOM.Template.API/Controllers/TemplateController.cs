using ECOM.Template.API.Filters;
using ECOM.Template.UserCases.Implement;
using ECOM.Template.UserCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

namespace ECOM.Template.API.Controllers
{
    [FilterTemplate]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly IEjecutaServicio _ejecutaServicio;
        //private readonly ICallHttpServices _callHttpServices;

        public TemplateController(IEjecutaServicio ejecutaServicio)
        {
            _ejecutaServicio = ejecutaServicio;
        }
        /// <summary>
        /// Afiliación de órdenes
        /// </summary>
        /// <param name="requestOrder"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("affiliate/order")]
        public async Task<HttpResponseMessage> PostOrderAsync(object requestOrder)
        {
            //Retorna valor de búsqueda
            return await _ejecutaServicio.GeneraPeticion(requestOrder, InitVariables.PathBase, 1, InitVariables.Headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Fincado de pedidos en ADN
        /// </summary>
        /// <param name="requestOrder"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("web/generaVenta")]
        public async Task<HttpResponseMessage> GeneraVentaAsync(object requestOrder)
        {
            //Retorna valor de búsqueda
            return await _ejecutaServicio.GeneraPeticion(requestOrder, InitVariables.PathBase, 1, InitVariables.Headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Gateway de peticiones POST
        /// </summary>
        /// <param name="requestOrder"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ECOM/Gateway/Post/{Metodo}")]
        public async Task<HttpResponseMessage> GateWayPost(object requestOrder)
        {
            //Retorna valor de búsqueda
            if (!string.IsNullOrEmpty(InitVariables.RawRequest))
                requestOrder = string.Empty; //new Utils().GetObject(VariablesGlobales.RawRequest);

            return await _ejecutaServicio.GeneraPeticion(requestOrder, InitVariables.PathBase, 1, InitVariables.Headers).ConfigureAwait(false);
        }

        /// <summary>
        /// Gateway de peticiones GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ECOM/Gateway/Get/{Metodo}")]
        [ProducesResponseType(typeof(HttpResponseMessage), 200)]
        public async Task<HttpResponseMessage> GateWayGet()
        {
            //Retorna valor de búsqueda
            return await _ejecutaServicio.GeneraPeticion(InitVariables.Parameters, InitVariables.PathBase, 0, InitVariables.Headers).ConfigureAwait(false);
        }
    }
}
