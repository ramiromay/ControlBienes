using AutoMapper;
using ControlBienes.Entities.Almacen.Bien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Almacen.Inventario
{
	public class BusInventarioAlmacenMapping : Profile
	{
		public BusInventarioAlmacenMapping()
		{
			CreateMap<EntBienAlmacen, EntBienAlmacenResponse>()
		   .ForMember(dest => dest.IdBien, opt => opt.MapFrom(src => src.iIdBien))
		   .ForMember(dest => dest.IdAlmacen, opt => opt.MapFrom(src => src.iIdAlmacen))
		   .ForMember(dest => dest.IdBms, opt => opt.MapFrom(src => src.iIdBms))
		   .ForMember(dest => dest.Almacen, opt => opt.MapFrom(src => src.Almacen.sNombre))
		   .ForMember(dest => dest.Bien, opt => opt.MapFrom(src => src.Bms.sNombre))
		   .ForMember(dest => dest.Familia, opt => opt.MapFrom(src => src.Familia.sNombre))
		   .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.sDescripcion))
		   .ForMember(dest => dest.CodigoArmonizado, opt => opt.MapFrom(src => src.nCodigoArmonizado))
		   .ForMember(dest => dest.Existencia, opt => opt.MapFrom(src => src.iExistencia))
		   .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => src.sUnidadMedida))
		   .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.Bms.dPrecioUnitario))
		   .ForMember(dest => dest.IdFamilia, opt => opt.MapFrom(src => src.iIdFamilia))
		   .ForMember(dest => dest.IdSubfamilia, opt => opt.MapFrom(src => src.iIdSubfamilia));
		}
	}
}
