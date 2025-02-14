using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Almacen.ProgramaOperativo;
using ControlBienes.Entities.Almacen.Proveedor;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Almacen.Movimiento;

public partial class EntMovimiento : EntRegistroGenerico
{
	public long iIdMovimiento { get; set; }
	public long iIdPeriodo { get; set; }

	public long iIdEtapa { get; set; }


	public long iIdTipoMovimiento { get; set; }

	public long iIdAlmacen { get; set; }

	public long iIdMetodoAdquisicion { get; set; }

	public long? iIdProgramaOperativo { get; set; }

	public string sNumeroFactura { get; set; }

	public DateTime? dtFechaResepcion { get; set; }

	public long? iIdFuenteFinanciamiento { get; set; }

	public long? iIdConceptoMovimiento { get; set; }

	public long? iIdProveedor { get; set; }

	public long? iIdFamilia { get; set; }

	public string sObservaciones { get; set; }

	public double? dImporteTotal { get; set; }

	public string sArticulos { get; set; }

	public virtual EntAlmacen Almacen { get; set; }

	public virtual EntPeriodo Periodo { get; set; }

	public virtual EntEtapa Etapa { get; set; }

	public virtual EntConceptoMovimiento ConceptoMovimiento { get; set; }

	public virtual EntFamilia Familia { get; set; }

	public virtual EntFuenteFinanciamiento FuenteFinanciamiento { get; set; }

	public virtual EntMetodoAdquisicion MetodoAdquisicion { get; set; }

	public virtual EntProgramasOperativo IIdProgramaOperativoNavigation { get; set; }

	public virtual EntProveedor Proveedor { get; set; }

	public virtual EntTipoMovimiento TipoMovimiento { get; set; }

	public virtual ICollection<EntMovimientoBien> MovimientosBienes { get; set; } = new List<EntMovimientoBien>();
}
