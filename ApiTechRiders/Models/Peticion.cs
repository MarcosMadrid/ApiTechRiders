using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONES")]
    public class Peticion
    {
        [Key]
        [Column("IDPETICION")]
        public int IdPeticion { get; set; }
        [Column("TIPO_PETICION")]
        public int? TipoPeticion { get; set; } = null!;
        [Column("ID_GENERAL")]
        public int? IdGeneral { get;set; } = null!;
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("FECHA_PETICION")]
        public DateTime FechaPeticion { get;set; }
    }
}
