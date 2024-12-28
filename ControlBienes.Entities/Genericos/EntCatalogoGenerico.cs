using System.ComponentModel.DataAnnotations.Schema;

namespace ControlBienes.Entities.Genericos
{
    public abstract class EntCatalogoGenerico : EntRegistroGenerico
    {
        [Column(name: "bActivo")]
        public bool bActivo {  get; set; }
    }
}
