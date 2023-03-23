using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.model
{    
    public class Response_API_CP
    {
        public string CatalogoJsonString { get; set; }
        public object Error { get; set; }
    }

    public class Estado
    {
        public int iIdEstado { get; set; }
        public object Pais { get; set; }
        public int iEstadoPais { get; set; }
        public int iClaveEstadoCepomex { get; set; }
        public string sEstado { get; set; }
    }

    public class Municipio
    {
        public int iIdMunicipio { get; set; }
        public Estado Estado { get; set; }
        public int iMunicipioEstado { get; set; }
        public int iClaveMunicipioCepomex { get; set; }
        public string sMunicipio { get; set; }
    }

    public class CatalogosJson
    {
        public Municipio Municipio { get; set; }
        public List<Ubicacion> Ubicacion { get; set; }
    }

    public class Ubicacion
    {
        public int iIdUbicacion { get; set; }
        public object CodigoPostal { get; set; }
        public int iUbicacionCodigoPostal { get; set; }
        public object TipoUbicacion { get; set; }
        public int iClaveUbicacionCepomex { get; set; }
        public object Ciudad { get; set; }
        public string sUbicacion { get; set; }
    }
    
    public class Aseguradora
    {
        public int PeticionAseguradoraId { get; set; }
        public int PeticionId { get; set; }
        public int AseguradoraId { get; set; }
        public double Tarifa { get; set; }
    }

    public class Peticion_Cotizacion
    {
        public int PeticionId { get; set; }
        public string Marca { get; set; }
        public string Submarca { get; set; }
        public int Modelo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionId { get; set; }
        public bool PeticionFinalizada { get; set; }
        public string PeticionLlave { get; set; }
        public List<Aseguradora> aseguradoras { get; set; }
    }

}