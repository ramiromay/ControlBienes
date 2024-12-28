using System.ComponentModel.DataAnnotations.Schema;

namespace ControlBienes.Entities.Genericos
{
    public abstract class EntRegistroGenerico
    {
        [Column(name: "dtFechaCreacion", TypeName = "datetime")]
        public DateTime dtFechaCreacion { get; set; }

        [Column(name: "dtFechaModificacion", TypeName = "datetime")]
        public DateTime dtFechaModificacion { get; set; }
    }
}
