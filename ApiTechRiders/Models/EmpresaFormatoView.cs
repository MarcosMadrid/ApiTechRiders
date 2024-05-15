using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("EMPRESASFORMATOVIEW")]
    public class EmpresaFormatoView
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
        [Column("RAZON_SOCIAL_EMPRESA")]
        public string RazonSocial { get; set; } = null!;
        [Column("PROVINCIA")]
        public string Provincia { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }

        [Column("IDTIPOEMPRESA")]
        public int? IdTipoEmpresa { get; set; } = null!;
        [Column("DESCRIPCION")]
        public string TipoEmpresa { get; set; }
        [Column("ESTADO")]
        public int? EstadoEmpresa { get; set; } = null!;
        [Column("DESCRIPCIONESTADO")]
        public string DescripcionEstado { get; set; } = null!;
    }
}
