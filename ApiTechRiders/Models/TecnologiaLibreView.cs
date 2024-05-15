using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TECNOLOGIASLIBRESVIEW")]
    public class TecnologiaLibreView
    {
        [Key]
        [Column("POSICION")]
        public int Id { get; set; }

        [Column("IDESTADOSCHARLA")]
        public int IdEstadoCharla { get; set; }
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("IDTECNOLOGIA")]
        public int IdTecnologia { get; set; }
        [Column("ID_TIPO_TECNOLOGIA")]
        public int IdTipoTecnologia { get; set; }
        [Column("NOMBRE_TECNOLOGIA")]
        public string NombreTecnologia { get; set; }
        [Column("TIPOTECNOLOGIA")]
        public string TipoTecnologia { get; set; }
    }
}
