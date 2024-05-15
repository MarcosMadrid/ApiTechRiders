using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ApiTechRiders.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("APELLIDOS")]
        public string Apellidos { get; set; }
        [Column("CORREO")]
        public string Email { get; set; } = null!;
        [Column("TELEFONO")]
        public string Telefono { get; set; } = null!;
        [Column("LINKEDIN")]
        public string LinkedIn { get; set; } = null!;
        [Column("PASS")]
        public string Password { get; set; }
        [Column("IDROLE")]
        public int IdRole { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
        [Column("IDEMPRESASCENTROS")]
        public int? IdEmpresaCentro { get; set; } = null!;
        [Column("ESTADO")]
        public int Estado { get; set; }
        [Column("LINKEDINVISIBLE")]
        public int LinkedInVisible { get; set; }
        [Column("TOKENPASS")]
        public string? TokenPass { get; set; }
        [Column("IMAGEN")]
        public string? Imagen { get; set; }
    }
}
