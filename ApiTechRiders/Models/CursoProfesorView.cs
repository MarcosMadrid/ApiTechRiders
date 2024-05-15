using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CURSOSPROFESORESVIEW")]
    public class CursoProfesorView
    {
        [Key]
        [Column("CLAVE")]
        public int Id { get; set; }
        [Column("IDUSUARIO")]
        public int IdProfesor { get; set; }
        [Column("PROFESOR")]
        public string Profesor { get; set; }
        [Column("EMAIL")]
        public string EmailProfesor { get; set; }
        [Column("TELEFONO")]
        public string TelefonoProfesor { get; set; }
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        [Column("NOMBRECURSO")]
        public string NombreCurso { get; set; }
        [Column("DESCRIPCIONCURSO")]
        public string DescripcionCurso { get; set; }
        [Column("IDEMPRESACENTRO")]
        public int IdCentro { get; set; }
        [Column("CENTRO")]
        public string Centro { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvinciaCentro { get; set; }
        [Column("PROVINCIACENTRO")]
        public string ProvinciaCentro { get; set; }
    }
}
