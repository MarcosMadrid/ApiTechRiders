using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_CHARLAS")]
    public class PeticionCharla
    {
        [Key]
        [Column("IDPETICIONCHARLA")]
        public int IdPeticionCharla { get; set; }
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("IDTIPOPETICIONCATEGORIA")]
        public int IdTipoPeticionCategoria { get; set; }
    }
}
