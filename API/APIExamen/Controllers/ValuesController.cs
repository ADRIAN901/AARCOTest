using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using APIExamen.Core.Business;

namespace APIExamen.Controllers
{
    public class ValuesController : ApiController
    {

        [HttpGet]
        [Route("GetMarca")]
        public async Task<HttpResponseMessage> GetMarca()
        {
            return await new ManejadorAutos().GetMarca();
        }

        [HttpGet]
        [Route("GetSubMarca/{idMarca}")]
        public async Task<HttpResponseMessage> GetSubMarca(int idMarca)
        {
            return await new ManejadorAutos().GetSubMarca(idMarca);
        }

        [HttpGet]
        [Route("GetModeloSubMarca/{idSubMarca}")]
        public async Task<HttpResponseMessage> GetModeloSubMarca(int idSubMarca)
        {
            return await new ManejadorAutos().GetModeloSubMarca(idSubMarca);
        }

        [HttpGet]
        [Route("GetDescripcion/{idMarca}/{idSubMarca}/{idModeloSubMarca}")]
        public async Task<HttpResponseMessage> GetDescripcion(int idMarca, int idSubMarca, int idModeloSubMarca)
        {
            return await new ManejadorAutos().GetDescripcion(idMarca, idSubMarca, idModeloSubMarca);
        }
    }
}