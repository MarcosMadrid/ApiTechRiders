using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("PETICIONESFORMATOVIEW")]
    public class PeticionFormatoView
    {
        [Key]
        [Column("POSICION")]
        public int Posicion { get; set; }
        [Column("IDREGISTRO")]
        public int IdRegistroPeticion { get; set; }
        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }
        [Column("TIPOPETICION")]
        public string TipoPeticion { get; set; }
        [Column("IDTIPOPETICION")]
        public int IdTipoPeticion { get; set; }
    }
}
