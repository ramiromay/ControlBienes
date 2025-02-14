using AutoMapper;
using ControlBienes.Entities.Catalogos.Almacen;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Catalogos.Almacen
{
	public class BusAlmacenMapping : Profile
	{
		public BusAlmacenMapping()
		{
			CreateMap<EntAlmacen, EntAlmacenResponse>()
			  .ForMember(dest => dest.IdAlmacen, opt => opt.MapFrom(src => src.iIdAlmacen))
			  .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.iIdEmpleado))
			  .ForMember(dest => dest.IdPeriodo, opt => opt.MapFrom(src => src.iIdPeriodo))
			  .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => $"{src.Empleado!.Persona.sNombres} {src.Empleado!.Persona.sPrimerNombre} {src.Empleado!.Persona.sSegundoNombre}"))
			  .ForMember(dest => dest.IdMetodoCosteo, opt => opt.MapFrom(src => src.iIdMetodoCosteo))
			  .ForMember(dest => dest.MetodoCosteo, opt => opt.MapFrom(src => src.MetodoCosteo!.sAbreviacion	  ))
			  .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.sNombre))
			  .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.sDireccion))
			  .ForMember(dest => dest.Horario, opt => opt.MapFrom(src => src.sHorario))
			  .ForMember(dest => dest.IdCuenta, opt => opt.MapFrom(src => src.iIdCuenta))
			  .ForMember(dest => dest.FolioEntrada, opt => opt.MapFrom(src => src.sFolioEntrada))
			  .ForMember(dest => dest.FolioSalida, opt => opt.MapFrom(src => src.sFolioSalida))
			  .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
			  .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
			  .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

			CreateMap<EntAlmacenRequest, EntAlmacen>()
	.ForMember(dest => dest.iIdEmpleado, opt => opt.MapFrom(src => src.IdEmpleado))
	.ForMember(dest => dest.iIdMetodoCosteo, opt => opt.MapFrom(src => src.IdMetodoCosteo))
	.ForMember(dest => dest.iIdPeriodo, opt => opt.MapFrom(src => src.IdPeriodo))
	.ForMember(dest => dest.sNombre, opt => opt.MapFrom(src => src.Nombre))
	.ForMember(dest => dest.sDireccion, opt => opt.MapFrom(src => src.Direccion))
	.ForMember(dest => dest.sHorario, opt => opt.MapFrom(src => src.Horario))
	.ForMember(dest => dest.iIdCuenta, opt => opt.MapFrom(src => src.IdCuenta))
	.ForMember(dest => dest.sFolioEntrada, opt => opt.MapFrom(src => src.FolioEntrada))
	.ForMember(dest => dest.sFolioSalida, opt => opt.MapFrom(src => src.FolioSalida));

		}
	}
}
