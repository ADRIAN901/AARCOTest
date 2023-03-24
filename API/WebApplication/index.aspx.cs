
using RestSharp;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {                
                //loadMarca();               
            }
        }

        

        private void onkeypress_txtCP(object sender, EventArgs e)
        {
            if ("a"=="s")
            {
                string a = "";
            }
            else
            {
                string b = "";
            }
        }

        protected void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {            
            if(((TextBox)sender).Text.Length == 5)
            {
                //REALIZA CONSUMO DE API

                string cp = ((TextBox)sender).Text;

                var client = new RestClient("https://web.aarco.com.mx/api-examen/api/examen/sepomex/" + cp);
                client.Timeout = -1;
                client.FollowRedirects = false;
                var request = new RestRequest(Method.Get);
                IRestResponse response = client.Execute(request);

                dynamic array = JsonConvert.DeserializeObject(response.ToString());                



            }

        }


        //protected void loadSubmarca(string marcaID)
        //{
        //    List<ItemCatalogo> informacion = new List<ItemCatalogo>();

        //    try
        //    {
        //        //Consulta API Rnow para traer la informacion de las especialidades 
        //        sParametros = "?q=1=1 and Tipo_Localidad=3 and id_localidad_padre='" + estadoID + "'";

        //        APIModel apiModel = new APIModel { URL_base = BaseRnow, Route = "/services/rest/connect/latest/CO.Localidades/", MethodAPI = Method.GET, Parameters = sParametros };
        //        jsonString = API.consumirRnow(apiModel);

        //        dynamic array = JsonConvert.DeserializeObject(jsonString);

        //        foreach (var item in array["items"])
        //        {
        //            informacion.Add(new ItemCatalogo
        //            {
        //                id = Convert.ToString(((Newtonsoft.Json.Linq.JValue)item["id"]).Value),
        //                lookupName = Convert.ToString(((Newtonsoft.Json.Linq.JValue)item["lookupName"]).Value)
        //            });
        //        }

        //    }

        //    catch (Exception error)
        //    {
        //        //No realiza nada y envia los valores encontrados
        //    }

        //    cboCiudades.DataTextField = "lookupName";
        //    cboCiudades.DataValueField = "id";
        //    cboCiudades.DataSource = informacion;
        //    cboCiudades.DataBind();
        //    cboCiudades.Filter = RadComboBoxFilter.Contains;
        //}
    }
}