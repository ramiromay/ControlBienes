using AutoMapper;
using ControlBienes.Entities.Almacen.EtapaMovimiento;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.EtapaSolicitud;
using ControlBienes.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.MovimientoBien
{
	public class BusMovimientoBienMapping : Profile
	{
		public BusMovimientoBienMapping()
		{
			CreateMap<EntEtapaMovimiento, EntEtapaResponse>()
			.ForMember(dest => dest.IdEtapa, opt => opt.MapFrom(src => src.EtapaDestino.iIdEtapa))
			.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.EtapaDestino.sNombre));

			CreateMap<EntMovimiento, EntMovimientoBienResponse>()
				.ForMember(dest => dest.IdMovimiento, opt => opt.MapFrom(src => src.iIdMovimiento))
				.ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
				.ForMember(dest => dest.IdEtapa, opt => opt.MapFrom(src => src.iIdEtapa))
				.ForMember(dest => dest.IdTipoMovimiento, opt => opt.MapFrom(src => src.iIdTipoMovimiento))
				.ForMember(dest => dest.IdAlmacen, opt => opt.MapFrom(src => src.iIdAlmacen))
				.ForMember(dest => dest.IdMetodoAdquisicion, opt => opt.MapFrom(src => src.iIdMetodoAdquisicion))
				.ForMember(dest => dest.IdProgramaOperativo, opt => opt.MapFrom(src => src.iIdProgramaOperativo))
				.ForMember(dest => dest.NumeroFactura, opt => opt.MapFrom(src => src.sNumeroFactura))
				.ForMember(dest => dest.FechaResepcion, opt => opt.MapFrom(src => src.dtFechaResepcion))
				.ForMember(dest => dest.IdConceptoMovimiento, opt => opt.MapFrom(src => src.iIdConceptoMovimiento))
				.ForMember(dest => dest.IdProveedor, opt => opt.MapFrom(src => src.iIdProveedor))
				.ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
				.ForMember(dest => dest.Observaciones, opt => opt.MapFrom(src => src.sObservaciones))
				.ForMember(dest => dest.ImporteTotal, opt => opt.MapFrom(src => src.dImporteTotal))
				.ForMember(dest => dest.Almacen, opt => opt.MapFrom(src => src.Almacen.sNombre ?? string.Empty))
				.ForMember(dest => dest.Etapa, opt => opt.MapFrom(src => src.Etapa.sNombre))
				.ForMember(dest => dest.ConceptoMovimiento, opt => opt.MapFrom(src => src.ConceptoMovimiento.sNombre ?? string.Empty))
				.ForMember(dest => dest.Familia, opt => opt.MapFrom(src => $"{src.Familia.iIdFamilia}.- {src.Familia.sNombre}" ?? string.Empty))
				.ForMember(dest => dest.MetodoAdquisicion, opt => opt.MapFrom(src => src.MetodoAdquisicion.sNombre ?? string.Empty))
				.ForMember(dest => dest.Proveedor, opt => opt.MapFrom(src => src.Proveedor.sNombre ?? string.Empty))
				.ForMember(dest => dest.TipoMovimiento, opt => opt.MapFrom(src => src.TipoMovimiento.sNombre ?? string.Empty))
				.ForMember(dest => dest.Articulos, opt => opt.MapFrom(src => src.sArticulos));

			CreateMap<EntMovimientoBienRequest, EntMovimiento>()
				.ForMember(dest => dest.iIdPeriodo, opt => opt.MapFrom(src => 2024))
				.ForMember(dest => dest.iIdEtapa, opt => opt.MapFrom(src => (long)EnumEtapa.CapturaInicial))
				.ForMember(dest => dest.iIdTipoMovimiento, opt => opt.MapFrom(src => src.IdTipoMovimiento))
				.ForMember(dest => dest.iIdAlmacen, opt => opt.MapFrom(src => src.IdAlmacen))
				.ForMember(dest => dest.iIdMetodoAdquisicion, opt => opt.MapFrom(src => src.IdMetodoAdquisicion))
				.ForMember(dest => dest.iIdProgramaOperativo, opt => opt.MapFrom(src => src.IdProgramaOperativo))
				.ForMember(dest => dest.sNumeroFactura, opt => opt.MapFrom(src => src.NumeroFactura))
				.ForMember(dest => dest.dtFechaResepcion, opt => opt.MapFrom(src => src.FechaResepcion))
				.ForMember(dest => dest.iIdConceptoMovimiento, opt => opt.MapFrom(src => src.IdConceptoMovimiento))
				.ForMember(dest => dest.iIdProveedor, opt => opt.MapFrom(src => src.IdProveedor))
				.ForMember(dest => dest.iIdFamilia, opt => opt.MapFrom(src => src.IdFamilia))
				.ForMember(dest => dest.sObservaciones, opt => opt.MapFrom(src => src.Observaciones))
				.ForMember(dest => dest.dImporteTotal, opt => opt.MapFrom(src => BusTransformarUtils.UCalcularImporteTotal(src.Articulos)))
				.ForMember(dest => dest.sArticulos, opt => opt.MapFrom(src => src.Articulos));
		}
	}
}
