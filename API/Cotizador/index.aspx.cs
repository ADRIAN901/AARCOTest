using Newtonsoft.Json;
using RestSharp;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.model;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace WebApplication
{
    public partial class index : System.Web.UI.Page
    {
        private const string V = "";
        private string idMarca, idSubMarca, idModeloSubMarca;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                loadMarca();               
            }
        }

        private void loadMarca()
        {
            //CONSUME API
            //var client = new RestClient("http://localhost:56887/GetMarca");
            var client = new RestClient("https://localhost:7029/api/Autos/GetMarca");
            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<DescripcionBase> respuesta = JsonConvert.DeserializeObject<List<DescripcionBase>>(response.Content);
                foreach (var item in respuesta)
                    ddlMarca.Items.Add(new ListItem { Value = item.Id.ToString(), Text = item.Descripcion });
            }

            ddlMarca.SelectedIndex = -1;
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {            
            if(((TextBox)sender).Text.Length == 5)
            {                
                string cp = ((TextBox)sender).Text;
                consultar_CP(cp);
            }

        }

        protected void btnCotizar_Click(object sender, EventArgs e)
        {
            //VALIDA QUE ESTEN SELECCIONADOS LOS CAMPOS
            if (!val_ddlMarca.IsValid || !val_ddlSubmarca.IsValid || !val_ddlModelo.IsValid || !val_ddlDescripcion.IsValid || !val_txtCodigoPostal.IsValid || !val_ddlColonia.IsValid)
            {
                string script = "error('Debes capturar todos los campos para realizar una cotizacion.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
            }
            else
            {
                string DescipcionId = ddlDescripcion.SelectedValue;
                consultar_cotizacion(DescipcionId);
                //consultar_cotizacion("bd8e92d6-715b-4551-8ff2-fbdb69a56cc2");
            }
        }


        private void consultar_CP(string cp)
        {
            try
            {
                //LIMPIA VALORES
                txtEstado.Text = "";
                txtMunicipio.Text = "";
                ddlColonia.Items.Clear();


                //CONSUME API
                var client = new RestClient("https://web.aarco.com.mx/api-examen/api/examen/sepomex/" + cp);
                client.Timeout = -1;
                client.FollowRedirects = false;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                Response_API_CP respuesta = JsonConvert.DeserializeObject<Response_API_CP>(response.Content.ToString());
                CatalogosJson informacion = JsonConvert.DeserializeObject<CatalogosJson>(respuesta.CatalogoJsonString.Substring(1, respuesta.CatalogoJsonString.Length - 2));

                txtEstado.Text = informacion.Municipio.Estado.sEstado;
                txtMunicipio.Text = informacion.Municipio.sMunicipio;

                foreach (var item in informacion.Ubicacion)
                {
                    ddlColonia.Items.Add(new ListItem { Value = item.iIdUbicacion.ToString(), Text = item.sUbicacion });
                }
            }
            catch { }
        }

        private void consultar_cotizacion(string DescripcionId)
        {
            try
            {
                string peticion_llave = crear_peticion(DescripcionId);

                bool PeticionFinalizada = false;
                Peticion_Cotizacion peticion_Cotizacion = new Peticion_Cotizacion();

                do { 
                
                    //CONSUME API
                    var client = new RestClient("https://web.aarco.com.mx/api-examen/api/examen/peticion/" + peticion_llave);
                    client.Timeout = -1;
                    client.FollowRedirects = false;
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = client.Execute(request);

                    peticion_Cotizacion = JsonConvert.DeserializeObject<Peticion_Cotizacion>(response.Content.ToString());

                    PeticionFinalizada = peticion_Cotizacion.PeticionFinalizada;

                } while (PeticionFinalizada == false);


                //LLENAMOS INFORMACION
                lblAxa.Text = peticion_Cotizacion.aseguradoras[0].Tarifa.ToString("$#.00");
                lblZurich.Text = peticion_Cotizacion.aseguradoras[1].Tarifa.ToString("$#.00");
                lblHdi.Text = peticion_Cotizacion.aseguradoras[2].Tarifa.ToString("$#.00");
                lblChubb.Text = peticion_Cotizacion.aseguradoras[3].Tarifa.ToString("$#.00");
                lblQualitas.Text = peticion_Cotizacion.aseguradoras[4].Tarifa.ToString("$#.00");


            }
            catch { }
        }

        private string crear_peticion(string DescripcionId)
        {
            string peticion_llave = "";
            try
            {
                //CONSUME API
                var client = new RestClient("https://web.aarco.com.mx/api-examen/api/examen/crear-peticion");
                client.Timeout = -1;
                client.FollowRedirects = false;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = @"{""DescripcionId"":""" + DescripcionId + '"' + "}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                string cadena = Encoding.Default.GetString(new byte[] { 34 });

                peticion_llave = response.Content.ToString().Replace(cadena, "");
            }
            catch { }

            return peticion_llave;
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubmarca.Items.Clear();
            idMarca = ddlMarca.SelectedValue;
            //CONSUME API
            //var client = new RestClient("http://localhost:56887/GetSubMarca/" + idMarca);
            var client = new RestClient("https://localhost:7029/api/Autos/GetSubMarca/" + idMarca);
            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<DescripcionBase> respuesta = JsonConvert.DeserializeObject<List<DescripcionBase>>(response.Content);
                foreach (var item in respuesta)
                    ddlSubmarca.Items.Add(new ListItem { Value = item.Id.ToString(), Text = item.Descripcion });
            }
        }

        protected void ddlSubmarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlModelo.Items.Clear();
            idSubMarca = ddlSubmarca.SelectedValue;
            //CONSUME API
            //var client = new RestClient("http://localhost:56887/GetModeloSubMarca/" + idSubMarca);
            var client = new RestClient("https://localhost:7029/api/Autos/GetModeloSubMarca/" + idSubMarca);

            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<DescripcionBase> respuesta = JsonConvert.DeserializeObject<List<DescripcionBase>>(response.Content);
                foreach (var item in respuesta)
                    ddlModelo.Items.Add(new ListItem { Value = item.Id.ToString(), Text = item.Descripcion });
            }
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDescripcion.Items.Clear();

            idMarca = ddlMarca.SelectedValue;
            idSubMarca = ddlSubmarca.SelectedValue;
            idModeloSubMarca = ddlModelo.SelectedValue;
            
            //CONSUME API
            //var client = new RestClient("http://localhost:56887/GetDescripcion/" + idMarca + "/" + idSubMarca + "/" + idModeloSubMarca);
            var client = new RestClient("https://localhost:7029/api/Autos/GetDescripcion/" + idMarca + "/" + idSubMarca + "/" + idModeloSubMarca);
            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<DescripcionModel> respuesta = JsonConvert.DeserializeObject<List<DescripcionModel>>(response.Content);
                foreach (var item in respuesta)
                    ddlDescripcion.Items.Add(new ListItem { Value = item.DescripcionId.ToString(), Text = item.Descripcion });
            }
        }
    }
}