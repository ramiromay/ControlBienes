using AutoMapper;
using ControlBienes.Business.Contrats.Patrimonio;
using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Business.Exceptions;
using ControlBienes.Business.Features.Catalogos.Familia;
using ControlBienes.Business.Features.Patrimonio.TramiteMueble;
using ControlBienes.Business.Genericos;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Repository.Catalogos;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Constants;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.General.Cuenta;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.BajaInmueble;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.SubModulo;
using ControlBienes.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Features.Patrimonio.TramiteInmueble
{
	public class BusTramiteInmueble : IBusTramiteInmueble
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
		private readonly IBusIdentityAccess _servicioAcesso;
		private readonly IMapper _mapper;
		private readonly IValidator<EntDetalleAltaInmuebleRequest> _validatorAlta;
		private readonly IValidator<EntDetalleModificacionInmuebleRequest> _validatorModificacion;
		private readonly IValidator<EntDetalleBajaInmuebleRequest> _validatorBaja;
		private readonly IValidator<EntDetalleDesincorporacionMuebleRequest> _validatorDesincorporacion;
		private readonly ILogger<BusTramiteMueble> _logger;
		private const EnumCodigoOperacion _code = EnumCodigoOperacion.CodeOkTramiteMueble;
		private const EnumCodigoOperacion _codeError = EnumCodigoOperacion.CodeErrorTramiteMueble;

		public BusTramiteInmueble(IDatDetalleAlta repoAlta, IDatEtapaTramite repoEtapaTramite, IDatDetalleSolicitud repoDetalleSolicitud, IDatSolicitud repoSolicitud, IDatSeguimiento repoSeguimiento, IDatHistorial repoHistorial, IDatFamilia repoFamilia, IDatSubfamilia repoSubfamilia, IDatMarca repoMarca, IDatBms repoBms, IDatPeriodo repoPeriodo, IDatUnidadAdministrativa repoUnidadAdministrativa, IDatTipoAdquisicion repoTipoAdquisicion, IDatEstadoFisico repoEstadoFisico, IDatColor repoColor, IDatUbicacion repoUbicacion, IDatMunicipio repoMunicipio, IDatCaracteristicaBien repoCaracteristicaBien, IDatResguardante repoResguardante, IMapper mapper, IValidator<EntDetalleAltaInmuebleRequest> validatorAlta, ILogger<BusTramiteMueble> logger, IDatBienPatrimonio repoBienPatrimonio, IDatDetalleModificacion repoModificacion, IValidator<EntDetalleModificacionInmuebleRequest> validatorModificacion, IDatDetalleBaja repoBaja, IValidator<EntDetalleBajaInmuebleRequest> validatorBaja, IDatDocumento repoDocumento, IValidator<EntDetalleDesincorporacionMuebleRequest> validatorDesincorporacion, IBusIdentityAccess servicioAcesso)
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
			_servicioAcesso = servicioAcesso;
		}
		private bool BDepreciaBien(long idSubfamilia, decimal precioUnitario)
		{
			return idSubfamilia != EntConstant.InmuebleNoDeprecia &&
				precioUnitario != EntConstant.PrecioNoDeprecia;
		}

		private EntBienPatrimonio BGenerarBienMueble(EntDetalleSolicitud detalleSolicitud)
		{
			var request = detalleSolicitud.DetalleAlta;
			return new EntBienPatrimonio
			{
				iIdSolicitud = request.iIdSolicitud,
				iIdPeriodo = detalleSolicitud.Solicitud.iIdPeriodo,
				iIdTipoBien = detalleSolicitud.Solicitud.iIdTipoBien,
				iIdUnidadAdministrativa = request.iIdUnidadAdministrativa,
				sReferenciaConac = request.sReferenciaConac,
				iIdFamilia = request.iIdFamilia,
				iIdSubfamilia = request.iIdSubfamilia,
				dtFechaAlta = DateTime.Now,
				sDescripcion = request.sDescripcion,
				iIdEstadoFisico = request.iIdEstadoFisico,
				iIdTipoAdquisicion = request.iIdTipoAdquisicion,
				iIdMunicipio = request.iIdMunicipio,
				dPrecioUnitario = request.dPrecioUnitario,
				iAniosVida = request.iAniosVida,
				dtFechaAdquisicion = request.dtFechaAdquisicion,
				sObservacionBien = request.sObservacionBien,
				sObservacionResponsable = request.sObservacionResponsable,
				bDeprecia = BDepreciaBien(request.iIdSubfamilia, request.dPrecioUnitario),
				DatoInmueble = new()
				{
					sNomenclatura = request.DatosInmueble.sNomenclatura,
					iIdTipoInmueble = request.DatosInmueble.iIdTipoInmueble,
					iIdUsoInmueble = request.DatosInmueble.iIdUsoInmueble,
					iIdTipoDomninio = request.DatosInmueble.iIdTipoDomninio,
					iIdTipoAfectacion = request.DatosInmueble.iIdTipoAfectacion,
					sAfectante = request.DatosInmueble.sAfectante,
					dValorHistorico = request.DatosInmueble.dValorHistorico,
					dValorLibros = request.DatosInmueble.dValorLibros,
					dDepreciacion = request.DatosInmueble.dDepreciacion,
					sPublicacion = request.DatosInmueble.sPublicacion,
					sExpediente = request.DatosInmueble.sExpediente,
					sEscrituraTitulo = request.DatosInmueble.sEscrituraTitulo,
					dtFechaAltaSistema = request.DatosInmueble.dtFechaAltaSistema,
					DatosRegistral = new()
					{
						iFolioCatastro = request.DatosInmueble.DatosRegistral.iFolioCatastro,
						sCalle = request.DatosInmueble.DatosRegistral.sCalle,
						dSuperficie = request.DatosInmueble.DatosRegistral.dSuperficie,
						dValorTerreno = request.DatosInmueble.DatosRegistral.dValorTerreno,
						sNumeroExterior = request.DatosInmueble.DatosRegistral.sNumeroExterior,
						sNumeroInterior = request.DatosInmueble.DatosRegistral.sNumeroInterior,
						sCruzamimiento1 = request.DatosInmueble.DatosRegistral.sCruzamimiento1,
						sCruzamimiento2 = request.DatosInmueble.DatosRegistral.sCruzamimiento2,
						dSuperficieContruccion = request.DatosInmueble.DatosRegistral.dSuperficieContruccion,
						sTablaje = request.DatosInmueble.DatosRegistral.sTablaje,
						dValorConstruccion = request.DatosInmueble.DatosRegistral.dValorConstruccion,
						dValorInicial = request.DatosInmueble.DatosRegistral.dValorInicial,
						nCodigoPostal = request.DatosInmueble.DatosRegistral.nCodigoPostal,
						iIdOrigenValor = request.DatosInmueble.DatosRegistral.iIdOrigenValor,
						sAsentamiento = request.DatosInmueble.DatosRegistral.sAsentamiento,
						sPropietario = request.DatosInmueble.DatosRegistral.sPropietario
					}
				}
			};
		}

		private EntHistorial BGenerarHistorial(EntBienPatrimonio bienMueble, EntDetalleSolicitud detalle)
		{
			var idUsuario = _servicioAcesso.BObtenerIdUsuario();
			return new EntHistorial()
			{
				iIdBien = bienMueble.iIdBien,
				iIdSolicitud = detalle.iIdSolicitud,
				iIdModulo = (long)EnumModulo.SistemaIntegralDePatrimonio,
				iIdSubModulo = (long)EnumSubModulo.AdministradorCedulasBienesInmuebles,
				iIdUsuario = idUsuario
			};
		}

		private EntSeguimiento BGenerarSeguimiento(EntDetalleSolicitud detalleSolicitud, long idEtapa)
		{
			var idUsuario = _servicioAcesso.BObtenerIdUsuario();

			return new EntSeguimiento()
			{
				iIdDetalleSolicitud = detalleSolicitud.iIdDetalleSolicitud,
				iIdEtapa = idEtapa,
				dtFechaHora = DateTime.Now,
				iIdModulo = (long)EnumModulo.SistemaIntegralDePatrimonio,
				iIdSubModulo = (long)EnumSubModulo.AdministradorCedulasBienesInmuebles,
				iIdUsuario = idUsuario
			};
		}

		private async Task BAplicarVOBOAsync(EntDetalleSolicitud detalleSolicitud)
		{

			if (detalleSolicitud.DetalleAlta != null)
			{
				var detalleAlta = detalleSolicitud.DetalleAlta;
				var bienMueble = BGenerarBienMueble(detalleSolicitud);
				await _repoBienPatrimonio.DCrearAsync(bienMueble);

				var folioBien = BusTransformarUtils.UGenerarFolioBien(BusTransformarUtils.PrefijoInmueble, bienMueble.iIdBien);
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
					detalle.dtFechaBaja = detalleSolicitud.DetalleBaja.BajaInmueble.dtFechaBaja;
					detalle.sMotivoBaja = detalleSolicitud.DetalleBaja.BajaInmueble.sJustificacion;
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
					e => e.DatoInmueble.DatosRegistral,
				};
				var tramiteOriginal = await _repoBienPatrimonio.DObtenerRegistroAsync(incluir: incluir, predicado: e => e.sFolioBien == foliosBien, desactivarTracking: false);

				if (idMotivoTramite == (long)EnumMotivoTramite.ModificacionDeDatosDelInmueble)
				{
					tramiteOriginal.sReferenciaConac = tramiteActualizado.sReferenciaConac;
					tramiteOriginal.iIdFamilia = tramiteActualizado.iIdFamilia;
					tramiteOriginal.iIdSubfamilia = tramiteActualizado.iIdSubfamilia;
					tramiteOriginal.DatoInmueble.sNomenclatura = tramiteActualizado.DatoInmueble.sNomenclatura;
					tramiteOriginal.sDescripcion = tramiteActualizado.sDescripcion;
					tramiteOriginal.iIdEstadoFisico = tramiteActualizado.iIdEstadoFisico;
					tramiteOriginal.DatoInmueble.iIdTipoDomninio = tramiteActualizado.DatoInmueble.iIdTipoDomninio;
					tramiteOriginal.DatoInmueble.iIdUsoInmueble = tramiteActualizado.DatoInmueble.iIdUsoInmueble;
					tramiteOriginal.iIdMunicipio = tramiteActualizado.iIdMunicipio;
					tramiteOriginal.sObservacionBien = tramiteActualizado.sObservacionBien;
					tramiteOriginal.sObservacionResponsable = tramiteActualizado.sObservacionResponsable;
					tramiteOriginal.DatoInmueble.DatosRegistral.nCodigoPostal = tramiteActualizado.DatoInmueble.DatosRegistral.nCodigoPostal;

				}
				else if (idMotivoTramite == (long)EnumMotivoTramite.ModificacionPorCorreccionDeMedidas)
				{
					tramiteOriginal.DatoInmueble.DatosRegistral.dSuperficie = tramiteActualizado.DatoInmueble.DatosRegistral.dSuperficie;
					tramiteOriginal.DatoInmueble.DatosRegistral.dValorTerreno = tramiteActualizado.DatoInmueble.DatosRegistral.dValorTerreno;
					tramiteOriginal.DatoInmueble.DatosRegistral.dSuperficieContruccion = tramiteActualizado.DatoInmueble.DatosRegistral.dSuperficieContruccion;
					tramiteOriginal.DatoInmueble.DatosRegistral.dValorConstruccion = tramiteActualizado.DatoInmueble.DatosRegistral.dValorConstruccion;
					tramiteOriginal.DatoInmueble.DatosRegistral.dValorInicial = tramiteActualizado.DatoInmueble.DatosRegistral.dValorTerreno + tramiteActualizado.DatoInmueble.DatosRegistral.dValorConstruccion;
					tramiteOriginal.dPrecioUnitario = tramiteOriginal.DatoInmueble.DatosRegistral.dValorInicial;
					tramiteOriginal.iAniosVida = tramiteActualizado.iAniosVida;
					tramiteOriginal.bDeprecia = BDepreciaBien(tramiteOriginal.iIdSubfamilia, tramiteOriginal.dPrecioUnitario);

				}
				else if (idMotivoTramite == (long)EnumMotivoTramite.ModificacionPorConstruccion || idMotivoTramite == (long)EnumMotivoTramite.ModificacionPorMejoraConstruccion)
				{
					tramiteOriginal.DatoInmueble.DatosRegistral.dSuperficie = tramiteActualizado.DatoInmueble.DatosRegistral.dSuperficie;
					tramiteOriginal.DatoInmueble.DatosRegistral.dValorTerreno = tramiteActualizado.DatoInmueble.DatosRegistral.dValorTerreno;
					tramiteOriginal.DatoInmueble.DatosRegistral.dSuperficieContruccion = tramiteActualizado.DatoInmueble.DatosRegistral.dSuperficieContruccion;
					tramiteOriginal.DatoInmueble.DatosRegistral.dValorConstruccion = tramiteActualizado.DatoInmueble.DatosRegistral.dValorConstruccion;
					tramiteOriginal.DatoInmueble.DatosRegistral.dValorInicial = tramiteActualizado.DatoInmueble.DatosRegistral.dValorTerreno + tramiteActualizado.DatoInmueble.DatosRegistral.dValorConstruccion;
					tramiteOriginal.dPrecioUnitario = tramiteOriginal.DatoInmueble.DatosRegistral.dValorInicial;
					tramiteOriginal.iAniosVida = tramiteActualizado.iAniosVida;
					tramiteOriginal.DatoInmueble.iIdUsoInmueble = tramiteActualizado.DatoInmueble.iIdUsoInmueble;
					tramiteOriginal.bDeprecia = BDepreciaBien(tramiteOriginal.iIdSubfamilia, tramiteOriginal.dPrecioUnitario);

				}
				else if (idMotivoTramite == (long)EnumMotivoTramite.ModificacionPorAfectacion)
				{
					tramiteOriginal.DatoInmueble.iIdTipoAfectacion = tramiteActualizado.DatoInmueble.iIdTipoAfectacion;
					tramiteOriginal.DatoInmueble.sAfectante = tramiteActualizado.DatoInmueble.sAfectante;
					tramiteOriginal.DatoInmueble.iIdTipoDomninio = tramiteActualizado.DatoInmueble.iIdTipoDomninio;
					tramiteOriginal.DatoInmueble.iIdUsoInmueble = tramiteActualizado.DatoInmueble.iIdUsoInmueble;
					tramiteOriginal.DatoInmueble.iIdTipoInmueble = tramiteActualizado.DatoInmueble.iIdTipoInmueble;
				}
				tramiteOriginal.bEnProceso = false;
				await _repoBienPatrimonio.DActualizarAsync(tramiteOriginal);
				var historial = BGenerarHistorial(tramiteOriginal, detalleSolicitud);
				await _repoHistorial.DCrearAsync(historial);
			}
		}
		private async Task<bool> BEsTramiteDonacion(long idSolicitud)
		{
			var solicitud = await _repoSolicitud.DObtenerRegistroAsync(e => e.iIdSolicitud == idSolicitud);
			var idMotivoTramite = solicitud.iIdMotivoTramite;
			return idMotivoTramite == 9 || idMotivoTramite == 32 || idMotivoTramite == 57;
		}

		private async Task BAplicarRechazadoAsync(EntDetalleSolicitud detalleSolicitud)
		{
			if (detalleSolicitud.DetalleAlta != null) return;
			var foliosBien = detalleSolicitud.DetalleModificacion != null
				? detalleSolicitud.DetalleModificacion.sFolioBien
				: detalleSolicitud.DetalleBaja != null
					? detalleSolicitud.DetalleBaja.Baja.sFolioBien
					: "";
			var listFoliosBien = foliosBien.Split(",");
			var bienes = await _repoBienPatrimonio.DObtenerTodosAsync(predicado: e => listFoliosBien.Contains(e.sFolioBien), desactivarTracking: false);
			foreach (var bien in bienes)
			{
				bien.bEnProceso = false;
				await _repoBienPatrimonio.DActualizarAsync(bien);
			}
		}

		private void BValidarRequestAlta(EntDetalleAltaInmuebleRequest request)
		{
			var resultadoValidacion = _validatorAlta.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		private async Task BCompletarDatosTramiteAltaAsync(EntDetalleAltaInmuebleRequest request, EntDetalleAlta entidad, EntFamilia familia, EntSubfamilia subfamilia)
		{
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == "55.23.3");
			var periodo = await _repoPeriodo.DObtenerRegistroAsync(e => e.bActivo);
			var idPeriodo = periodo.iIdPeriodo;
			var esDonacion = await BEsTramiteDonacion(request.IdSolicitud.Value);

			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
			entidad.sCuentaActivo = $"{EntPlanCuenta.CuentaNo_123}.{subfamilia.iNumeroCuenta}.{idPeriodo}.{unidadAdministrativa.sNivelCompleto}.{EntConstant.DefaultFuenteFinanciamiento}";
			entidad.sCuentaActualizacion = esDonacion ? EntPlanCuenta.CuentaNo_3121 : entidad.sCuentaActivo;
		}

		private async Task BValidarRequestAltaBDAsync(EntDetalleAltaInmuebleRequest request, EntDetalleAlta entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var familia = await _repoFamilia.DObtenerRegistroAsync(request.IdFamilia.Value);
			var existeFamilia = familia != null;
			var subFamilia = await _repoSubfamilia.DObtenerRegistroAsync(request.IdSubfamilia.Value);
			var existeSubFamilia = familia != null;
			var perteneceSubFamiliaAFamilia = existeFamilia && existeSubFamilia && subFamilia.iIdFamilia == familia.iIdFamilia;
			var existeRequisicion = await _repoTipoAdquisicion.DExisteRegistroAsync(e => e.iIdTipoAdquisicion == request.IdTipoAdquisicion);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existeFamilia) errores.Append("La Familia no se encuentra registrada,");
			if (!existeSubFamilia) errores.Append("La Subfamilia no se encuentra registrada,");
			if (!perteneceSubFamiliaAFamilia) errores.Append("La Subfamilia no pertenece a la Familia,");
			if (!existeRequisicion) errores.Append("La Requisicion no se encuentra registrada,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteAltaAsync(request, entidad, familia, subFamilia);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BActualizarTramiteAltaAsync(long idDetalleSolicitud, EntDetalleAltaInmuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de alta");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleAlta.DatosInmueble.DatosRegistral,
					e => e.DetalleAlta.Factura.DatoVehicular,
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

				detalleAlta.sReferenciaConac = request.ReferenciaConac;
				detalleAlta.iIdFamilia = request.IdFamilia.Value;
				detalleAlta.iIdSubfamilia = request.IdSubfamilia.Value;
				detalleAlta.DatosInmueble.sNomenclatura = request.Nomenclatura;
				detalleAlta.sDescripcion = request.Descripcion;
				detalleAlta.DatosInmueble.iIdTipoInmueble = request.IdTipoInmueble.Value;
				detalleAlta.DatosInmueble.iIdUsoInmueble = request.IdUsoInmueble.Value;
				detalleAlta.DatosInmueble.iIdTipoDomninio = request.IdTipoDominio.Value;
				detalleAlta.iIdEstadoFisico = request.IdEstadoFisico.Value;
				detalleAlta.DatosInmueble.iIdTipoAfectacion = request.IdTipoAfectacion.Value;
				detalleAlta.DatosInmueble.sAfectante = request.Afectante;
				detalleAlta.iIdTipoAdquisicion = request.IdTipoAdquisicion.Value;
				detalleAlta.iIdMunicipio = request.IdMunicipio;
				detalleAlta.DatosInmueble.dValorHistorico = request.ValorHistorico.Value;
				detalleAlta.DatosInmueble.dValorLibros = request.ValorLibros.Value;
				detalleAlta.DatosInmueble.dDepreciacion = request.Depreciacion.Value;
				detalleAlta.dPrecioUnitario = request.ValorTerreno.Value + request.ValorConstruccion.Value;
				detalleAlta.iAniosVida = request.AniosVida.Value;

				detalleAlta.dtFechaAdquisicion = request.FechaAdquisicion.Value;
				detalleAlta.DatosInmueble.dtFechaAltaSistema = request.FechaAltaSistema.Value;

				detalleAlta.DatosInmueble.DatosRegistral.iFolioCatastro = request.FolioCatastro.Value;
				detalleAlta.DatosInmueble.DatosRegistral.sCalle = request.Calle;
				detalleAlta.DatosInmueble.DatosRegistral.dSuperficie = request.Superficie.Value;
				detalleAlta.DatosInmueble.DatosRegistral.dValorTerreno = request.ValorTerreno.Value;
				detalleAlta.DatosInmueble.DatosRegistral.sNumeroExterior = request.NumeroExterior;
				detalleAlta.DatosInmueble.DatosRegistral.sNumeroInterior = request.NumeroInterior;
				detalleAlta.DatosInmueble.DatosRegistral.sCruzamimiento1 = request.Cruzamiento1;
				detalleAlta.DatosInmueble.DatosRegistral.sCruzamimiento2 = request.Cruzamiento2;
				detalleAlta.DatosInmueble.DatosRegistral.dSuperficieContruccion = request.SuperficieConstruccion.Value;
				detalleAlta.DatosInmueble.DatosRegistral.sTablaje = request.Tablaje;
				detalleAlta.DatosInmueble.DatosRegistral.dValorConstruccion = request.ValorConstruccion.Value;
				detalleAlta.DatosInmueble.DatosRegistral.dValorInicial = request.ValorTerreno.Value + request.ValorConstruccion.Value;
				detalleAlta.DatosInmueble.DatosRegistral.nCodigoPostal = request.CodigoPostal.Value;
				detalleAlta.DatosInmueble.DatosRegistral.iIdOrigenValor = request.IdOrigenValor.Value;
				detalleAlta.DatosInmueble.DatosRegistral.sAsentamiento = request.Asentamiento;
				detalleAlta.DatosInmueble.DatosRegistral.sPropietario = request.Propietario;

				detalleAlta.sObservacionBien = request.ObservacionInmueble;
				detalleAlta.sObservacionResponsable = request.ObservacionSupervicion;

				detalleAlta.DatosInmueble.sPublicacion = request.DecretoPublicaicion;
				detalleAlta.DatosInmueble.sExpediente = request.Expediente;
				detalleAlta.DatosInmueble.sEscrituraTitulo = request.EscrituraTitulo;

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
					"Ocurrio un error al intentar actualizar el tramite de alta"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCrearTramiteAltaAsync(EntDetalleAltaInmuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de alta");
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
					"Ocurrio un error al intentar crear el tramite de alta"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<EntDetalleAltaInmuebleResponse>> BObtenerTramiteAltaAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteAltaAsync);
			var resultado = new EntityResponse<EntDetalleAltaInmuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de alta");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleAltaInmuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleAltaInmuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de alta"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BCambiarEtapaTramiteAsync(long idDetalleSolicitud, long? idEtapa)
		{
			var nombreMetodo = nameof(BCambiarEtapaTramiteAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para cambiar la etapa del tramite");
			try
			{

				if (!idEtapa.HasValue)
					throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, "La Etapa a la que quiere cambiar es requerida");

				var incluir = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleAlta.DatosInmueble.DatosRegistral,
					e => e.DetalleBaja.BajaInmueble,
					e => e.DetalleBaja.Baja,
					e => e.DetalleModificacion.DatoInmueble.DatosRegistral,
					e => e.Solicitud
				};
				var detalleSolicitud = await _repoDetalleSolicitud.DObtenerRegistroAsync(e => e.iIdDetalleSolicitud == idDetalleSolicitud, incluir: incluir)
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
					"Ocurrio un error al intentar carmbiar la etapa del tramite"
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

		private void BValidarRequestModificacion(EntDetalleModificacionInmuebleRequest request)
		{
			var resultadoValidacion = _validatorModificacion.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}


		private async Task BCompletarDatosTramiteModificacionAsync(EntDetalleModificacionInmuebleRequest request, EntDetalleModificacion entidad, EntBienPatrimonio bien,EntSubfamilia subfamilia)
		{
			var unidadAdministrativa = await _repoUnidadAdministrativa.DObtenerRegistroAsync(e => e.sNivelCompleto == "55.23.3");
			var periodo = await _repoPeriodo.DObtenerRegistroAsync(e => e.bActivo);
			var idPeriodo = periodo.iIdPeriodo;
			var esDonacion = await BEsTramiteDonacion(request.IdSolicitud.Value);

			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
			entidad.sCuentaActivo = $"{EntPlanCuenta.CuentaNo_123}.{subfamilia.iNumeroCuenta}.{idPeriodo}.{unidadAdministrativa.sNivelCompleto}.{EntConstant.DefaultFuenteFinanciamiento}";
			entidad.sCuentaActualizacion = esDonacion ? EntPlanCuenta.CuentaNo_3121 : entidad.sCuentaActivo;
			await BCambiarEstadoBienes(entidad.sFolioBien, bien.sFolioBien);
			entidad.sFolioBien = bien.sFolioBien;
			entidad.iIdUnidadAdministrativa = unidadAdministrativa.iIdUnidadAdministrativa;
			entidad.iIdCentroCosto = bien.iIdUnidadAdministrativa;
			entidad.sCuentaActivo = $"{EntPlanCuenta.CuentaNo_123}.{subfamilia.iNumeroCuenta}.{idPeriodo}.{unidadAdministrativa.sNivelCompleto}.{EntConstant.DefaultFuenteFinanciamiento}";
			entidad.sCuentaActualizacion = esDonacion ? EntPlanCuenta.CuentaNo_3121 : entidad.sCuentaActivo;
		}

		private async Task BValidarRequestModificacionBDAsync(EntDetalleModificacionInmuebleRequest request, EntDetalleModificacion entidad)
		{

			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var familia = await _repoFamilia.DObtenerRegistroAsync(request.IdFamilia.Value);
			var existeFamilia = familia != null;
			var subFamilia = await _repoSubfamilia.DObtenerRegistroAsync(request.IdSubfamilia.Value);
			var existeSubFamilia = familia != null;
			var perteneceSubFamiliaAFamilia = existeFamilia && existeSubFamilia && subFamilia.iIdFamilia == familia.iIdFamilia;
			var existeRequisicion = await _repoTipoAdquisicion.DExisteRegistroAsync(e => e.iIdTipoAdquisicion == request.IdTipoAdquisicion);
			var bien = await _repoBienPatrimonio.DObtenerRegistroAsync(e => e.iIdBien == request.IdBienPatrimonio);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existeFamilia) errores.Append("La Familia no se encuentra registrada,");
			if (!existeSubFamilia) errores.Append("La Subfamilia no se encuentra registrada,");
			if (!perteneceSubFamiliaAFamilia) errores.Append("La Subfamilia no pertenece a la Familia,");
			if (!existeRequisicion) errores.Append("La Requisicion no se encuentra registrada,");
			if (bien == null) errores.Append("El Bien Patrimonio no se encuentra registrado,");

			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteModificacionAsync(request, entidad, bien, subFamilia);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BCrearTramiteModificacionAsync(EntDetalleModificacionInmuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de modificacion");
			try
			{
				BValidarRequestModificacion(request);
				var detalleSolicitud = _mapper.Map<EntDetalleModificacionInmuebleRequest, EntDetalleSolicitud>(request);
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
					"Ocurrio un error al intentar crear el tramite de modificacion"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteModificacionAsync(long idDetalleSolicitud, EntDetalleModificacionInmuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteModificacionAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de modificacion");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleModificacion.DatoInmueble.DatosRegistral,
					e => e.DetalleModificacion.Solicitud
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

				detalleModificacion.sReferenciaConac = request.ReferenciaConac;
				detalleModificacion.iIdFamilia = request.IdFamilia.Value;
				detalleModificacion.iIdSubfamilia = request.IdSubfamilia.Value;
				detalleModificacion.DatoInmueble.sNomenclatura = request.Nomenclatura;
				detalleModificacion.sDescripcion = request.Descripcion;
				detalleModificacion.DatoInmueble.iIdTipoInmueble = request.IdTipoInmueble.Value;
				detalleModificacion.DatoInmueble.iIdUsoInmueble = request.IdUsoInmueble.Value;
				detalleModificacion.DatoInmueble.iIdTipoDomninio = request.IdTipoDominio.Value;
				detalleModificacion.iIdEstadoFisico = request.IdEstadoFisico.Value;
				detalleModificacion.DatoInmueble.iIdTipoAfectacion = request.IdTipoAfectacion.Value;
				detalleModificacion.DatoInmueble.sAfectante = request.Afectante;
				detalleModificacion.iIdTipoAdquisicion = request.IdTipoAdquisicion.Value;
				detalleModificacion.iIdMunicipio = request.IdMunicipio.Value;
				detalleModificacion.DatoInmueble.dValorHistorico = request.ValorHistorico.Value;
				detalleModificacion.DatoInmueble.dValorLibros = request.ValorLibros.Value;
				detalleModificacion.DatoInmueble.dDepreciacion = request.Depreciacion.Value;
				detalleModificacion.dPrecioUnitario = request.ValorTerreno.Value + request.ValorConstruccion.Value;
				detalleModificacion.iAniosVida = request.AniosVida.Value;

				detalleModificacion.dtFechaAdquisicion = request.FechaAdquisicion.Value;
				detalleModificacion.DatoInmueble.dtFechaAltaSistema = request.FechaAltaSistema.Value;

				detalleModificacion.DatoInmueble.DatosRegistral.iFolioCatastro = request.FolioCatastro.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.sCalle = request.Calle;
				detalleModificacion.DatoInmueble.DatosRegistral.dSuperficie = request.Superficie.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.dValorTerreno = request.ValorTerreno.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.sNumeroExterior = request.NumeroExterior;
				detalleModificacion.DatoInmueble.DatosRegistral.sNumeroInterior = request.NumeroInterior;
				detalleModificacion.DatoInmueble.DatosRegistral.sCruzamimiento1 = request.Cruzamiento1;
				detalleModificacion.DatoInmueble.DatosRegistral.sCruzamimiento2 = request.Cruzamiento2;
				detalleModificacion.DatoInmueble.DatosRegistral.dSuperficieContruccion = request.SuperficieConstruccion.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.sTablaje = request.Tablaje;
				detalleModificacion.DatoInmueble.DatosRegistral.dValorConstruccion = request.ValorConstruccion.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.dValorInicial = request.ValorTerreno.Value + request.ValorConstruccion.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.nCodigoPostal = request.CodigoPostal.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.iIdOrigenValor = request.IdOrigenValor.Value;
				detalleModificacion.DatoInmueble.DatosRegistral.sAsentamiento = request.Asentamiento;
				detalleModificacion.DatoInmueble.DatosRegistral.sPropietario = request.Propietario;

				detalleModificacion.sObservacionBien = request.ObservacionInmueble;
				detalleModificacion.sObservacionResponsable = request.ObservacionSupervicion;

				detalleModificacion.DatoInmueble.sPublicacion = request.DecretoPublicaicion;
				detalleModificacion.DatoInmueble.sExpediente = request.Expediente;
				detalleModificacion.DatoInmueble.sEscrituraTitulo = request.EscrituraTitulo;

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

		public async Task<EntityResponse<EntDetalleModificacionInmuebleResponse>> BObtenerTramiteModificacionAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteAltaAsync);
			var resultado = new EntityResponse<EntDetalleModificacionInmuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de modificacion");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleModificacionInmuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleModificacionInmuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de modificacion"
				);
			}

			return resultado;
		}

		private async Task BCompletarDatosTramiteBajaAsync(EntDetalleBajaInmuebleRequest request, EntBaja entidad)
		{
			await BCambiarEstadoBienes(entidad.sFolioBien, request.FolioBien);
		}

		private void BValidarRequestBaja(EntDetalleBajaInmuebleRequest request)
		{
			var resultadoValidacion = _validatorBaja.Validate(request);
			if (resultadoValidacion.IsValid) return;
			var errores = BusConvertirErrors.UFormatearTexto(resultadoValidacion.Errors);
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores);
		}

		private async Task BValidarRequestBajaBDAsync(EntDetalleBajaInmuebleRequest request, EntBaja entidad)
		{
			var existeSolicitud = await _repoSolicitud.DExisteRegistroAsync(e => e.iIdSolicitud == request.IdSolicitud);
			var existeBien = await _repoBienPatrimonio.DExisteRegistroAsync(e => e.iIdBien == request.IdBienPatrimonio);

			var errores = new StringBuilder(string.Empty);
			if (!existeSolicitud) errores.Append("La Solicitud no se encuentra registrada,");
			if (!existeBien) errores.Append("El bien no existen en el inventario,");
			string erroresConverter = errores.ToString();
			if (string.IsNullOrEmpty(erroresConverter))
			{
				await BCompletarDatosTramiteBajaAsync(request, entidad);
				return;
			};
			errores.Clear().Append(BusConvertirErrors.URemoverComillaFinal(erroresConverter));
			throw new BusRequestException(EntMensajeConstant.SolicitudIncorrecta, errores.ToString());

		}

		public async Task<EntityResponse<int>> BCrearTramiteBajaAsync(EntDetalleBajaInmuebleRequest request)
		{
			var nombreMetodo = nameof(BCrearTramiteBajaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para crear un tramite de baja");
			try
			{
				BValidarRequestBaja(request);
				var detalleSolicitud = _mapper.Map<EntDetalleBajaInmuebleRequest, EntDetalleSolicitud>(request);
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
					"Ocurrio un error al intentar crear el tramite de baja"
				);
			}

			return resultado;
		}

		public async Task<EntityResponse<int>> BActualizarTramiteBajaAsync(long idDetalleSolicitud, EntDetalleBajaInmuebleRequest request)
		{
			var nombreMetodo = nameof(BActualizarTramiteAltaAsync);
			var resultado = new EntityResponse<int>();
			await using var transaction = await _repoDetalleSolicitud.DBeginTransactionAsync();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para actualizar un tramite de baja");
			try
			{
				var includes = new List<Expression<Func<EntDetalleSolicitud, object>>>()
				{
					e => e.DetalleBaja.BajaInmueble,
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

				var bajaInmueble = detalleSolicitud.DetalleBaja.BajaInmueble;
				bajaInmueble.iIdBien = request.IdBienPatrimonio.Value;
				bajaInmueble.sDestinoBien = request.DestinoBien;
				bajaInmueble.sJustificacion = request.JustificacionBaja;
				bajaInmueble.dtFechaBaja = request.FechaBaja.Value;
				bajaInmueble.dtFechaBajaSistema = request.FechaBajaSistema.Value;
				bajaInmueble.dtFechaDesincorporacion = request.FechaDesincorporacion.Value;
				bajaInmueble.dValorBaja = request.ValorBaja.Value;
				bajaInmueble.sAfavorDe = request.AFavor;
				bajaInmueble.sEscrituraTitulo = request.EscrituraTitulo;

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

		public async Task<EntityResponse<EntDetalleBajaInmuebleResponse>> BObtenerTramiteBajaAsync(long idDetalleSolicitud)
		{
			var nombreMetodo = nameof(BObtenerTramiteAltaAsync);
			var resultado = new EntityResponse<EntDetalleBajaInmuebleResponse>();

			_logger.LogInformation($"{(long)_code}: Inicia la operacion para consultar el tramite de baja");
			try
			{
				var responseDto = await _repoDetalleSolicitud.DObtenerProyeccionElementoAsync<EntDetalleBajaInmuebleResponse>(e => e.iIdDetalleSolicitud == idDetalleSolicitud)
					?? throw new BusRecursoNoEncontradoException(EntMensajeConstant.NoEncontrado);
				resultado.Success(responseDto, _code);
			}
			catch (Exception ex)
			{
				resultado = BusExceptionHandler.Handle<EntDetalleBajaInmuebleResponse>(
					_logger,
					ex,
					_codeError,
					nombreMetodo,
					"Ocurrio un error al intentar consultar el tramite de baja"
				);
			}

			return resultado;
		}
	}
}
