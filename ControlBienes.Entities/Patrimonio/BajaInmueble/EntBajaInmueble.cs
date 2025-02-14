using ControlBienes.Entities.Catalogos.TipoInmueble;
using ControlBienes.Entities.Catalogos.UsoInmueble;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.BajaInmueble;

public partial class EntBajaInmueble
{
    public long iIdBajaInmueble { get; set; }

    public long iIdBien { get; set; }

    public int? iFolioElectronico { get; set; }

    public string sClaveCatastral { get; set; }

    public DateTime dtFechaBaja { get; set; }

    public DateTime dtFechaBajaSistema { get; set; }

    public decimal dValorBaja { get; set; }

    public string sEscrituraTitulo { get; set; }

    public DateTime dtFechaDesincorporacion { get; set; }

    public string sInmueblePermutado { get; set; }

    public string sAvaluo1 { get; set; }

    public string sAvaluo2 { get; set; }

    public string sAfavorDe { get; set; }

    public string sDecretoPublicacion { get; set; }

    public string sReferencaPoliza { get; set; }

    public string sJustificacion { get; set; }

    public long? iIdUsoInmueble { get; set; }

    public long? iIdTipoInmueble { get; set; }

    public long? iIdTipoDomninio { get; set; }

    public string sObservacion { get; set; }

    public string sDestinoBien { get; set; }

    public double dValorBienPermutadoConstruccion { get; set; }

    public double dValorBienPermutadoTerreno { get; set; }

    public DateTime dtFechaPermuta { get; set; }

    public string sRepositario { get; set; }

    public string sExpedienteUnion { get; set; }

    public DateTime? dtFechaUnion { get; set; }

    public string sDonatario { get; set; }

    public DateTime dtFechaDonacion { get; set; }

    public string sDecretoPublicacionDonacion { get; set; }

    public virtual ICollection<EntDetalleBaja> DetallesBajas { get; set; } = new List<EntDetalleBaja>();

    public virtual EntBienPatrimonio Bien { get; set; }

    public virtual EntTipoDominio TiposDominio { get; set; }

    public virtual EntTipoInmueble TipoInmueble { get; set; }

    public virtual EntUsoInmueble UsoInmueble { get; set; }
}
