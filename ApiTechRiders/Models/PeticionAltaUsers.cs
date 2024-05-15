using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_ALTA_USERS")]
    public class PeticionAltaUsers
    {
        [Key]
        [Column("IDPETICIONALTAUSERS")]
        public int IdPeticionAltaUsers { get; set; }
        [Column("IDUSER")]
        public int IdUser { get; set; }
        [Column("IDTIPOPETICIONCATEGORIA")]
        public int IdTipoPeticionCategoria { get; set; }
    }
}
