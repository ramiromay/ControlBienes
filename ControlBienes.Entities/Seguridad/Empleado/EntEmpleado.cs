using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.General.Nombramiento;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.Persona;
using ControlBienes.Entities.Seguridad.Usuario;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ControlBienes.Entities.Seguridad.Empleado;

public partial class EntEmpleado : EntCatalogoGenerico
{
    public long iIdEmpleado { get; set; }

    public long iIdPersona { get; set; }

    public long iIdUsuario { get; set; }

    public DateTime dtFechaIngreso { get; set; }

    public long iIdNombramiento { get; set; }

    public virtual ICollection<EntAlmacen> Almacenes { get; set; } = new List<EntAlmacen>();

    public virtual ICollection<EntBaja> Bajas { get; set; } = new List<EntBaja>();

    public virtual ICollection<EntDetalleDesincorporacion> DetallesDesincorporaciones { get; set; } = new List<EntDetalleDesincorporacion>();

    public virtual ICollection<EntDetalleDestinoFinal> DetallesDestinoFinales { get; set; } = new List<EntDetalleDestinoFinal>();

    public virtual EntNombramiento Nombramiento { get; set; }

    public virtual EntPersona Persona { get; set; }

    public virtual EntUsuario Usuario { get; set; }

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();

	public override string ToString()
	{

		return JsonSerializer.Serialize(this); ;
	}
}
