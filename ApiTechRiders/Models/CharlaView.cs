using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("VISTACHARLAS")]
    public class CharlaView
    {
        [Key]
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("DESCRIPCION")]
        public string DescripcionCharla { get; set; }
        [Column("FECHA_CHARLA")]
        public DateTime FechaCharla { get; set; }
        [Column("IDESTADOCHARLA")]
        public int IdEstadoCharla { get; set; }
        [Column("ESTADOCHARLA")]
        public string EstadoCharla { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
        [Column("PROVINCIA")]
        public string Provincia { get; set; }
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        [Column("NOMBRE_CURSO")]
        public string NombreCurso { get; set; }
        [Column("OBSERVACIONESCHARLA")]
        public string ObservacionesCharla { get; set; }
        [Column("FECHA_SOLICITUD")]
        public DateTime FechaSolicitudCharla { get; set; }
        [Column("MODALIDAD")]
        public string Modalidad { get; set; }
        [Column("IDTECHRIDER")]
        public int IdTechRider { get; set; }
        [Column("TECHRIDER")]
        public string TechRider { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("TELEFONO")]
        public string Telefono { get; set; }
        [Column("IDROLE")]
        public int IdRole { get; set; }
        [Column("TIPOROLE")]
        public string TipoRole { get; set; }
        [Column("VALORACION")]
        public int Valoracion { get; set; }
        [Column("COMENTARIOVALORACION")]
        public string ComentarioValoracion { get; set; }
    }
}
