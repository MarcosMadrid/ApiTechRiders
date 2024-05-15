using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_CATEGORIAS")]
    public class PeticionCategorias
    {
        [Key]
        [Column("IDPETICIONCATEGORIAS")]
        public int IdPeticionCategorias { get; set; }
        [Column("CATEGORIA")]
        public string Categoria { get; set; }
    }
}
