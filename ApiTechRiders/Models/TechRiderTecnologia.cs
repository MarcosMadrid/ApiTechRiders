using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("DATOSTECHRIDERTECNOLOGIAS")]
    public class TechRiderTecnologia
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
        public string Telefono { get; set; }
        [Column("IDTECNOLOGIA")]
        public int IdTecnologia { get; set; }
        [Column("NOMBRE_TECNOLOGIA")]
        public string Tecnologia { get; set; }
        [Column("IDTIPOTECNOLOGIA")]
        public int IdTipoTecnologia { get; set; }
        [Column("TIPOTECNOLOGIA")]
        public string TipoTecnologia { get; set; }
    }
}
