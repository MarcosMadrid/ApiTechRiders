using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TECHRIDERSEMPRESASVIEW")]
    public class TechRiderEmpresaView
    {
        [Key]
        [Column("CLAVE")]
        public int Id { get; set; }
        [Column("IDTECHRIDER")]
        public int IdTechRider { get; set; }
        [Column("TECHRIDER")]
        public string TechRider { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("TELEFONO")]
        public string TelefonoTechRider { get; set; }
        [Column("LINKEDIN")]
        public string LinkedIn { get; set; }
        [Column("IDEMPRESA")]
        public int IdEmpresa { get; set; }
        [Column("EMPRESA")]
        public string Empresa { get; set; }
        [Column("DIRECCION")]
        public string Direccion { get; set; }
        [Column("TELEFONOEMPRESA")]
        public string TelefonoEmpresa { get; set; }
        [Column("PROVINCIAEMPRESA")]
        public string ProvinciaEmpresa { get; set; }
        [Column("LINKEDINVISIBLE")]
        public int LinkedInVisible { get; set; }
    }
}
