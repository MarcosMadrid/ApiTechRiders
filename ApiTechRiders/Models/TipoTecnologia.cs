using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TIPOSTECNOLOGIAS")]
    public class TipoTecnologia
    {
        [Key]
        [Column("IDTIPOTECNOLOGIA")]
        public int IdTipoTecnologia { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
    }
}
