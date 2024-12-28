using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Sistema.Catalogo.Catalogo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlBienes.Entities.Sistema.ColumnaTabla
{
    public class EntColumnaTablaResponse
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int Tamanio { get; set; } 
        public string TipoDato { get; set; }
    }
}
