using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("ROLES")]
    public class Role
    {
        [Key]
        [Column("IDROLE")]
        public int IdRole { get; set; }
        [Column("TIPO_ROLE")]
        public string TipoRole { get; set; } = null!;
    }
}
