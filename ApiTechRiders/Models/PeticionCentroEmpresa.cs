using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_CENTRO_EMPRESA")]
    public class PeticionCentroEmpresa
    {
        [Key]
        [Column("IDPETICIONCENTROEMPRESA")]
        public int IdPeticionCentroEmpresa { get; set; }
        [Column("IDCENTROEMPRESA")]
        public int IdCentroEmpresa { get; set; }
        [Column("IDTIPOPETICIONCATEGORIA")]
        public int IdTipoPeticionCategoria { get; set; }
    }
}
