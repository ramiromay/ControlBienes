using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen.Bien;

public partial class EntBienAlmacen : EntRegistroGenerico
{
	public long iIdBien { get; set; }

	public long iIdPeriodo{ get; set; }


	public long iIdAlmacen { get; set; }

	public long iIdBms { get; set; }

	public string sDescripcion { get; set; }

	public decimal? nCodigoArmonizado { get; set; }

	public double iExistencia { get; set; }

	public string sUnidadMedida { get; set; }

	public long iIdFamilia { get; set; }

	public long? iIdSubfamilia { get; set; }

	public virtual EntAlmacen Almacen { get; set; }

	public virtual EntPeriodo Periodo { get; set; }

	public virtual EntBms Bms { get; set; }

	public virtual EntFamilia Familia { get; set; }

	public virtual EntSubfamilia Subfamilia { get; set; }
}
