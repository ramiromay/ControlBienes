using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.General.Cuenta;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.Empleado;

namespace ControlBienes.Entities.Catalogos;

public partial class EntAlmacen : EntRegistroGenerico
{
    public long iIdAlmacen { get; set; }

    public long iIdPeriodo { get; set; }

    public string sNombre { get; set; }

    public string sDireccion { get; set; }

    public string sHorario { get; set; }

    public long iIdEmpleado { get; set; }

    public long iIdCuenta { get; set; }

    public long iIdMetodoCosteo { get; set; }

    public string sFolioEntrada { get; set; }

    public string sFolioSalida { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntAnaquel> Anaqueles { get; set; } = new List<EntAnaquel>();

    public virtual ICollection<EntBienAlmacen> Bienes { get; set; } = new List<EntBienAlmacen>();

    public virtual EntCuenta Cuenta { get; set; }

    public virtual EntEmpleado Empleado { get; set; }

    public virtual EntMetodoCosteo MetodoCosteo { get; set; }

    public virtual EntPeriodo Periodo { get; set; }

    public virtual ICollection<EntMovimiento> Movimientos { get; set; } = new List<EntMovimiento>();

    public virtual ICollection<EntZona> Zonas { get; set; } = new List<EntZona>();
}
