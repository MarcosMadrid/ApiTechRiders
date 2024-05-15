using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechRiders.Models
{
    [Table("TIPOSPETICIONESCATEGORIAS")]
    public class TipoPeticionCategoria
    {
        [Key]
        [Column("IDTIPOPETICIONCATEGORIA")]
        public int IdTipoPeticionCategoria {get;set;}
        [Column("CATEGORIA")]
        public string Categoria { get;set;}
    }
}
