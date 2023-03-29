using System.ComponentModel.DataAnnotations;

namespace APIExamen.Models
{
    public class Descripcion
    {
        [Key]
        public int Id { get; set; }
        public string? DescripcionId { get; set; }
        public string? DescripcionA { get; set; }
        public int IdModeloSubMarca { get; set; }
        public int IdSubMarca { get; set; }
        public int IdMarca { get; set; }
    }
}