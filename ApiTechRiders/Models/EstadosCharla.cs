using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("ESTADOSCHARLA")]
    public class EstadosCharla
    {
        [Key]
        [Column("IDESTADOSCHARLA")]
        public int IdEstadosCharla { get; set; } 
        [Column("TIPO")]
        public string Tipo { get; set; } = null!;
    }
}
