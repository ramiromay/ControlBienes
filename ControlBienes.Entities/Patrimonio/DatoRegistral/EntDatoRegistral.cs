using ControlBienes.Entities.Catalogos.OrigenValor;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.DatoInmueble;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.DatoRegistral;

public partial class EntDatoRegistral : EntRegistroGenerico
{
    public long iIdDatoRegistral { get; set; }

    public string sNombre { get; set; }

    public int iFolioElectronico { get; set; }

    public int iFolioCatastro { get; set; }

    public string sCalle { get; set; }

    public double dSuperficie { get; set; }

    public decimal dValorTerreno { get; set; }

    public string sNumeroExterior { get; set; }

    public string sNumeroInterior { get; set; }

    public string sCruzamimiento1 { get; set; }

    public string sCruzamimiento2 { get; set; }

    public double dSuperficieContruccion { get; set; }

    public string sTablaje { get; set; }

    public decimal dValorConstruccion { get; set; }

    public decimal dValorInicial { get; set; }

    public decimal? nCodigoPostal { get; set; }

    public long iIdOrigenValor { get; set; }

    public string sAsentamiento { get; set; }

    public string sPropietario { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntDatoInmueble> DatosInmuebles { get; set; } = new List<EntDatoInmueble>();

    public virtual EntOrigenValor OrigenValor { get; set; }
}
