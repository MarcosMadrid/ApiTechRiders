using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("VALORACIONESCHARLAS")]
    public class ValoracionCharla
    {
        [Key]
        [Column("IDVALORACION")]
        public int IdValoracion { get; set; }
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("VALORACION")]
        public int Valoracion { get;set; }
        [Column("COMENTARIO")]
        public string Comentario { get;set; }
    }
}
