using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PROVINCIAS")]
    public class Provincia
    {
        [Key]
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
        [Column("PROVINCIA")]
        public string NombreProvincia { get; set; } = null!;
    }
}
