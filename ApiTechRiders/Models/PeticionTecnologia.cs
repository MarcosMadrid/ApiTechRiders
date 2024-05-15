using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES_TECNOLOGIAS")]
    public class PeticionTecnologia
    {
        [Key]
        [Column("IDPETICIONTECNOLOGIAS")]
        public int IdPeticionTecnologia { get; set; }
        [Column("NOMBRETECNOLOGIA")]
        public string NombreTecnologia { get; set; }
        [Column("IDTIPOPETICIONCATEGORIA")]
        public int IdTipoPeticionCategoria { get; set; }
    }
}
