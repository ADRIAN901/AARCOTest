using Newtonsoft.Json;
using RestSharp;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.model;

namespace WebApplication
{
    public partial class index : System.Web.UI.Page
    {
        private const string V = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                //loadMarca();               
            }
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
            if(!val_ddlMarca.IsValid || !val_ddlSubmarca.IsValid || !val_ddlModelo.IsValid || !val_ddlDescripcion.IsValid || !val_txtCodigoPostal.IsValid || !val_ddlColonia.IsValid)
            {                
                string script = "error('Debes capturar todos los campos para realizar una cotizacion.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", script, true);
            }
            else
            {
                string DescipcionId= ddlDescripcion.SelectedValue;
                consultar_cotizacion("97dbc536-58db-4749-ba20-ad22d37348e7");
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
                lblAxa.Text = peticion_Cotizacion.aseguradoras[0].Tarifa.ToString("#.00");
                lblZurich.Text = peticion_Cotizacion.aseguradoras[1].Tarifa.ToString("#.00");
                lblHdi.Text = peticion_Cotizacion.aseguradoras[2].Tarifa.ToString("#.00");
                lblChubb.Text = peticion_Cotizacion.aseguradoras[3].Tarifa.ToString("#.00");
                lblQualitas.Text = peticion_Cotizacion.aseguradoras[4].Tarifa.ToString("#.00");


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
                Console.WriteLine(response.Content);

                peticion_llave = response.Content.ToString();
            }
            catch { }

            return peticion_llave;
        }


    }
}