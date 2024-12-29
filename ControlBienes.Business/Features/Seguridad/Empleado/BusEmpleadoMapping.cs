using AutoMapper;
using ControlBienes.Entities.Seguridad.Empleado;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Empleado
{
	public class BusEmpleadoMapping : Profile
	{
		public BusEmpleadoMapping()
		{
			CreateMap<EntEmpleado, EntEmpleadoResponse>()
				.ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.iIdEmpleado))
				.ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Persona.sNombres))
				.ForMember(dest => dest.ApellidoPaterno, opt => opt.MapFrom(src => src.Persona.sPrimerNombre))
				.ForMember(dest => dest.ApellidoMaterno, opt => opt.MapFrom(src => src.Persona.sSegundoNombre))
				.ForMember(dest => dest.Hombre, opt => opt.MapFrom(src => src.Persona.bHombre))
				.ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.Persona.dtFechaNacimiento))
				.ForMember(dest => dest.Rfc, opt => opt.MapFrom(src => src.Persona.sRfc))
				.ForMember(dest => dest.IdNacionalidad, opt => opt.MapFrom(src => src.Persona.iIdNacionalidad))
				.ForMember(dest => dest.Nacionalidad, opt => opt.MapFrom(src => src.Persona.Nacionalidad.sNombre))
				.ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario.UserName))
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Usuario.Email))
				.ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Usuario.PhoneNumber))
				.ForMember(dest => dest.Permisos, opt => opt.MapFrom(src => src.Usuario.UsuariosPermisos.Select(e => e.iIdPermiso).ToImmutableList()))
				.ForMember(dest => dest.IdRol, opt => opt.MapFrom(src => src.Usuario.UsuarioRoles.FirstOrDefault().RoleId))
				.ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Usuario.UsuarioRoles.FirstOrDefault().Rol.Name))
				.ForMember(dest => dest.FechaIngreso, opt => opt.MapFrom(src => src.dtFechaIngreso))
				.ForMember(dest => dest.IdNombramiento, opt => opt.MapFrom(src => src.iIdNombramiento))
				.ForMember(dest => dest.Nombramiento, opt => opt.MapFrom(src => src.Nombramiento.sNombre))
				.ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.bActivo))
				.ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => src.dtFechaCreacion))
				.ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => src.dtFechaModificacion));

			CreateMap<EntEmpleadoRequest, EntEmpleado>()
				.ForPath(dest => dest.Persona.sNombres, opt => opt.MapFrom(src => src.Nombres))
				.ForPath(dest => dest.Persona.sPrimerNombre, opt => opt.MapFrom(src => src.ApellidoPaterno))
				.ForPath(dest => dest.Persona.sSegundoNombre, opt => opt.MapFrom(src => src.ApellidoMaterno))
				.ForPath(dest => dest.Persona.bHombre, opt => opt.MapFrom(src => src.Hombre))
				.ForPath(dest => dest.Persona.dtFechaNacimiento, opt => opt.MapFrom(src => src.FechaNacimiento))
				.ForPath(dest => dest.Persona.sRfc, opt => opt.MapFrom(src => src.Rfc))
				.ForPath(dest => dest.Persona.iIdNacionalidad, opt => opt.MapFrom(src => src.IdNacionalidad))
				.ForPath(dest => dest.Usuario.UserName, opt => opt.MapFrom(src => src.Usuario))
				.ForPath(dest => dest.Usuario.NormalizedUserName, opt => opt.MapFrom(src => src.Usuario.ToUpper()))
				.ForPath(dest => dest.Usuario.PasswordHash, opt => opt.MapFrom(src => src.NuevaContrasenia))
				.ForPath(dest => dest.Usuario.Email, opt => opt.MapFrom(src => src.Email))
				.ForPath(dest => dest.Usuario.NormalizedEmail, opt => opt.MapFrom(src => src.Email.ToUpper()))
				.ForPath(dest => dest.Usuario.PhoneNumber, opt => opt.MapFrom(src => src.Telefono))
				.ForPath(dest => dest.Usuario.PhoneNumberConfirmed, opt => opt.MapFrom(_ => true))
				.ForPath(dest => dest.Usuario.EmailConfirmed, opt => opt.MapFrom(_ => true))
				.ForPath(dest => dest.Usuario.AccessFailedCount, opt => opt.MapFrom(_ => 0))
				.ForPath(dest => dest.Usuario.LockoutEnabled, opt => opt.MapFrom(_ => false))
				.ForPath(dest => dest.Usuario.TwoFactorEnabled, opt => opt.MapFrom(_ => false))
				.ForMember(dest => dest.dtFechaIngreso, opt => opt.MapFrom(src => src.FechaIngreso))
				.ForMember(dest => dest.iIdNombramiento, opt => opt.MapFrom(src => src.IdNombramiento));
		}
	}
}
