using AutoMapper;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.Seguridad.Autentificacion;
using ControlBienes.Entities.Seguridad.Empleado;
using ControlBienes.Entities.Seguridad.Persona;
using ControlBienes.Entities.Seguridad.Rol;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Autentificacion
{
	public class BusAutentificationMapping
	{

		public static EntAutentificacionResponse Map(EntEmpleado empleado, EntRol rol, string token, IEnumerable<EntUsuarioPermiso> permisos)
		{
			var persona = empleado.Persona;
			var usuario = empleado.Usuario;
			var esUnSoloNombre = persona.sNombres.Trim().Split(' ').Length == 1;
			var nombre =  esUnSoloNombre 
				? persona.sNombres 
				: $"{persona.sNombres.Trim().Split(' ')[0]} {persona.sPrimerNombre}";

			return new EntAutentificacionResponse
			{
				Id = usuario.Id,
				Usuario = usuario.UserName,
				Nombre = nombre,
				Rol = usuario.UserName,
				Token = token,
				Permisos = permisos.Select(e => e.iIdPermiso).ToArray()
			};
		}

	}
}
