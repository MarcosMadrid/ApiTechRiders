using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("ESTADOSVALIDACION")]
    public class EstadosValidacion
    {
        [Key]
        [Column("IDESTADOVALIDACION")]
        public int IdEstadoValidacion { get; set; }
        [Column("NOMBRE_ESTADO")]
        public string NombreEstado { get;set; } = null!;
    }
}
