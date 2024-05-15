using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("EMPRESASCENTROS")]
    public class EmpresasCentros
    {
        [Key]
        [Column("IDEMPRESACENTRO")]
        public int IdEmpresaCentro { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("DIRECCION")]
        public string Direccion { get; set; } = null!;
        [Column("TELEFONO")]
        public string Telefono { get; set; } = null!;
        [Column("PERSONA_CONTACTO")]
        public string PersonaContacto { get; set; } = null!;
        [Column("CIF")]
        public string Cif { get; set; } = null!;
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
        [Column("RAZON_SOCIAL_EMPRESA")]
        public string RazonSocial { get; set; } = null!;
        [Column("IDTIPOEMPRESA")]
        public int? IdTipoEmpresa { get; set; } = null!;
        [Column("ESTADO")]
        public int? EstadoEmpresa { get; set; } = null!;
    }
}
