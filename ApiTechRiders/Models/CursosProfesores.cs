using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CURSOS_PROFESORES")]
    public class CursosProfesores
    {
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        [Column("IDPROFESOR")]
        public int IdProfesor { get; set; }
    }
}
