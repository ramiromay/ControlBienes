using ControlBienes.Entities.Catalogos.EstadoFisico;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Catalogos.TipoAdquisicion;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Catalogos.Ubicacion;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.General.Municipio;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using ControlBienes.Entities.Patrimonio.DatoInmueble;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Factura;
using ControlBienes.Entities.Patrimonio.Licitacion;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Modificacion;

public partial class EntDetalleModificacion
{
    public long iIdDetalleModificacion { get; set; }

    public long iIdBien { get; set; }

    public long iIdSolicitud { get; set; }

    public int? iNumeroBienes { get; set; }

    public long iIdTipoBien { get; set; }

    public string sFolioBien { get; set; }

    public long iIdFamilia { get; set; }

    public long iIdSubfamilia { get; set; }

    public long? iIdBms { get; set; }

    public string sReferenciaConac { get; set; }

    public string sPartidaEspecifica { get; set; }

    public string sDescripcion { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

	public long? iIdCentroCosto { get; set; }

	public string sRequisicion { get; set; }

    public string sOrdenCompra { get; set; }

    public string sCuentaPorPagar { get; set; }

    public long iIdTipoAdquisicion { get; set; }

    public long iIdMunicipio { get; set; }

    public string sSustituyeBv { get; set; }

    public long? iIdUbicacion { get; set; }

    public string sNoSeries { get; set; }

    public string sFolioAnterior { get; set; }

    public long iIdEstadoFisico { get; set; }

    public decimal dPrecioUnitario { get; set; }

    public int iAniosVida { get; set; }

    public DateTime dtFechaInicioUso { get; set; }

    public DateTime dtFechaAdquisicion { get; set; }

    public decimal dPrecioDepreciado { get; set; }

    public decimal dPrecioDesechable { get; set; }

    public string sCuentaActivo { get; set; }

    public string sCuentaActualizacion { get; set; }

    public string sCaracteristicas { get; set; }

    public string sResguardantes { get; set; }

    public string sObservacionBien { get; set; }

    public string sObservacionResponsable { get; set; }

    public long? iIdDatoInmueble { get; set; }

    public long? iIdLicitacion { get; set; }

    public long? iIdFactura { get; set; }

	public long? iIdDatoGeneral { get; set; }

	public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual EntBienPatrimonio Bien { get; set; }

    public virtual EntBms Bms { get; set; }

    public virtual EntDatoInmueble DatoInmueble { get; set; }

    public virtual EntEstadoFisico EstadoFisico { get; set; }

    public virtual EntFamilia Familia { get; set; }

    public virtual EntMunicipio Municipio { get; set; }

    public virtual EntSolicitud Solicitud { get; set; }

    public virtual EntSubfamilia Subfamilia { get; set; }

    public virtual EntTipoAdquisicion TipoAdquisicion { get; set; }

    public virtual EntTipoBien TipoBien { get; set; }

    public virtual EntUbicacion Ubicacion { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }

	public virtual EntUnidadAdministrativa CentroCosto { get; set; }

	public virtual EntDatoGeneral DatoGeneral { get; set; }

    public virtual EntFactura Factura { get; set; }

    public virtual EntLicitacion Licitacion { get; set; }
}
