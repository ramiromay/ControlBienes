using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Alta;
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

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual ICollection<EntEtapaTramite> EtapasTramitesOrigen { get; set; } = new List<EntEtapaTramite>();

    public virtual ICollection<EntEtapaTramite> EtapasTramitesDestino { get; set; } = new List<EntEtapaTramite>();

     public virtual ICollection<EntSeguimiento> Seguimientos { get; set; } = new List<EntSeguimiento>();

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();
}
