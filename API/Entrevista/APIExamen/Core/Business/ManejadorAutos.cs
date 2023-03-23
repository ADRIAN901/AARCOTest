using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace APIExamen.Core.Business
{
    public class ManejadorAutos
    {
        public async Task<HttpResponseMessage> GetMarca()
        {
            HttpResponseMessage resp;
            resp = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                //Content = new StringContent(JsonConvert.SerializeObject( "", Encoding.UTF8, "application/json"))
            };
            return resp;
        }

        public async Task<HttpResponseMessage> GetSubMarca(int idSubMarca)
        {
            HttpResponseMessage resp;
            resp = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                //Content = new StringContent(JsonConvert.SerializeObject( "", Encoding.UTF8, "application/json"))
            };
            return resp;
        }

        public async Task<HttpResponseMessage> GetModeloSubMarca(int idModeloSubMarca)
        {
            HttpResponseMessage resp;
            resp = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                //Content = new StringContent(JsonConvert.SerializeObject( "", Encoding.UTF8, "application/json"))
            };
            return resp;
        }

        public async Task<HttpResponseMessage> GetDescripcion(int idMarca, int idSubMarca, int idModeloSubMarca)
        {
            HttpResponseMessage resp;
            resp = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                //Content = new StringContent(JsonConvert.SerializeObject( "", Encoding.UTF8, "application/json"))
            };
            return resp;
        }
    }
}