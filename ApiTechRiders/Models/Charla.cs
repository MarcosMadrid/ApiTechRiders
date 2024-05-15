using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CHARLAS")]
    public class Charla
    {
        [Key]
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; } = null!;
        [Column("IDESTADOSCHARLA")]
        public int IdEstadoCharla { get; set; }
        [Column("FECHA_CHARLA")]
        public DateTime? FechaCharla { get; set; } = null!;
        [Column("OBSERVACIONES")]
        public string Observaciones { get;set; } = null!;
        [Column("IDTECHRIDER")]
        public int? IdTechRider { get; set; } = null!;
        [Column("FECHA_SOLICITUD")]
        public DateTime? FechaSolicitud { get; set; } = null!;
        [Column("TURNO")]
        public string Turno { get; set; } = null!;
        [Column("MODALIDAD")]
        public string Modalidad { get; set; } = null!;
        //[Column("VALORACION")]
        //public int? Valoracion { get;set; } = null!;
        //[Column("COMENTARIOS")]
        //public string Comentarios { get; set; } = null!;
        [Column("ACREDITACION_LINKEDIN")]
        public string AcreditacionLinkedIn { get; set; } = null!;
        [Column("IDCURSO")]
        public int IdCurso { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
    }
}
