using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TIPOEMPRESA")]
    public class TipoEmpresa
    {
        [Key]
        [Column("IDTIPOEMPRESA")]
        public int IdTipoEmpresa { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
    }
}
