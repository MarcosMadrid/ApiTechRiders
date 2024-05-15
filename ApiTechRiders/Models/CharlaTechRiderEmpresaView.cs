using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("CHARLASTECHRIDERSEMPRESAVIEW")]
    public class CharlaTechRiderEmpresaView
    {
        [Key]
        [Column("POSICION")]
        public int Id { get; set; }
        [Column("IDCHARLA")]
        public int IdCharla { get; set; }
        [Column("DESCRIPCION")]
        public string DescripcionCharla { get; set; }
        [Column("FECHA_CHARLA")]
        public DateTime FechaCharla { get; set; }
        [Column("TURNO")]
        public string Turno { get; set; }
        [Column("FECHA_SOLICITUD")]
        public DateTime FechaSolicitudCharla { get; set; }
        [Column("OBSERVACIONESCHARLA")]
        public string ObservacionesCharla { get; set; }
        [Column("IDESTADOCHARLA")]
        public int IdEstadoCharla { get; set; }
        [Column("ESTADOCHARLA")]
        public string EstadoCharla { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
        [Column("PROVINCIA")]
        public string Provincia { get; set; }
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
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }
        [Column("NOMBRE")]
        public string Empresa { get; set; }
        [Column("DIRECCION")]
        public string DireccionEmpresa { get; set; }
    }
}
