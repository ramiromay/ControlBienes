using ControlBienes.Entities.Catalogos.EstadoGeneral;
using ControlBienes.Entities.Catalogos.TipoAfectacion;
using ControlBienes.Entities.Catalogos.TipoInmueble;
using ControlBienes.Entities.Catalogos.UsoInmueble;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DatoRegistral;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.DatoInmueble;

public partial class EntDatoInmueble
{
    public long iIdDatoInmueble { get; set; }

    public string sNomenclatura { get; set; }

    public long iIdTipoInmueble { get; set; }

    public long iIdUsoInmueble { get; set; }

    public long iIdTipoDomninio { get; set; }

    public long? iIdEstadoGeneral { get; set; }

    public long iIdTipoAfectacion { get; set; }

    public string sAfectante { get; set; }

    public string sPublicacion { get; set; }

	public string sEscrituraTitulo { get; set; }

	public string sExpediente{ get; set; }

    public decimal? dValorHistorico { get; set; }

    public decimal? dValorLibros { get; set; }

    public decimal? dDepreciacion { get; set; }


	public DateTime dtFechaAltaSistema { get; set; }

    public long iIdDatoRegistral { get; set; }

    public virtual ICollection<EntBienPatrimonio> BienesPatrimonio { get; set; } = new List<EntBienPatrimonio>();

    public virtual ICollection<EntDetalleAlta> DetallesAlta { get; set; } = new List<EntDetalleAlta>();

    public virtual ICollection<EntDetalleModificacion> DetallesModificaciones { get; set; } = new List<EntDetalleModificacion>();

    public virtual EntDatoRegistral DatosRegistral { get; set; }

    public virtual EntEstadoGeneral EstadoGeneral { get; set; }

    public virtual EntTipoAfectacion TipoAfectacion { get; set; }

    public virtual EntTipoDominio TiposDominio { get; set; }

    public virtual EntTipoInmueble TipoInmueble { get; set; }

    public virtual EntUsoInmueble UsoInmueble { get; set; }
}
