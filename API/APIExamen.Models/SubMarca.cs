using System.ComponentModel.DataAnnotations;

namespace APIExamen.Models
{
    public class SubMarca
    {
        [Key]
        public int IdSubMarca { get; set; }

        public string? Descripcion { get; set; }
    }
}
