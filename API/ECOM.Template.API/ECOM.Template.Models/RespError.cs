namespace ECOM.Template.Models
{
    public class RespError
    {
        public TipoError TipError { get; set; } = TipoError.SinError;
        public string Mensaje { get; set; } = string.Empty;
    }


}
