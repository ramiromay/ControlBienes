using ControlBienes.Entities.Almacen.EtapaMovimiento;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.EtapaSolicitud;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Etapa;

public partial class EntEtapa : EntRegistroGenerico
{
    public long iIdEtapa { get; set; }

    public string sNombre { get; set; }

    public bool bActivo { get; set; }

	public virtual ICollection<EntMovimiento> EtapasMovimientos { get; set; } = new List<EntMovimiento>();

	public virtual ICollection<EntEtapaSolicitud> EtapasSolicitudesDestino{ get; set; } = new List<EntEtapaSolicitud>();

	public virtual ICollection<EntEtapaSolicitud> EtapasSolicitudesOrigen { get; set; } = new List<EntEtapaSolicitud>();

	public virtual ICollection<EntEtapaMovimiento> EtapasMovimientosDestino { get; set; } = new List<EntEtapaMovimiento>();

	public virtual ICollection<EntEtapaMovimiento> EtapasMovimientosOrigen { get; set; } = new List<EntEtapaMovimiento>();


	public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual ICollection<EntEtapaTramite> EtapasTramitesOrigen { get; set; } = new List<EntEtapaTramite>();

    public virtual ICollection<EntEtapaTramite> EtapasTramitesDestino { get; set; } = new List<EntEtapaTramite>();

     public virtual ICollection<EntSeguimiento> Seguimientos { get; set; } = new List<EntSeguimiento>();

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();
}
