using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("USERSFORMATOVIEW")]
    public class UserFormatoView
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("APELLIDOS")]
        public string Apellidos { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("TELEFONO")]
        public string Telefono { get; set; }
        [Column("LINKEDIN")]
        public string LinkedIn { get; set; }
        [Column("PROVINCIAUSUARIO")]
        public string Provincia { get; set; }
        [Column("IDPROVINCIA")]
        public int IdProvincia { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set; }
        [Column("IDESTADOVALIDACION")]
        public int IdEstadoValidacion { get; set; }
        [Column("LINKEDINVISIBLE")]
        public int LinkedInVisible { get; set; }
        [Column("IDROLE")]
        public int IdRole { get; set; }
        [Column("TIPOROLE")]
        public string TipoRole { get; set; }
    }
}
