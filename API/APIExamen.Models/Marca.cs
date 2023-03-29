using System.ComponentModel.DataAnnotations;

namespace APIExamen.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
    }
}