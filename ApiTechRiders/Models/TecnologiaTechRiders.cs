using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TECNOLOGIAS_TECHRIDERS")]
    public class TecnologiaTechRiders
    {
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("IDTECNOLOGIA")]
        public int IdTecnologia { get; set; }

    }
}
