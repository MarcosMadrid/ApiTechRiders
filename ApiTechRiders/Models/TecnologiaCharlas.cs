using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TECNOLOGIASCHARLAS")]
    public class TecnologiaCharlas
    {
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("IDTECNOLOGIA")]
        public int IdTecnologia { get; set; }
    }
}
