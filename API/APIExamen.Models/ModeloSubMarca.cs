using System.ComponentModel.DataAnnotations;

namespace APIExamen.Models
{
    public class ModeloSubMarca
    {
        [Key]
        public int IdModeloSubMarca { get; set; }
        public string? Descripcion { get; set; }
    }
}
