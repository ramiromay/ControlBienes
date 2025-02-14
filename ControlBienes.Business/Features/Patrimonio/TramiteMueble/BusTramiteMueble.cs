using AutoMapper;
using Azure.Core;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Repository.Patrimonio;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.General.Cuenta;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleMovimiento;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.Movimiento;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.SubModulo;
using ControlBienes.Utils;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteMueble
{
	public class BusTramiteMueble : IBusTramiteMueble
	{
		private readonly IDatDetalleAlta _repoAlta;
		private readonly IDatDetalleModificacion _repoModificacion;
		private readonly IDatDetalleBaja _repoBaja;
		private readonly IDatDetalleSolicitud _repoDetalleSolicitud;
		private readonly IDatBienPatrimonio _repoBienPatrimonio;
		private readonly IDatEtapaTramite _repoEtapaTramite;
		private readonly IDatSolicitud _repoSolicitud;
		private readonly IDatSeguimiento _repoSeguimiento;
		private readonly IDatHistorial _repoHistorial;
		private readonly IDatFamilia _repoFamilia;
		private readonly IDatSubfamilia _repoSubfamilia;
		private readonly IDatMarca _repoMarca;
		private readonly IDatBms _repoBms;
		private readonly IDatPeriodo _repoPeriodo;
		private readonly IDatUnidadAdministrativa _repoUnidadAdministrativa;
		private readonly IDatTipoAdquisicion _repoTipoAdquisicion;
		private readonly IDatEstadoFisico _repoEstadoFisico;
		private readonly IDatColor _repoColor;
		private readonly IDatUbicacion _repoUbicacion;
		private readonly IDatMunicipio _repoMunicipio;
		private readonly IDatCaracteristicaBien _repoCaracteristicaBien;
		private readonly IDatResguardante _repoResguardante;
		private readonly IDatDocumento _repoDocumento;
		private readonly IBusIdentityAccess _servicioAcceso;
		private readonly IMapper _mapper;
		private readonly IValidator<EntDetalleAltaMuebleRequest> _validatorAlta;
		private readonly IValidator<EntDetalleModificacionMuebleRequest> _validatorModificacion;
		private readonly IValidator<EntDetalleBajaMuebleRequest> _validatorBaja;
		private readonly IValidator<EntDetalleDesincorporacionMuebleRequest> _validatorDesincorporacion;
		private readonly ILogger<BusTramiteMueble> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		public BusTramiteMueble(IDatDetalleAlta repoAlta, IDatEtapaTramite repoEtapaTramite, IDatDetalleSolicitud repoDetalleSolicitud, IDatSolicitud repoSolicitud, IDatSeguimiento repoSeguimiento, IDatHistorial repoHistorial, IDatFamilia repoFamilia, IDatSubfamilia repoSubfamilia, IDatMarca repoMarca, IDatBms repoBms, IDatPeriodo repoPeriodo, IDatUnidadAdministrativa repoUnidadAdministrativa, IDatTipoAdquisicion repoTipoAdquisicion, IDatEstadoFisico repoEstadoFisico, IDatColor repoColor, IDatUbicacion repoUbicacion, IDatMunicipio repoMunicipio, IDatCaracteristicaBien repoCaracteristicaBien, IDatResguardante repoResguardante, IMapper mapper, IValidator<EntDetalleAltaMuebleRequest> validatorAlta, ILogger<BusTramiteMueble> logger, IDatBienPatrimonio repoBienPatrimonio, IDatDetalleModificacion repoModificacion, IValidator<EntDetalleModificacionMuebleRequest> validatorModificacion, IDatDetalleBaja repoBaja, IValidator<EntDetalleBajaMuebleRequest> validatorBaja, IDatDocumento repoDocumento, IValidator<EntDetalleDesincorporacionMuebleRequest> validatorDesincorporacion, IBusIdentityAccess servicioAcceso)
		{
			_repoAlta = repoAlta;
			_repoEtapaTramite = repoEtapaTramite;
			_repoDetalleSolicitud = repoDetalleSolicitud;
			_repoSolicitud = repoSolicitud;
			_repoSeguimiento = repoSeguimiento;
			_repoHistorial = repoHistorial;
			_repoFamilia = repoFamilia;
			_repoSubfamilia = repoSubfamilia;
			_repoMarca = repoMarca;
			_repoBms = repoBms;
			_repoPeriodo = repoPeriodo;
			_repoUnidadAdministrativa = repoUnidadAdministrativa;
			_repoTipoAdquisicion = repoTipoAdquisicion;
			_repoEstadoFisico = repoEstadoFisico;
			_repoColor = repoColor;
			_repoUbicacion = repoUbicacion;
			_repoMunicipio = repoMunicipio;
			_repoCaracteristicaBien = repoCaracteristicaBien;
			_repoResguardante = repoResguardante;
			_mapper = mapper;
			_validatorAlta = validatorAlta;
			_logger = logger;
			_repoBienPatrimonio = repoBienPatrimonio;
			_repoModificacion = repoModificacion;
			_validatorModificacion = validatorModificacion;
			_repoBaja = repoBaja;
			_validatorBaja = validatorBaja;
			_repoDocumento = repoDocumento;
			_validatorDesincorporacion = validatorDesincorporacion;
			_servicioAcceso = servicioAcceso;
		}

		private async Task<bool> BEsTramiteDonacion(long idSolicitud)
		{
			var solicitud = await _repoSolicitud.DObtenerRegistroAsync(e => e.iIdSolicitud == idSolicitud);
			var idMotivoTramite = solicitud.iIdMotivoTramite;
			return idMotivoTramite == 9 || idMotivoTramite == 32 || idMotivoTramite == 57;
		}

		private async Task BCompletarDatosTramiteAltaAsync(EntDetalleAltaMuebleRequest request, EntDetalleAlta entidad, EntUnidadAdministrativa unidadAdministrativa, EntFamilia familia, EntSubfamilia subfamilia, EntBms bms)
		{
			var periodo = await _repoPeriodo.DObtenerRegistroAsync(e => e.bActivo);
			var idPeriodo = periodo.iIdPeriodo;
			var bmsPartida = bms.sPartidas.Split(',')
				.FirstOrDefault(partida => partida.StartsWith("5"));
			var esDonacion = await BEsTramiteDonacion(request.IdSolicitud.Value);

			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
			entidad.sPartidaEspecifica = $"{EntConstant.DefaultPartida}.{familia.iIdFamilia}.{subfamilia.iIdSubfamilia}0.{bmsPartida}";
			entidad.sCuentaActivo = $"{EntPlanCuenta.CuentaNo_124}.{familia.iNumeroCuenta}.{subfamilia.iNumeroCuenta}.{idPeriodo}.{unidadAdministrativa.sNivelCompleto}.{EntConstant.DefaultFuenteFinanciamiento}";
			entidad.sCuentaActualizacion = esDonacion ? EntPlanCuenta.CuentaNo_3121 : entidad.sCuentaActivo;
		}

		private void BValidarRequestAlta(EntDetalleAltaMuebleRequest request)
		{
			var resultadoValidacion = _validatorAlta.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		private async Task BValidarRequestAltaBDAsync(EntDetalleAltaMuebleRequest request, EntDetalleAlta entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var familia = await _repoFamilia.DObtenerRegistroAsync(request.IdFamilia.Value);
			var existeFamilia = familia != null;
			var subFamilia = await _repoSubfamilia.DObtenerRegistroAsync(request.IdSubfamilia.Value);
			var existeSubFamilia = familia != null;
			var perteneceSubFamiliaAFamilia = existeFamilia && existeSubFamilia && subFamilia.iIdFamilia == familia.iIdFamilia;
			var bms = await _repoBms.DObtenerRegistroAsync(request.IdBms.Value);
			var existeBms = bms != null;
			var perteneceBmsASubFamilia = existeSubFamilia && bms.iIdSubfamilia == subFamilia.iIdSubfamilia;
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
			var existeUnidadAdministrativa = unidadAdministrativa != null;
			var existeRequisicion = await _repoTipoAdquisicion.DExisteRegistroAsync(e => e.iIdTipoAdquisicion == request.IdTipoAdquisicion);
			var existeEstadoFisico = !request.IdMarca.HasValue ||
				await _repoMarca.DExisteRegistroAsync(e => e.iIdMarca == request.IdMarca);
			var existeColor = !request.IdColor.HasValue ||
				await _repoColor.DExisteRegistroAsync(e => e.iIdColor == request.IdColor);
			var existeUbicacion = await _repoUbicacion.DExisteRegistroAsync(e => e.iIdUbicacion == request.IdUbicacion);
			var existeMunicipio = await _repoMunicipio.DExisteRegistroAsync(e => e.iIdMunicipio == request.IdMunicipio);
			var idsCaracteristicas = BusTransformarUtils.UObjetosToIDs(request.Caracteristicas);
			var existenCaracteristiasBien = await _repoCaracteristicaBien.DExistenRegistrosAsync(idsCaracteristicas, e => e.iIdCaracteristicaBien);
			var idsResponsables = request.Responsables.Split(',', StringSplitOptions.RemoveEmptyEntries)
							.Select(x => long.Parse(x))
							.ToList();
			
			var existenResguardantes = await _repoResguardante.DExistenRegistrosAsync(idsResponsables, e => e.iIdResguardante);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existeFamilia) errores.Append("La Familia no se encuentra registrada,");
			if (!existeSubFamilia) errores.Append("La Subfamilia no se encuentra registrada,");
			if (!perteneceSubFamiliaAFamilia) errores.Append("La Subfamilia no pertenece a la Familia,");
			if (!existeBms) errores.Append("El BMS no se encuentra registrado,");
			if (!perteneceBmsASubFamilia) errores.Append("El BMS no pertenece a la Familia y Subfamilia, ");
			if (!existeUnidadAdministrativa) errores.Append("El Centro de Costo no se encuentra registrado,");
			if (!existeRequisicion) errores.Append("La Requisicion no se encuentra registrada,");
			if (!existeEstadoFisico) errores.Append("El Estado Fisico no se encuentra registrado,");
			if (!existeColor) errores.Append("El Color no se encuentra registrado,");
			if (!existeUbicacion) errores.Append("La Ubicacion no se encuentra registrada,");
			if (!existeMunicipio) errores.Append("El Municipio no se encuentra registrado,");
			if (!existenCaracteristiasBien) errores.Append("Algunas Caracteristicas no se encuentran registradas,");
			if (!existenResguardantes) errores.Append("Algunos Responsables no se encuentran registrados,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteAltaAsync(request, entidad, unidadAdministrativa, familia, subFamilia, bms);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>> BObtenerTramitesPorSolicitudAsync(long idSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramitesPorSolicitudAsync);
			var resultado = new EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las solicitudes de bienes muebles");
			try
			{
				Expression<Func<EntDetalleSolicitud, bool>> filtro = e =>e.iIdSolicitud == idSolicitud;
				var resultListDto = await _repoDetalleSolicitud.DObtenerProyeccionListaAsync<EntDetalleSolicitudResponse>(filtro);
				resultado.Success(resultListDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntDetalleSolicitudResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todas las solicitudes de bienes muebles"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<IEnumerable<EntSeguimientoResponse>>> BObtenerSeguimientoTramiteAsync(long idDetalleSolicitud)
		{

			var nombreMetodo = nameof(BObtenerSeguimientoTramiteAsync);
			var resultado = new EntityResponse<IEnumerable<EntSeguimientoResponse>>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar todas las solicitudes de bienes muebles");
			try
			{
				var resultListDto = await _repoSeguimiento.DObtenerProyeccionListaAsync<EntSeguimientoResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud);
				resultado.Success(resultListDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<IEnumerable<EntSeguimientoResponse>>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar todas las solicitudes de bienes muebles"
				);
			}

			return resultado;
		}

		private bool BDepreciaBien(long idSubfamilia, decimal precioUnitario)
		{
			return idSubfamilia != EntConstant.MuebleNoDeprecia && 
				precioUnitario != EntConstant.PrecioNoDeprecia;
		}

		private EntBienPatrimonio BGenerarBienMueble(EntDetalleSolicitud detalleSolicitud)
		{
			var detalleAlta = detalleSolicitud.DetalleAlta;
			return new EntBienPatrimonio
			{
				iIdSolicitud = detalleSolicitud.iIdSolicitud,
				iIdPeriodo = detalleSolicitud.Solicitud.iIdPeriodo,
				iIdTipoBien = detalleAlta.iIdTipoBien,
				iIdFamilia = detalleAlta.iIdFamilia,
				iIdSubfamilia = detalleAlta.iIdSubfamilia,
				iIdBms = detalleAlta.iIdBms.Value,
				sReferenciaConac = detalleAlta.sReferenciaConac,
				sPartidaEspecifica = detalleAlta.sPartidaEspecifica,
				sCuentaActivo = detalleAlta.sCuentaActivo,
				sCuentaActualizacion = detalleAlta.sCuentaActualizacion,
				sDescripcion = detalleAlta.sDescripcion,
				iIdUnidadAdministrativa = detalleAlta.iIdUnidadAdministrativa,
				sRequisicion = detalleAlta.sRequisicion,
				sOrdenCompra = detalleAlta.sOrdenCompra,
				iIdTipoAdquisicion = detalleAlta.iIdTipoAdquisicion,
				sNoSeries = detalleAlta.sNoSeries,
				sFolioAnterior = detalleAlta.sFolioAnterior,
				iIdEstadoFisico = detalleAlta.iIdEstadoFisico,
				Licitacion = new()
				{
					iNumeroLicitacion = detalleAlta.Licitacion.iNumeroLicitacion,
					dtFecha = detalleAlta.Licitacion.dtFecha,
					sObservaciones = detalleAlta.Licitacion.sObservaciones
				},
				DatoGeneral = new ()
				{
					iIdColor = detalleAlta.DatoGeneral.iIdColor,
					iIdMarca = detalleAlta.DatoGeneral.iIdMarca
				},
				Factura = new()
				{
					iGarantiaDias = detalleAlta.Factura.iGarantiaDias,
					dtFecha = detalleAlta.Factura.dtFecha,
					sFolioFactura = detalleAlta.Factura.sFolioFactura,
				},
				dPrecioUnitario = detalleAlta.dPrecioUnitario,
				dtFechaAdquisicion = detalleAlta.dtFechaAdquisicion,
				iAniosVida = detalleAlta.iAniosVida,
				dtFechaInicioUso = detalleAlta.dtFechaInicioUso,
				dPrecioDesechable = detalleAlta.dPrecioDesechable,
				sObservacionBien = detalleAlta.sObservacionBien,
				iIdUbicacion = detalleAlta.iIdUbicacion.Value,
				iIdMunicipio = detalleAlta.iIdMunicipio.Value,
				sCaracteristicas = detalleAlta.sCaracteristicas,
				sResguardantes = detalleAlta.sResguardantes,
				sObservacionResponsable = detalleAlta.sObservacionResponsable,
				dtFechaAlta = DateTime.Now.Date,
				bActivo = true,
				bDeprecia = BDepreciaBien(detalleAlta.iIdSubfamilia, detalleAlta.dPrecioUnitario)
			};
		}

		private EntHistorial BGenerarHistorial(EntBienPatrimonio bienMueble, EntDetalleSolicitud detalle)
		{
			var idUsuario = _servicioAcceso.BObtenerIdUsuario();
			return new EntHistorial()
			{
				iIdBien = bienMueble.iIdBien,
				iIdSolicitud = detalle.iIdSolicitud,
				iIdModulo = (long)EnumModulo.SistemaIntegralDePatrimonio,
				iIdSubModulo = (long)EnumSubModulo.AdministradorCedulasBienesMuebles,
				iIdUsuario = idUsuario
			};
		}

		private EntSeguimiento BGenerarSeguimiento(EntDetalleSolicitud detalleSolicitud, long idEtapa)
		{
			var idUsuario = _servicioAcceso.BObtenerIdUsuario();
			return new EntSeguimiento()
			{
				iIdDetalleSolicitud = detalleSolicitud.iIdDetalleSolicitud,
				iIdEtapa = idEtapa,
				dtFechaHora = DateTime.Now,
				iIdModulo = (long)EnumModulo.SistemaIntegralDePatrimonio,
				iIdSubModulo = (long)EnumSubModulo.AdministradorCedulasBienesMuebles,
				iIdUsuario = idUsuario
			};
		}

		private async Task BAplicarVOBOAsync(EntDetalleSolicitud detalleSolicitud)
		{

			if (detalleSolicitud.DetalleAlta != null)
			{
				var detalleAlta = detalleSolicitud.DetalleAlta;
				if (string.IsNullOrEmpty(detalleAlta.sResguardantes))
					throw new BusConflictoException("No se puede cambiar la etapa a VOBO hasta que se le asigne al menos un reguardante al tramite.");

				var bienMueble = BGenerarBienMueble(detalleSolicitud);
				await _repoBienPatrimonio.DCrearAsync(bienMueble);

				var folioBien = BusTransformarUtils.UGenerarFolioBien(BusTransformarUtils.PrefijoMueble, bienMueble.iIdBien);
				bienMueble.sFolioBien = folioBien;
				await _repoBienPatrimonio.DActualizarAsync(bienMueble);

				detalleAlta.sFolioBien = folioBien;
				await _repoAlta.DActualizarAsync(detalleAlta);

				var historial = BGenerarHistorial(bienMueble, detalleSolicitud);
				await _repoHistorial.DCrearAsync(historial);
			}
			else if (detalleSolicitud.DetalleBaja != null)
			{
				var detalleBaja = detalleSolicitud.DetalleBaja.Baja;
				var foliosBien = detalleBaja.sFolioBien;
				var listFoliosBien = foliosBien.Split(",");
				var detalles = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => listFoliosBien.Contains(e.sFolioBien), desactivarTracking: false);

				foreach (var detalle in detalles)
				{
					detalle.bActivo = false;
					detalle.bDeprecia = false;
					detalle.bEnProceso = false;
					detalle.dtFechaBaja = DateTime.Now;
					detalle.sMotivoBaja = detalleBaja.sObservaciones;
					await _repoBienPatrimonio.DActualizarAsync(detalle);

					var historial = BGenerarHistorial(detalle, detalleSolicitud);
					await _repoHistorial.DCrearAsync(historial);
				}

			}
			else if (detalleSolicitud.DetalleMovimiento != null)
			{
				var idMotivoTramite = detalleSolicitud.Solicitud.iIdMotivoTramite;
				var movimiento = detalleSolicitud.DetalleMovimiento;
				var foliosBien = movimiento.sFolioBien;
				var listFoliosBien = foliosBien.Split(",");
				var detalles = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => listFoliosBien.Contains(e.sFolioBien), desactivarTracking: false);

				foreach (var detalle in detalles)
				{
					if (idMotivoTramite == (long)EnumMotivoTramite.TransferenciaDeBienesMuebles || idMotivoTramite == (long)EnumMotivoTramite.CambioDeCentroDeCostos)
					{
						detalle.iIdUnidadAdministrativa = movimiento.iIdNuevaUnidadAdministrativa.Value;
					}
					else if (idMotivoTramite == (long)EnumMotivoTramite.CambioDeResguardosDeMobiliarioYEquipo)
					{
						detalle.sResguardantes = movimiento.sResponsable;
					}
					detalle.bEnProceso = false;
					detalle.iIdMunicipio = movimiento.iIdMunicipio;
					detalle.iIdUbicacion = movimiento.iIdUbicacion.Value;

					await _repoBienPatrimonio.DActualizarAsync(detalle);
					var historial = BGenerarHistorial(detalle, detalleSolicitud);
					await _repoHistorial.DCrearAsync(historial);
				}

			}
			else if (detalleSolicitud.DetalleDesincorporacion != null)
			{
				var desincorporacion = detalleSolicitud.DetalleDesincorporacion;
				var foliosBien = desincorporacion.sFolioBien;
				var listFoliosBien = foliosBien.Split(",");
				var detalles = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => listFoliosBien.Contains(e.sFolioBien), desactivarTracking: false);

				foreach (var detalle in detalles)
				{
					detalle.bActivo = false;
					detalle.bDeprecia = false;
					detalle.bEnProceso = false;
					detalle.dtFechaBaja = DateTime.Now;
					detalle.sMotivoBaja = desincorporacion.sObservaciones;
					await _repoBienPatrimonio.DActualizarAsync(detalle);
					var historial = BGenerarHistorial(detalle, detalleSolicitud);
					await _repoHistorial.DCrearAsync(historial);
				}
			}
			else if (detalleSolicitud.DetalleDestinoFinal != null)
			{
				var tramiteActualizado = detalleSolicitud.DetalleDestinoFinal;
				var foliosBien = tramiteActualizado.sFolioBien;
				var listFoliosBien = foliosBien.Split(",");
				var detalles = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => listFoliosBien.Contains(e.sFolioBien), desactivarTracking: false);

				foreach (var detalle in detalles)
				{
					detalle.bActivo = false;
					detalle.bDeprecia = false;
					detalle.bEnProceso = false;
					detalle.dtFechaBaja = DateTime.Now;
					detalle.sMotivoBaja = detalleSolicitud.Solicitud.iIdMotivoTramite == (long)EnumMotivoTramite.Destruccion
						? tramiteActualizado.DetalleDestruccion.sDescripcion
						: tramiteActualizado.DetalleEnagenacion.sDescripcion;
					await _repoBienPatrimonio.DActualizarAsync(detalle);
					var historial = BGenerarHistorial(detalle, detalleSolicitud);
					await _repoHistorial.DCrearAsync(historial);
				}
			}
			else if (detalleSolicitud.DetalleModificacion != null)
			{
				var idMotivoTramite = detalleSolicitud.Solicitud.iIdMotivoTramite;
				var tramiteActualizado = detalleSolicitud.DetalleModificacion;
				var foliosBien = tramiteActualizado.sFolioBien;
				var incluir = new List<Expression<Func<EntBienPatrimonio, object>>>()
				{
					e => e.Factura,
					e => e.DatoGeneral,
					e => e.Licitacion
				};
				var tramiteOriginal = await _repoBienPatrimonio.DObtenerRegistroAsync(incluir: incluir, predicado: e => e.sFolioBien == foliosBien, desactivarTracking: false);

				if (idMotivoTramite == (long)EnumMotivoTramite.ModificacionDeDatosDeFactura)
				{
					var facturaActualizada = tramiteActualizado.Factura;
					var facturaOriginal = tramiteOriginal.Factura;
					facturaOriginal.sFolioFactura = facturaActualizada.sFolioFactura;
					facturaOriginal.dtFecha = facturaActualizada.dtFecha;
					facturaOriginal.iGarantiaDias = facturaActualizada.iGarantiaDias;

					tramiteOriginal.dPrecioUnitario = tramiteActualizado.dPrecioUnitario;
					tramiteOriginal.iAniosVida = tramiteActualizado.iAniosVida;
					tramiteOriginal.dtFechaInicioUso = tramiteActualizado.dtFechaInicioUso;
					tramiteOriginal.dPrecioDesechable = tramiteActualizado.dPrecioDesechable;
					tramiteOriginal.dtFechaAdquisicion = tramiteActualizado.dtFechaAdquisicion;
					tramiteOriginal.bDeprecia = BDepreciaBien(tramiteOriginal.iIdSubfamilia, tramiteOriginal.dPrecioUnitario);

				}
				else if (idMotivoTramite == (long)EnumMotivoTramite.ModificacionDeDatosDeMobiliarioYEquipo)
				{
					tramiteOriginal.sDescripcion = tramiteActualizado.sDescripcion;
					tramiteOriginal.sRequisicion = tramiteActualizado.sRequisicion;
					tramiteOriginal.sOrdenCompra = tramiteActualizado.sOrdenCompra;
					tramiteOriginal.iIdTipoAdquisicion = tramiteActualizado.iIdTipoAdquisicion;
					tramiteOriginal.sNoSeries = tramiteActualizado.sNoSeries;
					tramiteOriginal.sFolioAnterior = tramiteActualizado.sFolioAnterior;
					tramiteOriginal.iIdEstadoFisico = tramiteActualizado.iIdEstadoFisico;
					tramiteOriginal.sObservacionBien = tramiteActualizado.sObservacionBien;
					tramiteOriginal.iIdUbicacion = tramiteActualizado.iIdUbicacion;
					tramiteOriginal.iIdMunicipio = tramiteActualizado.iIdMunicipio;
					tramiteOriginal.sCaracteristicas = tramiteActualizado.sCaracteristicas;
					tramiteOriginal.sObservacionResponsable = tramiteActualizado.sObservacionResponsable;

					var licitacionActualizada = tramiteActualizado.Licitacion;
					var licitacionOriginal = tramiteOriginal.Licitacion;
					licitacionOriginal.iNumeroLicitacion = licitacionActualizada.iNumeroLicitacion;
					licitacionOriginal.dtFecha = licitacionActualizada.dtFecha;
					licitacionOriginal.sObservaciones = licitacionActualizada.sObservaciones;

					var datoGeneralActualizado = tramiteActualizado.DatoGeneral;
					var datoGeneralOriginal = tramiteOriginal.DatoGeneral;
					datoGeneralOriginal.iIdMarca = datoGeneralActualizado.iIdMarca;
					datoGeneralOriginal.iIdColor = datoGeneralActualizado.iIdColor;
				}
				tramiteOriginal.bEnProceso = false;
				await _repoBienPatrimonio.DActualizarAsync(tramiteOriginal);
				var historial = BGenerarHistorial(tramiteOriginal, detalleSolicitud);
				await _repoHistorial.DCrearAsync(historial);
			}
		}

		private async Task BAplicarRechazadoAsync(EntDetalleSolicitud detalleSolicitud)
		{
			if (detalleSolicitud.DetalleAlta != null) return;
			var foliosBien = detalleSolicitud.DetalleModificacion != null
				? detalleSolicitud.DetalleModificacion.sFolioBien
				: detalleSolicitud.DetalleBaja != null
					? detalleSolicitud.DetalleBaja.Baja.sFolioBien
					: detalleSolicitud.DetalleMovimiento != null
						? detalleSolicitud.DetalleMovimiento.sFolioBien
						: detalleSolicitud.DetalleDesincorporacion != null
							? detalleSolicitud.DetalleDesincorporacion.sFolioBien
							: detalleSolicitud.DetalleDestinoFinal != null
								? detalleSolicitud.DetalleDestinoFinal.sFolioBien
								: "";
			var listFoliosBien = foliosBien.Split(",");
			var bienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => listFoliosBien.Contains(e.sFolioBien), desactivarTracking: false);
			foreach (var bien in bienes)
			{
				bien.bEnProceso = false;
				await _repoBienPatrimonio.DActualizarAsync(bien);
			}
		}

		public async Task<EntityResponse<int>> BCambiarEtapaTramiteAsync(long idDetalleSolicitud, long? idEtapa)
		{
			var nombreMetodo = nameof(BCambiarEtapaTramiteAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para cambiar la etapa de tramite de bienes muebles");
			try
			{

				if (!idEtapa.HasValue)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Etapa a la que quiere cambiar es requerida");

				var incluir = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleAlta.Factura,
					e => e.DetalleAlta.DatoGeneral,
					e => e.DetalleAlta.Licitacion,
					e => e.DetalleBaja.Baja,
					e => e.DetalleDesincorporacion,
					e => e.DetalleDestinoFinal.DetalleDestruccion,
					e => e.DetalleDestinoFinal.DetalleEnagenacion,
					e => e.DetalleModificacion.Factura,
					e => e.DetalleModificacion.Licitacion,
					e => e.DetalleModificacion.DatoGeneral,
					e => e.DetalleMovimiento,
					e => e.Solicitud
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(e=> e.iIdDetalleSolicitud == idDetalleSolicitud, incluir: incluir)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				var etapaSiguienteCorrecta = await _repoEtapaTramite.DValidarCambioEtapaAsync(detalleSolicitud, idEtapa.Value);

				if (!etapaSiguienteCorrecta)
					throw new BusConflictoException("No se permite avanzar a esta etapa desde la etapa actual.");

				var resultCambioEtapa = await _repoDetalleSolicitud.DCambiarEtapaAsync(detalleSolicitud.iIdDetalleSolicitud, idEtapa.Value);
				var segumiento = BGenerarSeguimiento(detalleSolicitud, idEtapa.Value);
				var resultSegumiento = await _repoSeguimiento.DCrearAsync(segumiento);

				if (idEtapa.Value == (long)EnumEtapa.VOBO)
					await BAplicarVOBOAsync(detalleSolicitud);

				else if (idEtapa.Value == (long)EnumEtapa.Rechazo)
					await BAplicarRechazadoAsync(detalleSolicitud);
				
				await transaction.CommitAsync();
				resultado.Success(resultCambioEtapa + resultSegumiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear la solicitud de bienes muebles"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteAltaAsync(long idDetalleSolicitud, EntDetalleAltaMuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de alta de un bien mueble");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleAlta,
					e => e.DetalleAlta.Licitacion,
					e => e.DetalleAlta.DatoGeneral,
					e => e.DetalleAlta.Factura
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(
					predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud, 
					incluir: includes, 
					desactivarTracking: false
				) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (detalleSolicitud.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("No se puede modificar el trámite en la etapa actual.");

				var detalleAlta = detalleSolicitud.DetalleAlta;
				BValidarRequestAlta(request);
				await BValidarRequestAltaBDAsync(request, detalleAlta);

				detalleAlta.iNumeroBienes = request.NumeroBienes.Value;
				detalleAlta.iIdFamilia = request.IdFamilia.Value;
				detalleAlta.iIdSubfamilia = request.IdSubfamilia.Value;
				detalleAlta.iIdBms = request.IdBms.Value;
				detalleAlta.sDescripcion = request.Descripcion;
				detalleAlta.sRequisicion = request.Requisicion;
				detalleAlta.sOrdenCompra = request.OrdenCompra;
				detalleAlta.iIdTipoAdquisicion = request.IdTipoAdquisicion.Value;
				detalleAlta.sNoSeries = request.NoSeries;
				detalleAlta.sFolioAnterior = request.FolioAnterior;
				detalleAlta.iIdEstadoFisico = request.IdEstadoFisico.Value;
				detalleAlta.dPrecioUnitario = request.PrecioUnitario.Value;
				detalleAlta.dtFechaAdquisicion = request.FechaCompra.Value;
				detalleAlta.iAniosVida = request.VidaUtil.Value;
				detalleAlta.dtFechaInicioUso = request.FechaInicioUso.Value;
				detalleAlta.dPrecioDesechable = request.PrecioDesechable.Value;
				detalleAlta.sObservacionBien = request.ObservacionBien;
				detalleAlta.iIdUbicacion = request.IdUbicacion.Value;
				detalleAlta.iIdMunicipio = request.IdMunicipio.Value;
				detalleAlta.sCaracteristicas = request.Caracteristicas;
				detalleAlta.sResguardantes = request.Responsables;
				detalleAlta.sObservacionResponsable = request.ObservacionResponsable;

				var licitacion = detalleAlta.Licitacion;
				licitacion.iNumeroLicitacion = request.NoLicitacion;
				licitacion.dtFecha = request.FechaLicitacion;
				licitacion.sObservaciones = request.ObservacionLicitacion;

				var datoGeneral = detalleAlta.DatoGeneral;
				datoGeneral.iIdMarca = request.IdMarca;
				datoGeneral.iIdColor = request.IdColor;

				var factura = detalleAlta.Factura;
				factura.sFolioFactura = request.FolioFactura;
				factura.dtFecha = request.FechaFactura.Value;
				factura.iGarantiaDias = request.DiasGarantia;

				var result = await _repoDetalleSolicitud.DActualizarAsync(detalleSolicitud);
				await transaction.CommitAsync();
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el tramite de alta de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearTramiteAltaAsync(EntDetalleAltaMuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de alta de un bien mueble");
			try
			{
				BValidarRequestAlta(request);
				var detalleSolicitud = _mapper.Map<EntDetalleSolicitud>(request);
				await BValidarRequestAltaBDAsync(request, detalleSolicitud.DetalleAlta);

				var result = await _repoDetalleSolicitud.DCrearAsync(detalleSolicitud);
				var seguimiento = BGenerarSeguimiento(detalleSolicitud, detalleSolicitud.iIdEtapa);
				var resultadoSeguimiento = await _repoSeguimiento.DCrearAsync(seguimiento);
				await transaction.CommitAsync();
				resultado.Success(result + resultadoSeguimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el tramite de alta de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleAltaMuebleResponse>> BObtenerTramiteAltaAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteAltaAsync);
			var resultado = new EntityResponse<EntDetalleAltaMuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de alta");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleAltaMuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleAltaMuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de alta"
				);
			}

			return resultado;
		}

		private async Task BCambiarEstadoBienes(string folioBienActual, string folioBienNuevo)
		{
			var foliosBienesActuales = string.IsNullOrWhiteSpace(folioBienActual)
				? Array.Empty<string>()
				: folioBienActual.Split(",", StringSplitOptions.RemoveEmptyEntries);

			var foliosBienesNuevos = string.IsNullOrWhiteSpace(folioBienNuevo)
				? Array.Empty<string>()
				: folioBienNuevo.Split(",", StringSplitOptions.RemoveEmptyEntries);

			var todosFolios = foliosBienesActuales.Concat(foliosBienesNuevos).Distinct().ToArray();
			var todosBienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => todosFolios.Contains(e.sFolioBien));

			foreach (var bien in todosBienes)
			{
				bien.bEnProceso = foliosBienesNuevos.Contains(bien.sFolioBien);
					await _repoBienPatrimonio.DActualizarAsync(bien);
			}
		}

		private void BValidarRequestModificacion(EntDetalleModificacionMuebleRequest request)
		{
			var resultadoValidacion = _validatorModificacion.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}


		private async Task BCompletarDatosTramiteModificacionAsync(EntDetalleModificacionMuebleRequest request, EntDetalleModificacion entidad, EntBienPatrimonio bien, EntUnidadAdministrativa unidadAdministrativa)
		{
			await BCambiarEstadoBienes(entidad.sFolioBien, bien.sFolioBien);
			entidad.sFolioBien = bien.sFolioBien;
			entidad.iIdFamilia = bien.iIdFamilia;
			entidad.iIdSubfamilia = bien.iIdSubfamilia;
			entidad.iIdBms = bien.iIdBms.Value;
			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
			entidad.iIdCentroCosto = bien.iIdUnidadAdministrativa;
			entidad.sPartidaEspecifica = bien.sPartidaEspecifica;
			entidad.sCuentaActivo = bien.sCuentaActivo;
			entidad.sCuentaActualizacion = bien.sCuentaActualizacion;
			entidad.sResguardantes = bien.sResguardantes;
		}

		private async Task BValidarRequestModificacionBDAsync(EntDetalleModificacionMuebleRequest request, EntDetalleModificacion entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var bienPatrimonio = await _repoBienPatrimonio.DObtenerRegistroAsync(e => e.iIdBien == request.IdBienPatrimonio);
			var existeBienPatrimonio = bienPatrimonio != null;
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
			var existeUnidadAdministrativa = unidadAdministrativa != null;
			var existeRequisicion = await _repoTipoAdquisicion.DExisteRegistroAsync(e => e.iIdTipoAdquisicion == request.IdTipoAdquisicion);
			var existeEstadoFisico = !request.IdMarca.HasValue ||
				await _repoMarca.DExisteRegistroAsync(e => e.iIdMarca == request.IdMarca);
			var existeColor = !request.IdColor.HasValue ||
				await _repoColor.DExisteRegistroAsync(e => e.iIdColor == request.IdColor);
			var existeUbicacion = await _repoUbicacion.DExisteRegistroAsync(e => e.iIdUbicacion == request.IdUbicacion);
			var existeMunicipio = await _repoMunicipio.DExisteRegistroAsync(e => e.iIdMunicipio == request.IdMunicipio);
			var idsCaracteristicas = BusTransformarUtils.UObjetosToIDs(request.Caracteristicas);
			var existenCaracteristiasBien = await _repoCaracteristicaBien.DExistenRegistrosAsync(idsCaracteristicas, e => e.iIdCaracteristicaBien);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existeBienPatrimonio) errores.Append("El Bien Patrimonio no se encuentra registrado,");
			if (!existeUnidadAdministrativa) errores.Append("El Centro de Costo no se encuentra registrado,");
			if (!existeRequisicion) errores.Append("La Requisicion no se encuentra registrada,");
			if (!existeEstadoFisico) errores.Append("El Estado Fisico no se encuentra registrado,");
			if (!existeColor) errores.Append("El Color no se encuentra registrado,");
			if (!existeUbicacion) errores.Append("La Ubicacion no se encuentra registrada,");
			if (!existeMunicipio) errores.Append("El Municipio no se encuentra registrado,");
			if (!existenCaracteristiasBien) errores.Append("Algunas Caracteristicas no se encuentran registradas,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteModificacionAsync(request, entidad,bienPatrimonio, unidadAdministrativa);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BCrearTramiteModificacionAsync(EntDetalleModificacionMuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de modificacion de un bien mueble");
			try
			{
				BValidarRequestModificacion(request);
				var detalleSolicitud = _mapper.Map<EntDetalleModificacionMuebleRequest, EntDetalleSolicitud>(request);
				await BValidarRequestModificacionBDAsync(request, detalleSolicitud.DetalleModificacion);

				var result = await _repoDetalleSolicitud.DCrearAsync(detalleSolicitud);
				var seguimiento = BGenerarSeguimiento(detalleSolicitud, detalleSolicitud.iIdEtapa);
				var resultadoSeguimiento = await _repoSeguimiento.DCrearAsync(seguimiento);
				await transaction.CommitAsync();
				resultado.Success(result + resultadoSeguimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el tramite de modificacion de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteModificacionAsync(long idDetalleSolicitud, EntDetalleModificacionMuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de modificacion de un bien mueble");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleModificacion,
					e => e.DetalleModificacion.Licitacion,
					e => e.DetalleModificacion.DatoGeneral,
					e => e.DetalleModificacion.Factura
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(
					predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud,
					incluir: includes,
					desactivarTracking: false
				) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (detalleSolicitud.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("No se puede modificar el trámite en la etapa actual.");

				var detalleModificacion = detalleSolicitud.DetalleModificacion;
				BValidarRequestModificacion(request);
				await BValidarRequestModificacionBDAsync(request, detalleModificacion);
				if (request.IdMotivoTramite == (long)EnumMotivoTramite.ModificacionDeDatosDeFactura)
				{
					var factura = detalleModificacion.Factura;
					factura.sFolioFactura = request.FolioFactura;
					factura.dtFecha = request.FechaFactura.Value;
					factura.iGarantiaDias = request.DiasGarantia;

					detalleModificacion.dPrecioUnitario = request.PrecioUnitario.Value;
					detalleModificacion.iAniosVida = request.VidaUtil.Value;
					detalleModificacion.dtFechaInicioUso = request.FechaInicioUso.Value;
					detalleModificacion.dPrecioDesechable = request.PrecioDesechable.Value;
					detalleModificacion.dtFechaAdquisicion = request.FechaCompra.Value;

				}
				else if (request.IdMotivoTramite == (long)EnumMotivoTramite.ModificacionDeDatosDeMobiliarioYEquipo)
				{
					detalleModificacion.sDescripcion = request.Descripcion;
					detalleModificacion.sRequisicion = request.Requisicion;
					detalleModificacion.sOrdenCompra = request.OrdenCompra;
					detalleModificacion.iIdTipoAdquisicion = request.IdTipoAdquisicion.Value;
					detalleModificacion.sNoSeries = request.NoSeries;
					detalleModificacion.sFolioAnterior = request.FolioAnterior;
					detalleModificacion.iIdEstadoFisico = request.IdEstadoFisico.Value;
					detalleModificacion.sObservacionBien = request.ObservacionBien;
					detalleModificacion.iIdUbicacion = request.IdUbicacion.Value;
					detalleModificacion.iIdMunicipio = request.IdMunicipio.Value;
					detalleModificacion.sCaracteristicas = request.Caracteristicas;
					detalleModificacion.sObservacionResponsable = request.ObservacionResponsable;

					var licitacion = detalleModificacion.Licitacion;
					licitacion.iNumeroLicitacion = request.NoLicitacion;
					licitacion.dtFecha = request.FechaLicitacion;
					licitacion.sObservaciones = request.ObservacionLicitacion;

					var datoGeneral = detalleModificacion.DatoGeneral;
					datoGeneral.iIdMarca = request.IdMarca;
					datoGeneral.iIdColor = request.IdColor;
				}

				var result = await _repoDetalleSolicitud.DActualizarAsync(detalleSolicitud);
				await transaction.CommitAsync();
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el tramite de alta de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleModificacionMuebleResponse>> BObtenerTramiteModificacionAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteAltaAsync);
			var resultado = new EntityResponse<EntDetalleModificacionMuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de modificacion");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleModificacionMuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleModificacionMuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de modificacion"
				);
			}

			return resultado;
		}

		private async Task BCompletarDatosTramiteBajaAsync(EntDetalleBajaMuebleRequest request, EntBaja entidad, EntUnidadAdministrativa unidadAdministrativa)
		{
			await BCambiarEstadoBienes(entidad.sFolioBien, request.FolioBien);
			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
		}

		private void BValidarRequestBaja(EntDetalleBajaMuebleRequest request)
		{
			var resultadoValidacion = _validatorBaja.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		private async Task BValidarRequestBajaBDAsync(EntDetalleBajaMuebleRequest request, EntBaja entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
			var existeUnidadAdministrativa = unidadAdministrativa != null;

			var foliosBienes = request.FolioBien.Split(",").ToArray();
			var bienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado:
				e => foliosBienes.Contains(e.sFolioBien));
			var existenTodosBienes = bienes.Count == foliosBienes.Count();

			var idsDocumentos = request.Documentos?.Split(',', StringSplitOptions.RemoveEmptyEntries)
				.Select(x => long.Parse(x))
				.ToList() ;

			var existenDocumentos = await _repoDocumento.DExistenRegistrosAsync(idsDocumentos, e => e.iIdDocumento);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existenTodosBienes) errores.Append("Algunos Bienes no existen en el inventario,");
			if (!existenDocumentos) errores.Append("Algunos Documentos no existen,");
			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteBajaAsync(request, entidad, unidadAdministrativa);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}


		public async Task<EntityResponse<int>> BCrearTramiteBajaAsync(EntDetalleBajaMuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de baja de un bien mueble");
			try
			{
				BValidarRequestBaja(request);
				var detalleSolicitud = _mapper.Map<EntDetalleBajaMuebleRequest, EntDetalleSolicitud>(request);
				await BValidarRequestBajaBDAsync(request, detalleSolicitud.DetalleBaja.Baja);

				var result = await _repoDetalleSolicitud.DCrearAsync(detalleSolicitud);
				var seguimiento = BGenerarSeguimiento(detalleSolicitud, detalleSolicitud.iIdEtapa);
				var resultadoSeguimiento = await _repoSeguimiento.DCrearAsync(seguimiento);
				await transaction.CommitAsync();
				resultado.Success(result + resultadoSeguimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el tramite de modificacion de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteBajaAsync(long idDetalleSolicitud, EntDetalleBajaMuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de baja");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleBaja.Baja
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(
					predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud,
					incluir: includes,
					desactivarTracking: false
				) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (detalleSolicitud.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("No se puede modificar el trámite en la etapa actual.");

				var detalleBaja = detalleSolicitud.DetalleBaja.Baja;
				BValidarRequestBaja(request);
				await BValidarRequestBajaBDAsync(request, detalleBaja);

				detalleBaja.sFolioBien = request.FolioBien;
				detalleBaja.sObservaciones = request.Observaciones;
				detalleBaja.sFolioDocumento = request.FolioDocumento;
				detalleBaja.dtFehaDocumento = request.FechaDocumento.Value;
				detalleBaja.sListaDocunetario = request.Documentos;
				detalleBaja.sNombreSolicitante = request.NombreSolicitante;
				detalleBaja.sLugarResguardo = request.LugarResguardo;
				var result = await _repoDetalleSolicitud.DActualizarAsync(detalleSolicitud);
				await transaction.CommitAsync();
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el tramite de baja"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleBajaMuebleResponse>> BObtenerTramiteBajaAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteAltaAsync);
			var resultado = new EntityResponse<EntDetalleBajaMuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de baja");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleBajaMuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleBajaMuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de baja"
				);
			}

			return resultado;
		}

		private bool BIgualCentroCosto(string version1, string version2)
		{
			string majorAndMinor1 = string.Join(".", version1.Split('.')[0], version1.Split('.')[1]);
			string majorAndMinor2 = string.Join(".", version2.Split('.')[0], version2.Split('.')[1]);
			return majorAndMinor1 == majorAndMinor2;
		}

		private async Task BCompletarDatosTramiteMoviemientoAsync(EntDetalleMovimientoMuebleRequest request, EntDetalleMovimiento entidad, EntUnidadAdministrativa unidadAdministrativa, EntUnidadAdministrativa nuevaUnidadAdministrativa)
		{
			await BCambiarEstadoBienes(entidad.sFolioBien, request.FolioBien);
			if (request.IdMotivoTramite == (long)EnumMotivoTramite.TransferenciaDeBienesMuebles || request.IdMotivoTramite == (long)EnumMotivoTramite.CambioDeCentroDeCostos)
			{
				entidad.iIdNuevaUnidadAdministrativa = nuevaUnidadAdministrativa.iIdUnidadAdministrativa;
			}
			else if (request.IdMotivoTramite == (long)EnumMotivoTramite.CambioDeResguardosDeMobiliarioYEquipo)
			{
				entidad.sResponsable = request.Responsable;
			}
			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
		}

		private void BValidarRequestMovimiento(EntDetalleMovimientoMuebleRequest request)
		{
			var errores =  new StringBuilder(string.Empty);

			if (request.IdSolicitud <= 0)
				errores.Append("La solicitud es requerida,");

			if (request.IdMunicipio <= 0)
				errores.Append("El municipio es requerido,");

			if (request.IdUbicacion <= 0)
				errores.Append("La ubicacion es requerida,");

			if (string.IsNullOrEmpty(request.FolioBien))
				errores.Append("El folio del bien es requerido,");

			if (request.IdMotivoTramite == (long)EnumMotivoTramite.CambioDeCentroDeCostos)
			{

				if (string.IsNullOrEmpty( request.NivelUnidadAdministrativa))
					errores.Append("El nivel de la nueva unidad administrativa es requerido,");


				if (string.IsNullOrEmpty(request.NivelNuevaUnidadAdministrativa))
					errores.Append("El nivel de la nueva unidad administrativa es requerido,");


				if (!BIgualCentroCosto(request.NivelUnidadAdministrativa, request.NivelNuevaUnidadAdministrativa))
					errores.Append("El nivel de la nueva unidad administrativa debe ser igual al nivel de la unidad administrativa,");

			} else if (request.IdMotivoTramite == (long)EnumMotivoTramite.TransferenciaDeBienesMuebles)
			{

				if (BIgualCentroCosto(request.NivelUnidadAdministrativa, request.NivelNuevaUnidadAdministrativa))
					errores.Append("El nivel de la nueva unidad administrativa debe ser diferente al nivel de la unidad administrativa para realizar la transferencia,");
			}
			else if (request.IdMotivoTramite == (long)EnumMotivoTramite.CambioDeResguardosDeMobiliarioYEquipo)
			{

				if (string.IsNullOrEmpty(request.Responsable))
					errores.Append("El responsable es requerido,");
			}
			if (string.IsNullOrEmpty(errores.ToString())) return;
			var erroresConverter = BusConvertirErrors.URemoverComillaFinal(errores.ToString());
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, erroresConverter);
		}

		private async Task BValidarRequestMovimientoBDAsync(EntDetalleMovimientoMuebleRequest request, EntDetalleMovimiento entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
			var existeUnidadAdministrativa = unidadAdministrativa != null;

			var nuevaUnidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelNuevaUnidadAdministrativa);
			var existeNuevaUnidadAdministrativa = request.IdMotivoTramite == (long)EnumMotivoTramite.CambioDeCentroDeCostos || request.IdMotivoTramite == (long)EnumMotivoTramite.TransferenciaDeBienesMuebles ? nuevaUnidadAdministrativa != null : true;

			var existeUbicacion = await _repoUbicacion.DExisteRegistroAsync(e => e.iIdUbicacion == request.IdUbicacion);
			var existeMunicipio = await _repoMunicipio.DExisteRegistroAsync(e => e.iIdMunicipio == request.IdMunicipio);

			var foliosBienes = request.FolioBien.Split(",").ToArray();
			var bienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado:
				e => foliosBienes.Contains(e.sFolioBien));
			var existenTodosBienes = bienes.Count == foliosBienes.Count();

			var idsResponsables = request.IdMotivoTramite == (long)EnumMotivoTramite.CambioDeResguardosDeMobiliarioYEquipo
				? request.Responsable.Split(',', StringSplitOptions.RemoveEmptyEntries)
							.Select(x => long.Parse(x))
							.ToList()
				: new List<long>();
			var existenResguardantes = await _repoResguardante.DExistenRegistrosAsync(idsResponsables, e => e.iIdResguardante);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existeUbicacion) errores.Append("La ubicacion no existe,");
			if (!existeMunicipio) errores.Append("El municipio no existe,");
			if (!existenTodosBienes) errores.Append("Algunos Bienes no existen en el inventario,");
			if (!existeNuevaUnidadAdministrativa) errores.Append("La nueva unidad administrativa no existe,");
			if (!existeUnidadAdministrativa) errores.Append("La unidad administrativa no existe,");
			if (!existenResguardantes) errores.Append("Algunos Documentos no existen,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteMoviemientoAsync(request, entidad, unidadAdministrativa, nuevaUnidadAdministrativa);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BCrearTramiteMovimientoAsync(EntDetalleMovimientoMuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteMovimientoAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de movimiento de un bien mueble");
			try
			{
				BValidarRequestMovimiento(request);
				var detalleSolicitud = _mapper.Map<EntDetalleMovimientoMuebleRequest, EntDetalleSolicitud>(request);
				await BValidarRequestMovimientoBDAsync(request, detalleSolicitud.DetalleMovimiento);

				var result = await _repoDetalleSolicitud.DCrearAsync(detalleSolicitud);
				var seguimiento = BGenerarSeguimiento(detalleSolicitud, detalleSolicitud.iIdEtapa);
				var resultadoSeguimiento = await _repoSeguimiento.DCrearAsync(seguimiento);
				await transaction.CommitAsync();
				resultado.Success(result + resultadoSeguimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el tramite de movimiento de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteMovimientoAsync(long idDetalleSolicitud, EntDetalleMovimientoMuebleRequest request)
		{

			var nombreMetodo = nameof(BCrearTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de movimiento de un bien mueble");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleMovimiento
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(
					predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud,
					incluir: includes,
					desactivarTracking: false
				) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (detalleSolicitud.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("No se puede modificar el trámite en la etapa actual.");

				var detalle = detalleSolicitud.DetalleMovimiento;
				BValidarRequestMovimiento(request);
				await BValidarRequestMovimientoBDAsync(request, detalle);

				detalle.iIdMunicipio = request.IdMunicipio.Value;
				detalle.iIdUbicacion = request.IdUbicacion.Value;
				detalle.sFolioBien = request.FolioBien;

				var result = await _repoDetalleSolicitud.DActualizarAsync(detalleSolicitud);
				await transaction.CommitAsync();
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el tramite de movimiento de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleMovimientoMuebleResponse>> BObtenerTramiteMovimientoAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteMovimientoAsync);
			var resultado = new EntityResponse<EntDetalleMovimientoMuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de movimeinto");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleMovimientoMuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleMovimientoMuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de movimiento"
				);
			}

			return resultado;
		}

		private async Task BCompletarDatosTramiteDesincorporacionAsync(EntDetalleDesincorporacionMuebleRequest request, EntDetalleDesincorporacion entidad, EntUnidadAdministrativa unidadAdministrativa)
		{
			await BCambiarEstadoBienes(entidad.sFolioBien, request.FolioBien);
			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
		}

		private void BValidarRequestDesincorporacion(EntDetalleDesincorporacionMuebleRequest request)
		{
			var resultadoValidacion = _validatorDesincorporacion.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		private async Task BValidarRequestDesincorporacionBDAsync(EntDetalleDesincorporacionMuebleRequest request, EntDetalleDesincorporacion entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
			var existeUnidadAdministrativa = unidadAdministrativa != null;

			var foliosBienes = request.FolioBien.Split(",").ToArray();
			var bienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado:
				e => foliosBienes.Contains(e.sFolioBien));
			var existenTodosBienes = bienes.Count == foliosBienes.Count();

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existenTodosBienes) errores.Append("Algunos Bienes no existen en el inventario,");
			if (!existeUnidadAdministrativa) errores.Append("La unidad administrativa no existe,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteDesincorporacionAsync(request, entidad, unidadAdministrativa);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BCrearTramiteDesincorporacionAsync(EntDetalleDesincorporacionMuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteMovimientoAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de desincorporacion de un bien mueble");
			try
			{
				BValidarRequestDesincorporacion(request);
				var detalleSolicitud = _mapper.Map<EntDetalleDesincorporacionMuebleRequest, EntDetalleSolicitud>(request);
				await BValidarRequestDesincorporacionBDAsync(request, detalleSolicitud.DetalleDesincorporacion);

				var result = await _repoDetalleSolicitud.DCrearAsync(detalleSolicitud);
				var seguimiento = BGenerarSeguimiento(detalleSolicitud, detalleSolicitud.iIdEtapa);
				var resultadoSeguimiento = await _repoSeguimiento.DCrearAsync(seguimiento);
				await transaction.CommitAsync();
				resultado.Success(result + resultadoSeguimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el tramite de desincorporacion de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteDesincorporacionAsync(long idDetalleSolicitud, EntDetalleDesincorporacionMuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteDesincorporacionAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de desincorporacion de un bien mueble");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleDesincorporacion
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(
					predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud,
					incluir: includes,
					desactivarTracking: false
				) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (detalleSolicitud.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("No se puede modificar el trámite en la etapa actual.");

				var detalle = detalleSolicitud.DetalleDesincorporacion;
				BValidarRequestDesincorporacion(request);
				await BValidarRequestDesincorporacionBDAsync(request, detalle);

				detalle.sFolioBien = request.FolioBien;
				detalle.sObservaciones = request.Observaciones;
				detalle.dtFechaPublicacion = request.FechaPublicacion.Value;
				detalle.sNumeroPublicacion = request.NumeroPublicacion;
				detalle.sDescripcionDesincorporacion = request.DescripcionDesincorporacion;

				var result = await _repoDetalleSolicitud.DActualizarAsync(detalleSolicitud);
				await transaction.CommitAsync();
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el tramite de desincorporacion de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleDesincorporacionMuebleResponse>> BObtenerTramiteDesincorporacionAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteDesincorporacionAsync);
			var resultado = new EntityResponse<EntDetalleDesincorporacionMuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de desincorporacion");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleDesincorporacionMuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleDesincorporacionMuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de desincorporacion"
				);
			}

			return resultado;
		}

		private async Task BCompletarDatosTramiteDestinoFinalAsync(EntDetalleDestinoFinalMuebleRequest request, EntDetalleDestinoFinal entidad, EntUnidadAdministrativa unidadAdministrativa)
		{
			await BCambiarEstadoBienes(entidad.sFolioBien, request.FolioBien);
			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
			entidad.sFolioBien = request.FolioBien;
		}

		private void BValidarRequestDestinoFinal(EntDetalleDestinoFinalMuebleRequest request)
		{
			var errores = new StringBuilder(string.Empty);

			if (request.IdMotivoTramite == (long)EnumMotivoTramite.Enajenacion)
			{
				if (string.IsNullOrEmpty(request.AvaluoEnajenacion))
					errores.Append("El avaluo de enajenacion es requerido,");

				if (string.IsNullOrEmpty(request.DescripcionEnajenacion))
					errores.Append("La descripcion de enajenacion es requerida,");

				if (!request.FechaEnajenacion.HasValue)
					errores.Append("La fecha de enajenacion es requerida,");

				if (string.IsNullOrEmpty(request.FolioEnajenacion))
					errores.Append("El folio de enajenacion es requerido,");

				if(!request.ImporteAvaluoEnajenacion.HasValue)
					errores.Append("El importe del avaluo de enajenacion es requerido,");

				if (request.ImporteAvaluoEnajenacion.HasValue && request.ImporteAvaluoEnajenacion.Value <= 0)
					errores.Append("El importe del avaluo de ser mayor a 0,");
			} else if (request.IdMotivoTramite == (long)EnumMotivoTramite.Destruccion)
			{
				if (string.IsNullOrEmpty(request.DescripcionDestruccion))
					errores.Append("La descripcion de destruccion es requerida,");

				if (string.IsNullOrEmpty(request.FolioDestruccion))
					errores.Append("El folio de destruccion es requerido,");

				if (!request.FechaDestruccion.HasValue)
					errores.Append("La fecha de destruccion es requerida, ");
			}
			if (string.IsNullOrEmpty(errores.ToString())) return;
			var erroresConverter = BusConvertirErrors.URemoverComillaFinal(errores.ToString());
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, erroresConverter);
		}

		private async Task BValidarRequestDestinoFinalBDAsync(EntDetalleDestinoFinalMuebleRequest request, EntDetalleDestinoFinal entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == request.NivelUnidadAdministrativa);
			var existeUnidadAdministrativa = unidadAdministrativa != null;

			var foliosBienes = request.FolioBien.Split(",").ToArray();
			var bienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado:
				e => foliosBienes.Contains(e.sFolioBien));
			var existenTodosBienes = bienes.Count == foliosBienes.Count();

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existenTodosBienes) errores.Append("Algunos Bienes no existen en el inventario,");
			if (!existeUnidadAdministrativa) errores.Append("La unidad administrativa no existe,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteDestinoFinalAsync(request, entidad, unidadAdministrativa);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BCrearTramiteDestinoFinalAsync(EntDetalleDestinoFinalMuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteDestinoFinalAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de destino final de un bien mueble");
			try
			{
				BValidarRequestDestinoFinal(request);
				var detalleSolicitud = _mapper.Map<EntDetalleDestinoFinalMuebleRequest, EntDetalleSolicitud>(request);
				await BValidarRequestDestinoFinalBDAsync(request, detalleSolicitud.DetalleDestinoFinal);
				if (request.IdMotivoTramite == (long)EnumMotivoTramite.Enajenacion)
				{
					detalleSolicitud.DetalleDestinoFinal.DetalleDestruccion = null;
				}
				else if (request.IdMotivoTramite == (long)EnumMotivoTramite.Destruccion)
				{
					detalleSolicitud.DetalleDestinoFinal.DetalleEnagenacion = null;
				}

				var result = await _repoDetalleSolicitud.DCrearAsync(detalleSolicitud);
				var seguimiento = BGenerarSeguimiento(detalleSolicitud, detalleSolicitud.iIdEtapa);
				var resultadoSeguimiento = await _repoSeguimiento.DCrearAsync(seguimiento);
				await transaction.CommitAsync();
				resultado.Success(result + resultadoSeguimiento, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar crear el tramite de destino final de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteDestinoFinalAsync(long idDetalleSolicitud, EntDetalleDestinoFinalMuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteDesincorporacionAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de destino final de un bien mueble");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleDestinoFinal.DetalleEnagenacion,
					e => e.DetalleDestinoFinal.DetalleDestruccion,
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(
					predicado: e => e.iIdDetalleSolicitud == idDetalleSolicitud,
					incluir: includes,
					desactivarTracking: false
				) ?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);

				if (detalleSolicitud.iIdEtapa != (long)EnumEtapa.CapturaInicial)
					throw new BusConflictoException("No se puede modificar el trámite en la etapa actual.");

				var detalle = detalleSolicitud.DetalleDestinoFinal;
				BValidarRequestDestinoFinal(request);
				await BValidarRequestDestinoFinalBDAsync(request, detalle);

				if (request.IdMotivoTramite == (long)EnumMotivoTramite.Enajenacion)
				{
					var enajenacion = detalle.DetalleEnagenacion;
					enajenacion.dtFecha = request.FechaEnajenacion.Value;
					enajenacion.sDescripcion = request.DescripcionEnajenacion;
					enajenacion.sFolio = request.FolioEnajenacion;
					enajenacion.dImporteAvaluo = request.ImporteAvaluoEnajenacion.Value;
					enajenacion.sAvaluo = request.AvaluoEnajenacion;
				}
				else if (request.IdMotivoTramite == (long)EnumMotivoTramite.Destruccion)
				{
					var destruccion = detalle.DetalleDestruccion;
					destruccion.dtFecha = request.FechaDestruccion.Value;
					destruccion.sDescripcion = request.DescripcionDestruccion;
					destruccion.sFolio = request.FolioDestruccion;
				}

				var result = await _repoDetalleSolicitud.DActualizarAsync(detalleSolicitud);
				await transaction.CommitAsync();
				resultado.Success(result, _code);
			}
			catch (Exception ex)
			{
				await transaction.RollbackAsync();
				resultado = BusExceptionHandler.Handle<int>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar actualizar el tramite de destino final de un bien mueble"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleDestinoFinalMuebleResponse>> BObtenerTramiteDestinoFinalAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteMovimientoAsync);
			var resultado = new EntityResponse<EntDetalleDestinoFinalMuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de destino final de un bien mueble");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleDestinoFinalMuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleDestinoFinalMuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de destino final de un bien mueble"
				);
			}

			return resultado;
		}
	}
}
