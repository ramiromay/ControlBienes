using AutoMapper;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Color;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Repository.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.Seguridad.Empleado;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using ControlBienes.Entities.Seguridad.UsuarioRol;
using ControlBienes.Services.Constants;
using ControlBienes.Services.Contracts;
using ControlBienes.Services.Models;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Seguridad.Empleado
{
	public class BusEmpleado : IBusEmpleado
	{

		private readonly IEmailService _emailService;
		private readonly IDatEmpleado _repositorio;
		private readonly IDatUsuario _repositorioUsuario;
		private readonly IDatUsuarioPermiso _repositorioUsuarioPermiso;
		private readonly IDatUsuarioRol _repositorioUsuarioRol;
		private readonly UserManager<EntUsuario> _userManager;
		private readonly IDatPersona _repositorioPersona;
		private readonly IDatRol _repositorioRol;
		private readonly IDatNacionalidad _repositorioNacionalidad;
		private readonly IDatNombramiento _repositorioNombramiento;
		private readonly ILogger<BusEmpleado> _logger;
		private readonly IMapper _mapper;
		private readonly IValidator<EntEmpleadoRequest> _validatorCreacion;
		const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkEmpleado;
		const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorEmpleado;

		public BusEmpleado(IDatEmpleado repositorio,
			IEmailService emailService,
			UserManager<EntUsuario> userManager, 
			IDatUsuario repositoriooUsuario,
			IDatUsuarioPermiso repositorioUsuarioPermiso,
			IDatUsuarioRol repositorioUsuarioRol,
			IDatPersona repositorioPersona,
			IDatRol repositorioRol,
			IDatNacionalidad repositorioNacionalidad,
			IDatNombramiento repositorioNombramiento,
			IMapper mapper, 
			ILogger<BusEmpleado> logger,
			IValidator<EntEmpleadoRequest> validator)
		{
			_emailService = emailService;
			_repositorio = repositorio;
			_userManager = userManager;
			_repositorioUsuario = repositoriooUsuario;
			_repositorioPersona = repositorioPersona;
			_repositorioRol = repositorioRol;
			_repositorioNacionalidad = repositorioNacionalidad;
			_repositorioNombramiento = repositorioNombramiento;
			_repositorioUsuarioPermiso = repositorioUsuarioPermiso;
			_repositorioUsuarioRol = repositorioUsuarioRol;
			_mapper = mapper;
			_logger = logger;
			_validatorCreacion = validator;
		}

		private string BValidarContraseniaNueva(EntEmpleadoRequest request)
		{
			if (string.IsNullOrEmpty(request.NuevaContrasenia))
				return "La nueva contraseña es requerida";

			if (string.IsNullOrEmpty(request.NuevaContraseniaConfirmacion))
				return "La confirmación de la nueva contraseña es requerida";

			if (request.NuevaContrasenia != request.NuevaContraseniaConfirmacion)
				return "La nueva contraseña y la confirmación de la nueva contraseña no coinciden";

			return string.Empty;
		}

		private string BValidarContraseniasActualizacion(EntUsuario usuario, EntEmpleadoRequest request)
		{
			if (!string.IsNullOrEmpty(request.ContraseniaActual) && usuario != null)
			{
				var passwordHasher = new PasswordHasher<EntUsuario>();
				var result = passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, request.ContraseniaActual);

				if (result == PasswordVerificationResult.Failed)
					return "La contraseña actual no es correcta";

				return BValidarContraseniaNueva(request);
			}
			return string.Empty;
		}

		private void BValidarRequest(EntUsuario usuario, EntEmpleadoRequest request, bool esCreacion = false)
		{
			var resultadoValidacion = _validatorCreacion.Validate(request);
			var erroresContrasenia = esCreacion 
				? BValidarContraseniaNueva(request) 
				: BValidarContraseniasActualizacion(usuario, request);

			if (resultadoValidacion.IsValid && string.IsNullOrEmpty(erroresContrasenia)) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores + erroresContrasenia);
		}

		private async Task BValidarRequestBD(EntEmpleado empleado,EntEmpleadoRequest request)
		{
			var idPersona = empleado != null ? empleado.iIdPersona : 0;
			var idUsuario =  empleado != null ? empleado.iIdUsuario : 0;
			var existeNombreEmpleado = await _repositorioPersona.DExisteRegistroAsync(e =>
				e.sNombres == request.Nombres &&
				e.sPrimerNombre == request.ApellidoPaterno &&
				e.sSegundoNombre == request.ApellidoMaterno &&
				e.iIdPersona != idPersona);

			var existeRfcc = await _repositorioPersona.DExisteRegistroAsync(e => 
				e.sRfc == request.Rfc &&
				e.iIdPersona != idPersona);

			var existeRol = await _repositorioRol.DExisteRegistroAsync(e => e.Id == request.IdRol);

			var existeNacionalidad = await _repositorioNacionalidad.DExisteRegistroAsync(e =>
				e.iIdNacionalidad == request.IdNacionalidad);

			var existeNombramiento = await _repositorioNombramiento.DExisteRegistroAsync(e => 
				e.iIdNombramiento == request.IdNombramiento);

			var existeUsuario = await _repositorioUsuario.DExisteRegistroAsync(e => 
				e.NormalizedUserName == request.Usuario.ToUpper() && 
				e.Id != idUsuario);

			var existeEmail = await _repositorioUsuario.DExisteRegistroAsync(e => 
				e.NormalizedEmail == request.Email.ToUpper() && 
				e.Id != idUsuario);

			var errores = new StringBuilder();
			if (existeNombreEmpleado) errores.Append("Los Nombres y Apellidos del empleado ya existe,");
			if (existeRfcc) errores.Append("El RFC del empleado ya se encuentra registrado en otro empleado,");
			if (!existeNacionalidad) errores.Append("La Nacionalidad asignada al usuario no existe,");
			if (!existeNombramiento) errores.Append("El Nombramiento asignado al usuario no existe,");
			if (!existeRol) errores.Append("El Rol asignado al usuario no existe,");
			if (existeUsuario) errores.Append("El Nombre de usuario ya se encuentra registrado,");
			if (existeEmail) errores.Append("El Email ya se encuentra registrado");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter)) return;
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());
		}

		private void BValidarIdentityResult(IdentityResult identityResult)
		{
			if (identityResult.Succeeded) return;
			var erroresConstrasenia = new StringBuilder();
			foreach (var error in identityResult.Errors)
			{
				string errorCode = error.Code;
				if (errorCode.Contains("Password"))
				{
					if (errorCode.Equals("PasswordTooShort"))
					{
						erroresConstrasenia.Append("La contraseña es demasiado corta,");
					}
					else if (errorCode.Equals("PasswordRequiresDigit"))
					{	
						erroresConstrasenia.Append("La contraseña debe contener al menos un número,");
					}
					else if (errorCode.Equals("PasswordRequiresLower"))
					{
						erroresConstrasenia.Append("La contraseña debe contener al menos una letra minúscula,");
					}
					else if (errorCode.Equals("PasswordRequiresUpper"))
					{
						erroresConstrasenia.Append("La contraseña debe contener al menos una letra mayúscula,");
					}
					else if (errorCode.Equals("PasswordRequiresNonAlphanumeric"))
					{
						erroresConstrasenia.Append("La contraseña debe contener al menos un carácter no alfanumérico,");
					}
				}
			}
			var errores = BusConvertirErrors.URemoverComillaFinal(erroresConstrasenia.ToString().Trim());
			if (!string.IsNullOrEmpty(errores))
			{
				throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
			}
			throw new Exception("Ocurrio un error inesperado al crear el Usuario" + identityResult.Errors);
		}

		public async Task<EntityResponse<int>> BActualizarAsync(long id, EntEmpleadoRequest request)
		{
			string nombreMetodo = nameof(BActualizarAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un empleado");
			await using var transaction = await _repositorio.DBeginTransactionAsync();

			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(
					predicado: e => e.iIdEmpleado == id, 
					incluir: new List<Expression<Func<EntEmpleado, object>>>()
					{
						e => e.Persona,
						e => e.Usuario
					}, 
					desactivarTracking: false)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				BValidarRequest(entidad.Usuario, request);
				await BValidarRequestBD(entidad, request);

				var persona = entidad.Persona;
				persona.sNombres = request.Nombres;
				persona.sPrimerNombre = request.ApellidoPaterno;
				persona.sSegundoNombre = request.ApellidoMaterno;
				persona.bHombre = request.Hombre;
				persona.sRfc = request.Rfc;
				persona.dtFechaNacimiento = request.FechaNacimiento.Value;
				persona.iIdNacionalidad = request.IdNacionalidad.Value;

				var usuario = entidad.Usuario;
				usuario.UserName = request.Usuario;
				usuario.NormalizedUserName =  request.Usuario.ToUpper();
				usuario.Email = request.Email;
				usuario.NormalizedEmail = request.Email.ToUpper();
				usuario.PhoneNumber = request.Telefono;
				usuario.dtFechaModificacion = DateTime.Now;

				entidad.dtFechaIngreso = request.FechaIngreso.Value;
				entidad.iIdNombramiento = request.IdNombramiento.Value;

				var resultEmpleado = await _repositorio.DActualizarAsync(entidad);
				var resultUsuarioPermisos = await _repositorioUsuarioPermiso.DActualizarPermisosUsuarioAsync(entidad.Usuario.Id, request.Permisos);
				var rolesIds = new List<long> { request.IdRol.Value };
				var resultUsuarioRol = await _repositorioUsuarioRol.DActualizarRolesUsuarioAsync(entidad.Usuario.Id, rolesIds);

				if (!string.IsNullOrEmpty(request.ContraseniaActual) &&
					!string.IsNullOrEmpty(request.NuevaContrasenia))
				{
					var resultCambiarContrasenia = await _userManager.ChangePasswordAsync(entidad.Usuario, request.ContraseniaActual, request.NuevaContrasenia);
					BValidarIdentityResult(resultCambiarContrasenia);
				}
				await transaction.CommitAsync();
				resultado.Success(resultUsuarioPermisos + resultUsuarioRol + resultEmpleado, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualiza el empleado"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCambiarEstatusAsync(long id)
		{
			string nombreMetodo = nameof(BCambiarEstatusAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualiza el estatus del empleado");
			try
			{
				var entidad = await _repositorio.DObtenerRegistroAsync(id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var result = await _repositorio.DActualizarEstatusAsync(entidad);
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el estatus del color"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearAsync(EntEmpleadoRequest request)
		{
			var nombreMetodo = nameof(BCrearAsync);
			var resultado = new EntityResponse<int>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un empleado");
			await using var transaction = await _repositorio.DBeginTransactionAsync();
			try
			{
				BValidarRequest(null, request, esCreacion: true);
				await BValidarRequestBD(null, request);

				var entidad = _mapper.Map<EntEmpleado>(request);
				var usuarioResult = await _userManager.CreateAsync(entidad.Usuario, request.NuevaContrasenia);
				BValidarIdentityResult(usuarioResult);

				var usuario = entidad.Usuario;
				var resultUsuarioPermisos = await _repositorioUsuarioPermiso.DCrearPermisosUsuariosAsync(usuario.Id, request.Permisos);

				var rolesIds = new List<long> { request.IdRol.Value };
				var resultUsuarioRol = await _repositorioUsuarioRol.DCrearRolesUsuarioAsync(usuario.Id, rolesIds);

				var resultEmpleado = await _repositorio.DCrearAsync(entidad);

				var email = new EmailModels
				{
					To = request.Email,
					Name = request.Nombres.Split(" ")[0],
					LastName = request.ApellidoPaterno,
					Subject = EmailTemplateConstants.WelcomeSubject,
					Template = EnumEmailTemplate.Welcome
				};
				await _emailService.BSendEmailAsync(email);

				await transaction.CommitAsync();
				resultado.Success(resultUsuarioPermisos + resultUsuarioRol + resultEmpleado, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el empleado"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntEmpleadoResponse>> BObtenerRegistroAsync(long id)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<EntEmpleadoResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el empleado");
			try
			{
				var responseDto = await _repositorio.DObtenerProyeccionElementoAsync<EntEmpleadoResponse>(e => e.iIdEmpleado == id)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntEmpleadoResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el empleado"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntEmpleadoResponse>>> BObtenerTodosAsync(bool? activo)
		{
			var nombreMetodo = nameof(BObtenerTodosAsync);
			var resultado = new EntityResponse<IEnumerable<EntEmpleadoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todos los empleados");
			try
			{
				Expression<Func<EntEmpleado, bool>>? predicado = activo.HasValue
					? r => r.bActivo == activo.Value
					: null;
				var repornseDto = await _repositorio.DObtenerProyeccionListaAsync<EntEmpleadoResponse>(predicado: predicado);
				resultado.Success(repornseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntEmpleadoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todos los empleados"
				);
			}

			return resultado;
		}
	}
}
