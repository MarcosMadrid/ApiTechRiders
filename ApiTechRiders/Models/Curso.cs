using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CURSOS")]
    public class Curso
    {
        [Key]
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        [Column("IDCENTRO")]
        public int IdCentro { get; set; }
        [Column("NOMBRE_CURSO")]
        public string NombreCurso { get; set; } = null!;
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
    }
}
