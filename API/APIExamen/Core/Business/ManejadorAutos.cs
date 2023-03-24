using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using APIExamen.Entities;
using APIExamen.Models;
using Newtonsoft.Json;

namespace APIExamen.Core.Business
{
    public class ManejadorAutos
    {
        public async Task<HttpResponseMessage> GetMarca()
        {
            HttpResponseMessage resp;
            try
            {
                List<DescripcionBase> lstDescripcionBase = new List<DescripcionBase>();
                using (AutosBDEntities autosBDEntities = new AutosBDEntities())
                {
                    var result = autosBDEntities.spGetMarca();
                    foreach (var marca in result)
                    {
                        DescripcionBase des = new DescripcionBase()
                        {
                            Id = marca.IdMarca,
                            Descripcion = marca.Descripcion
                        };
                        lstDescripcionBase.Add(des);
                    }
                }
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(lstDescripcionBase))
                };
            }
            catch (Exception ex)
            {
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message))
                };
            }
            return resp;
        }

        public async Task<HttpResponseMessage> GetSubMarca(int idMarca)
        {
            HttpResponseMessage resp;
            try
            {
                List<DescripcionBase> lstDescripcionBase = new List<DescripcionBase>();
                using (AutosBDEntities autosBDEntities = new AutosBDEntities())
                {
                    var result = autosBDEntities.spGetSubMarca(idMarca);
                    foreach (var subMarca in result)
                    {
                        DescripcionBase des = new DescripcionBase()
                        {
                            Id = subMarca.IdSubMarca,
                            Descripcion = subMarca.Descripcion
                        };
                        lstDescripcionBase.Add(des);
                    }
                }
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(lstDescripcionBase))
                };
            }
            catch (Exception ex)
            {
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message))
                };
            }
            return resp;
        }

        public async Task<HttpResponseMessage> GetModeloSubMarca(int idSubMarca)
        {
            HttpResponseMessage resp;
            try
            {
                List<DescripcionBase> lstDescripcionBase = new List<DescripcionBase>();
                using (AutosBDEntities autosBDEntities = new AutosBDEntities())
                {
                    var result = autosBDEntities.spGetModeloSubMarca(idSubMarca);
                    foreach (var modelosubMarca in result)
                    {
                        DescripcionBase des = new DescripcionBase()
                        {
                            Id = modelosubMarca.IdModeloSubMarca,
                            Descripcion = modelosubMarca.Descripcion
                        };
                        lstDescripcionBase.Add(des);
                    }
                }
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(lstDescripcionBase))
                };
            }
            catch (Exception ex)
            {
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message))
                };
            }
            return resp;
        }

        public async Task<HttpResponseMessage> GetDescripcion(int idMarca, int idSubMarca, int idModeloSubMarca)
        {
            HttpResponseMessage resp;
            try
            {
                List<DescripcionModel> lstDescripcion = new List<DescripcionModel>();
                using (AutosBDEntities autosBDEntities = new AutosBDEntities())
                {
                    var result = autosBDEntities.spGetDescripcion(idMarca, idSubMarca, idModeloSubMarca);
                    foreach (var descripcion in result)
                    {
                        DescripcionModel des = new DescripcionModel()
                        {
                            DescripcionId = descripcion.DescripcionId,
                            Descripcion = descripcion.Descripcion
                        };
                        lstDescripcion.Add(des);
                    }
                }
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(lstDescripcion))
                };
            }
            catch (Exception ex)
            {
                resp = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message))
                };
            }
            return resp;
        }
    }
}