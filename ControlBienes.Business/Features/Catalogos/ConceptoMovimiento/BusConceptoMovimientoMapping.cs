using AutoMapper;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.ConceptoMovimiento
{
	public class BusConceptoMovimientoMapping : Profile
	{
		public BusConceptoMovimientoMapping()
		{
			CreateMap<EntConceptoMovimiento, EntConceptoMovimientoResponse>()
				.ForMember(dest => dest.IdConceptoMovimiento, opt => opt.MapFrom(src => src.iIdConceptoMovimiento))
				.ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
				.ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
				.ForMember(dest => dest.IdTipoMovimiento, opt => opt.MapFrom(src => src.iIdTipoMovimiento))
				.ForMember(dest => dest.TipoMovimiento, opt => opt.MapFrom(src => src.TipoMovimiento.sNombre))
				 .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
			  .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
			  .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

			CreateMap<EntConceptoMovimientoRequest, EntConceptoMovimiento>()
				.ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
				.ForMember(dest => dest.sDescripcion, opt => opt.MapFrom(src => src.Descripcion))
				.ForMember(dest => dest.iIdTipoMovimiento, opt => opt.MapFrom(src => src.IdTipoMovimiento));
		}
	}
}
