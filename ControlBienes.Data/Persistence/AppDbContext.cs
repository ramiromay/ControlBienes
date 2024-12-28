using System;
using System.Collections.Generic;
using ControlBienes.Business.Configuracion;
using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Catalogos;
using ControlBienes.Entities.Catalogos.CaracteristicaBien;
using ControlBienes.Entities.Catalogos.CentroTrabajo;
using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.Catalogos.ClaseVehicular;
using ControlBienes.Entities.Catalogos.ClaveVehicular;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.CombustibleVehicular;
using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Catalogos.EstadoFisico;
using ControlBienes.Entities.Catalogos.EstadoGeneral;
using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.LineaVehicular;
using ControlBienes.Entities.Catalogos.Marca;
using ControlBienes.Entities.Catalogos.OrigenValor;
using ControlBienes.Entities.Catalogos.Resguardante;
using ControlBienes.Entities.Catalogos.Subfamilia;
using ControlBienes.Entities.Catalogos.TipoAdquisicion;
using ControlBienes.Entities.Catalogos.TipoAfectacion;
using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Catalogos.TipoInmueble;
using ControlBienes.Entities.Catalogos.TipoVehicular;
using ControlBienes.Entities.Catalogos.Titular;
using ControlBienes.Entities.Catalogos.Turno;
using ControlBienes.Entities.Catalogos.Ubicacion;
using ControlBienes.Entities.Catalogos.UsoInmueble;
using ControlBienes.Entities.Catalogos.VersionVehicular;
using ControlBienes.Entities.General.BMS;
using ControlBienes.Entities.General.Cuenta;
using ControlBienes.Entities.General.Municipio;
using ControlBienes.Entities.General.Nacionalidad;
using ControlBienes.Entities.General.Nombramiento;
using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.General.TipoNivel;
using ControlBienes.Entities.General.TipoResponsable;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Afectacion;
using ControlBienes.Entities.Patrimonio.Alta;
using ControlBienes.Entities.Patrimonio.Baja;
using ControlBienes.Entities.Patrimonio.BajaInmueble;
using ControlBienes.Entities.Patrimonio.Bien;
using ControlBienes.Entities.Patrimonio.DatoGeneral;
using ControlBienes.Entities.Patrimonio.DatoInmueble;
using ControlBienes.Entities.Patrimonio.DatoRegistral;
using ControlBienes.Entities.Patrimonio.DatoVehicular;
using ControlBienes.Entities.Patrimonio.Depreciacion;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using ControlBienes.Entities.Patrimonio.Factura;
using ControlBienes.Entities.Patrimonio.Historial;
using ControlBienes.Entities.Patrimonio.Licitacion;
using ControlBienes.Entities.Patrimonio.Modificacion;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.Movimiento;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Patrimonio.TipoBienImueble;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Seguridad.Empleado;
using ControlBienes.Entities.Seguridad.Permiso;
using ControlBienes.Entities.Seguridad.Persona;
using ControlBienes.Entities.Seguridad.Rol;
using ControlBienes.Entities.Seguridad.RolPermiso;
using ControlBienes.Entities.Seguridad.Usuario;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using ControlBienes.Entities.Seguridad.UsuarioRol;
using ControlBienes.Entities.Sistema.Catalogo;
using ControlBienes.Entities.Sistema.ColumnaTabla;
using ControlBienes.Entities.Sistema.Modulo;
using ControlBienes.Entities.Sistema.Seccion;
using ControlBienes.Entities.Sistema.SubModulo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlBienes.Data.Persistence;

public partial class AppDbContext : IdentityDbContext<
        EntUsuario, EntRol, long,
        IdentityUserClaim<long>, EntUsuarioRol, IdentityUserLogin<long>,
        IdentityRoleClaim<long>, IdentityUserToken<long>>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EntAfectacion> Afectaciones { get; set; }

    public virtual DbSet<EntAlmacen> Almacenes { get; set; }

    public virtual DbSet<EntAnaquel> Anaqueles { get; set; }

    public virtual DbSet<EntBaja> Bajas { get; set; }

    public virtual DbSet<EntBajaInmueble> BajasInmuebles { get; set; }

    public virtual DbSet<EntBienAlmacen> Bienes { get; set; }

    public virtual DbSet<EntrBienPatrimonio> Bienes1 { get; set; }

    public virtual DbSet<EntBms> Bms { get; set; }

    public virtual DbSet<EntCaracteristicaBien> CaracteristicasBienes { get; set; }

    public virtual DbSet<EntCatalogo> Catalogos { get; set; }

    public virtual DbSet<EntCentroTrabajoTurno> CentroTrabajoTurnos { get; set; }

    public virtual DbSet<EntCentroTrabajo> CentrosTrabajos { get; set; }

    public virtual DbSet<EntClaseVehicular> ClasesVehiculares { get; set; }

    public virtual DbSet<EntClaveVehicular> ClavesVehiculares { get; set; }

    public virtual DbSet<EntColor> Colores { get; set; }

    public virtual DbSet<EntColumnasTabla> ColumnasTablas { get; set; }

    public virtual DbSet<EntCombustibleVehicular> CombustiblesVehiculares { get; set; }

    public virtual DbSet<EntConceptoMovimiento> ConceptosMovimientos { get; set; }

    public virtual DbSet<EntCuenta> Cuentas { get; set; }

    public virtual DbSet<EntDatoGeneral> DatosGenerales { get; set; }

    public virtual DbSet<EntDatoInmueble> DatosInmuebles { get; set; }

    public virtual DbSet<EntDatoRegistral> DatosRegistrales { get; set; }

    public virtual DbSet<EntDatoVehicular> DatosVehiculares { get; set; }

    public virtual DbSet<EntDepreciacion> Depreciaciones { get; set; }

    public virtual DbSet<EntDetalleAlta> DetallesAltas { get; set; }

    public virtual DbSet<EntDetalleBaja> DetallesBajas { get; set; }

    public virtual DbSet<EntDetalleDesincorporacion> DetallesDesincorporaciones { get; set; }

    public virtual DbSet<EntDetalleDestinoFinal> DetallesDestinoFinales { get; set; }

    public virtual DbSet<EntDetalleDestruccion> DetallesDestrucciones { get; set; }

    public virtual DbSet<EntDetalleEnagenacion> DetallesEnagenaciones { get; set; }

    public virtual DbSet<EntDetalleModificacion> DetallesModificaciones { get; set; }

    public virtual DbSet<EntDetalleMovimiento> DetallesMovimientos { get; set; }

    public virtual DbSet<EntDetalleSolicitud> DetallesSolicitudes { get; set; }

    public virtual DbSet<EntDocumento> Documentos { get; set; }

    public virtual DbSet<EntEmpleado> Empleados { get; set; }

    public virtual DbSet<EntEstadoFisico> EstadosFisicos { get; set; }

    public virtual DbSet<EntEstadoGeneral> EstadosGenerales { get; set; }

    public virtual DbSet<EntEtapa> Etapas { get; set; }

    public virtual DbSet<EntEtapaTramite> EtapasTramites { get; set; }

    public virtual DbSet<EntFactura> Facturas { get; set; }

    public virtual DbSet<EntFamilia> Familias { get; set; }

    public virtual DbSet<EntFuenteFinanciamiento> FuentesFinanciamientos { get; set; }

    public virtual DbSet<EntHistorial> Historiales { get; set; }

    public virtual DbSet<EntLicitacion> Licitaciones { get; set; }

    public virtual DbSet<EntLineaVehicular> LineasVehiculares { get; set; }

    public virtual DbSet<EntMarca> Marcas { get; set; }

    public virtual DbSet<EntMetodoAdquisicion> MetodosAdquisicions { get; set; }

    public virtual DbSet<EntMetodoCosteo> MetodosCosteos { get; set; }

    public virtual DbSet<EntModulo> Modulos { get; set; }

    public virtual DbSet<EntMotivoTramite> MotivosTramites { get; set; }

    public virtual DbSet<EntMovimiento> Movimientos { get; set; }

    public virtual DbSet<EntMovimientoBien> MovimientosBienes { get; set; }

    public virtual DbSet<EntMunicipio> Municipios { get; set; }

    public virtual DbSet<EntNacionalidad> Nacionalidades { get; set; }

    public virtual DbSet<EntNombramiento> Nombramientos { get; set; }

    public virtual DbSet<EntOrigenValor> OrigenesValores { get; set; }

    public virtual DbSet<EntPeriodo> Periodos { get; set; }

    public virtual DbSet<EntPermiso> Permisos { get; set; }

    public virtual DbSet<EntPersona> Personas { get; set; }

    public virtual DbSet<EntProgramasOperativo> ProgramasOperativos { get; set; }

    public virtual DbSet<EntProveedor> Proveedores { get; set; }

    public virtual DbSet<EntResguardante> Resguardantes { get; set; }

    public virtual DbSet<EntRol> Roles { get; set; }

    public virtual DbSet<EntRolPermiso> RolesPermisos { get; set; }

    public virtual DbSet<EntSeccion> Secciones { get; set; }

    public virtual DbSet<EntSeguimiento> Seguimientos { get; set; }

    public virtual DbSet<EntSolicitud> Solicitudes { get; set; }

    public virtual DbSet<EntSubModulo> SubModulos { get; set; }

    public virtual DbSet<EntSubfamilia> Subfamilias { get; set; }

    public virtual DbSet<EntTipoAdquisicion> TiposAdquisiciones { get; set; }

    public virtual DbSet<EntTipoAfectacion> TiposAfectaciones { get; set; }

    public virtual DbSet<EntTipoBien> TiposBienes { get; set; }

    public virtual DbSet<EntTipoBienInmueble> TiposBienesInmuebles { get; set; }

    public virtual DbSet<EntTipoDominio> TiposDominios { get; set; }

    public virtual DbSet<EntTipoInmueble> TiposInmuebles { get; set; }

    public virtual DbSet<EntTipoMovimiento> TiposMovimientos { get; set; }

    public virtual DbSet<EntTipoNivel> TiposNiveles { get; set; }

    public virtual DbSet<EntTipoResponsable> TiposResponsables { get; set; }

    public virtual DbSet<EntTipoTramite> TiposTramites { get; set; }

    public virtual DbSet<EntTipoVehicular> TiposVehiculares { get; set; }

    public virtual DbSet<EntTitular> Titulares { get; set; }

    public virtual DbSet<EntTurno> Turnos { get; set; }

    public virtual DbSet<EntUbicacion> Ubicaciones { get; set; }

    public virtual DbSet<EntUnidadAdministrativa> UnidadesAdministrativas { get; set; }

    public virtual DbSet<EntUsoInmueble> UsosInmuebles { get; set; }

    public virtual DbSet<EntUsuario> Usuarios { get; set; }

    public virtual DbSet<EntUsuarioPermiso> UsuariosPermisos { get; set; }

    public virtual DbSet<EntUsuarioRol> UsuariosRoles { get; set; }

    public virtual DbSet<EntVersionVehicular> VersionesVehiculares { get; set; }

    public virtual DbSet<EntZona> Zonas { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        DateTime fechaActual = DateTime.Now;
        foreach (var entry in ChangeTracker.Entries<EntRegistroGenerico>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.dtFechaCreacion = fechaActual;
                    entry.Entity.dtFechaModificacion = fechaActual;
                    break;
                case EntityState.Modified:
                    entry.Entity.dtFechaModificacion = fechaActual;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntAfectacion>(entity =>
        {
            entity.HasKey(e => e.iIdAfectacion).HasName("PK__Afectaci__3330A390631BB483");

            entity.ToTable("Afectaciones", "Patrimonio");

            entity.Property(e => e.iIdAfectacion).HasColumnName("iIdAfectacion");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntAlmacen>(entity =>
        {
            entity.HasKey(e => e.iIdAlmacen).HasName("PK__Almacene__7D1F7ADE0C6F6157");

            entity.ToTable("Almacenes", "Catalogo");

            entity.Property(e => e.iIdAlmacen).HasColumnName("iIdAlmacen");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdCuenta).HasColumnName("iIdCuenta");
            entity.Property(e => e.iIdEmpleado).HasColumnName("iIdEmpleado");
            entity.Property(e => e.iIdMetodoCosteo).HasColumnName("iIdMetodoCosteo");
            entity.Property(e => e.iIdPeriodo).HasColumnName("iIdPeriodo");
            entity.Property(e => e.sDireccion)
                .IsRequired()
                .HasColumnName("sDireccion");
            entity.Property(e => e.sFolioEntrada)
                .HasMaxLength(50)
                .HasColumnName("sFolioEntrada");
            entity.Property(e => e.sFolioSalida)
                .HasMaxLength(50)
                .HasColumnName("sFolioSalida");
            entity.Property(e => e.sHorario)
                .IsRequired()
                .HasColumnName("sHorario");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Cuenta).WithMany(p => p.Almacenes)
                .HasForeignKey(d => d.iIdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacenes_iIdCuenta");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Almacenes)
                .HasForeignKey(d => d.iIdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacenes_iIdEmpleado");

            entity.HasOne(d => d.MetodoCosteo).WithMany(p => p.Almacenes)
                .HasForeignKey(d => d.iIdMetodoCosteo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacenes_iIdMetodoCosteo");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Almacenes)
                .HasForeignKey(d => d.iIdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Almacenes_iIdPeriodo");
        });

        modelBuilder.Entity<EntAnaquel>(entity =>
        {
            entity.HasKey(e => e.iIdAnaquel).HasName("PK__Anaquele__9358EDDE0ED56108");

            entity.ToTable("Anaqueles", "Catalogo");

            entity.Property(e => e.iIdAnaquel).HasColumnName("iIdAnaquel");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdAlmacen).HasColumnName("iIdAlmacen");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Anaqueles)
                .HasForeignKey(d => d.iIdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Anaqueles_iIdAlmacen");
        });

        modelBuilder.Entity<EntBaja>(entity =>
        {
            entity.HasKey(e => e.iIdBaja).HasName("PK__Bajas__25A062524CB5A5B4");

            entity.ToTable("Bajas", "Patrimonio");

            entity.Property(e => e.iIdBaja).HasColumnName("iIdBaja");
            entity.Property(e => e.dtFehaDocumento)
                .HasColumnType("date")
                .HasColumnName("dtFehaDocumento");
            entity.Property(e => e.iIdEmpleado).HasColumnName("iIdEmpleado");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.sFolioBien)
                .IsRequired()
                .HasColumnName("sFolioBien");
            entity.Property(e => e.sFolioDictamen)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("sFolioDictamen");
            entity.Property(e => e.sListaDocunetario).HasColumnName("sListaDocunetario");
            entity.Property(e => e.sLugarResguardo)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sLugarResguardo");
            entity.Property(e => e.sNombreSolicitante)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombreSolicitante");
            entity.Property(e => e.sObservaciones).HasColumnName("sObservaciones");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Bajas)
                .HasForeignKey(d => d.iIdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bajas_iIdEmpleado");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.Bajas)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bajas_iIdTipoBien");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.Bajas)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bajas_iIdUnidadAdministrativa");
        });

        modelBuilder.Entity<EntBajaInmueble>(entity =>
        {
            entity.HasKey(e => e.iIdBajaInmueble).HasName("PK__BajasInm__CD4F675026AD28D3");

            entity.ToTable("BajasInmuebles", "Patrimonio");

            entity.Property(e => e.iIdBajaInmueble).HasColumnName("iIdBajaInmueble");
            entity.Property(e => e.dValorBaja).HasColumnName("dValorBaja");
            entity.Property(e => e.dValorBienPermutadoConstruccion).HasColumnName("dValorBienPermutadoConstruccion");
            entity.Property(e => e.dValorBienPermutadoTerreno).HasColumnName("dValorBienPermutadoTerreno");
            entity.Property(e => e.dtFechaBaja)
                .HasColumnType("date")
                .HasColumnName("dtFechaBaja");
            entity.Property(e => e.dtFechaBajaSistema)
                .HasColumnType("date")
                .HasColumnName("dtFechaBajaSistema");
            entity.Property(e => e.dtFechaDesincorporacion)
                .HasColumnType("date")
                .HasColumnName("dtFechaDesincorporacion");
            entity.Property(e => e.dtFechaDonacion)
                .HasColumnType("date")
                .HasColumnName("dtFechaDonacion");
            entity.Property(e => e.dtFechaPermuta)
                .HasColumnType("date")
                .HasColumnName("dtFechaPermuta");
            entity.Property(e => e.dtFechaUnion)
                .HasColumnType("date")
                .HasColumnName("dtFechaUnion");
            entity.Property(e => e.iFolioElectronico).HasColumnName("iFolioElectronico");
            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
            entity.Property(e => e.iIdTipoDomninio).HasColumnName("iIdTipoDomninio");
            entity.Property(e => e.iIdTipoInmueble).HasColumnName("iIdTipoInmueble");
            entity.Property(e => e.iIdUsoInmueble).HasColumnName("iIdUsoInmueble");
            entity.Property(e => e.sAfavorDe)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sAFavorDe");
            entity.Property(e => e.sAvaluo1)
                .HasMaxLength(255)
                .HasColumnName("sAvaluo1");
            entity.Property(e => e.sAvaluo2)
                .HasMaxLength(255)
                .HasColumnName("sAvaluo2");
            entity.Property(e => e.sClaveCatastral)
                .HasMaxLength(50)
                .HasColumnName("sClaveCatastral");
            entity.Property(e => e.sDecretoPublicacion)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sDecretoPublicacion");
            entity.Property(e => e.sDecretoPublicacionDonacion)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sDecretoPublicacionDonacion");
            entity.Property(e => e.sDestinoBien).HasColumnName("sDestinoBien");
            entity.Property(e => e.sDonatario)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sDonatario");
            entity.Property(e => e.sEscrituraTitulo)
                .HasMaxLength(255)
                .HasColumnName("sEscrituraTitulo");
            entity.Property(e => e.sExpedienteUnion)
                .HasMaxLength(255)
                .HasColumnName("sExpedienteUnion");
            entity.Property(e => e.sInmueblePermutado)
                .HasMaxLength(255)
                .HasColumnName("sInmueblePermutado");
            entity.Property(e => e.sJustificacion).HasColumnName("sJustificacion");
            entity.Property(e => e.sObservacion)
                .IsRequired()
                .HasColumnName("sObservacion");
            entity.Property(e => e.sReferencaPoliza).HasColumnName("sReferencaPoliza");
            entity.Property(e => e.sRepositario)
                .HasMaxLength(255)
                .HasColumnName("sRepositario");

            entity.HasOne(d => d.Bien).WithMany(p => p.BajasInmuebles)
                .HasForeignKey(d => d.iIdBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BajasInmuebles_iIdBien");

            entity.HasOne(d => d.TiposDominio).WithMany(p => p.BajasInmuebles)
                .HasForeignKey(d => d.iIdTipoDomninio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BajasInmuebles_iIdTipoDomninio");

            entity.HasOne(d => d.TipoInmueble).WithMany(p => p.BajasInmuebles)
                .HasForeignKey(d => d.iIdTipoInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BajasInmuebles_iIdTipoInmueble");

            entity.HasOne(d => d.UsoInmueble).WithMany(p => p.BajasInmuebles)
                .HasForeignKey(d => d.iIdUsoInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BajasInmuebles_iIdUsoInmueble");
        });

        modelBuilder.Entity<EntBienAlmacen>(entity =>
        {
            entity.HasKey(e => e.iIdBien).HasName("PK__Bienes__23B12AED43C1BB2C");

            entity.ToTable("Bienes", "Almacen");

            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iExistencia).HasColumnName("iExistencia");
            entity.Property(e => e.iIdAlmacen).HasColumnName("iIdAlmacen");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdSubfamilia).HasColumnName("iIdSubfamilia");
            entity.Property(e => e.nCodigoArmonizado)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("nCodigoArmonizado");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sUnidadMedida)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sUnidadMedida");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Bienes)
                .HasForeignKey(d => d.iIdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlmacenBienes_iIdAlmacen");

            entity.HasOne(d => d.Familia).WithMany(p => p.BienesAlmacen)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlmacenBienes_iIdFamilia");

            entity.HasOne(d => d.Subfamilia).WithMany(p => p.BienesAlmacen)
                .HasForeignKey(d => d.iIdSubfamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlmacenBienes_iIdSubfamilia");
        });

        modelBuilder.Entity<EntrBienPatrimonio>(entity =>
        {
            entity.HasKey(e => e.iIdBien).HasName("PK__Bienes__23B12AEDCBFD51DE");

            entity.ToTable("Bienes", "Patrimonio");

            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
            entity.Property(e => e.bDeprecia)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("bDeprecia");
            entity.Property(e => e.dPrecioDepreciado).HasColumnName("dPrecioDepreciado");
            entity.Property(e => e.dPrecioDesechable).HasColumnName("dPrecioDesechable");
            entity.Property(e => e.dPrecioUnitario).HasColumnName("dPrecioUnitario");
            entity.Property(e => e.dtFechaAdquisicion)
                .HasColumnType("date")
                .HasColumnName("dtFechaAdquisicion");
            entity.Property(e => e.dtFechaAlta)
                .HasColumnType("date")
                .HasColumnName("dtFechaAlta");
            entity.Property(e => e.dtFechaBaja)
                .HasColumnType("date")
                .HasColumnName("dtFechaBaja");
            entity.Property(e => e.dtFechaInicioUso)
                .HasColumnType("date")
                .HasColumnName("dtFechaInicioUso");
            entity.Property(e => e.iAniosVida).HasColumnName("iAniosVida");
            entity.Property(e => e.iIdBms).HasColumnName("iIdBMS");
            entity.Property(e => e.iIdEstadoFisico).HasColumnName("iIdEstadoFisico");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdMunicipio).HasColumnName("iIdMunicipio");
            entity.Property(e => e.iIdPeriodo).HasColumnName("iIdPeriodo");
            entity.Property(e => e.iIdSubfamilia).HasColumnName("iIdSubfamilia");
            entity.Property(e => e.iIdTipoAdquisicion).HasColumnName("iIdTipoAdquisicion");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUbicacion).HasColumnName("iIdUbicacion");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.iIdDatoInmueble).HasColumnName("idDatoInmueble");
            entity.Property(e => e.sCaracteristicas).HasColumnName("sCaracteristicas");
            entity.Property(e => e.sCuentaActivo)
                .HasMaxLength(50)
                .HasColumnName("sCuentaActivo");
            entity.Property(e => e.sCuentaActualizacion)
                .HasMaxLength(50)
                .HasColumnName("sCuentaActualizacion");
            entity.Property(e => e.sCuentaPorPagar).HasColumnName("sCuentaPorPagar");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sFolioAnterior)
                .HasMaxLength(10)
                .HasColumnName("sFolioAnterior");
            entity.Property(e => e.sFolioBien).HasColumnName("sFolioBien");
            entity.Property(e => e.sMotivoBaja).HasColumnName("sMotivoBaja");
            entity.Property(e => e.sNoSeries).HasColumnName("sNoSeries");
            entity.Property(e => e.sObservacionBien).HasColumnName("sObservacionBien");
            entity.Property(e => e.sObservacionResponsable).HasColumnName("sObservacionResponsable");
            entity.Property(e => e.sOrdenCompra).HasColumnName("sOrdenCompra");
            entity.Property(e => e.sPartidaEspecifica)
                .HasMaxLength(50)
                .HasColumnName("sPartidaEspecifica");
            entity.Property(e => e.sReferenciaConac)
                .HasMaxLength(50)
                .HasColumnName("sReferenciaCONAC");
            entity.Property(e => e.sRequisicion).HasColumnName("sRequisicion");
            entity.Property(e => e.sResguardantes).HasColumnName("sResguardantes");
            entity.Property(e => e.sSustituyeBv)
                .HasMaxLength(50)
                .HasColumnName("sSustituyeBV");

            entity.HasOne(d => d.Bms).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdBms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdBMS");

            entity.HasOne(d => d.EstadoFisico).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdEstadoFisico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdEstadoFisico");

            entity.HasOne(d => d.Familia).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdFamilia");

            entity.HasOne(d => d.Municipio).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdMunicipio");

            entity.HasOne(d => d.Periodo).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdPeriodo");

            entity.HasOne(d => d.Subfamilia).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdSubfamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdSubfamilia");

            entity.HasOne(d => d.TipoAdquisicion).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdTipoAdquisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdTipoAdquisicion");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdTipoBien");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdUbicacion");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bienes_iIdUnidadAdministrativa");

            entity.HasOne(d => d.DatoInmueble).WithMany(p => p.BienesPatrimonio)
                .HasForeignKey(d => d.iIdDatoInmueble)
                .HasConstraintName("FK_Bienes_iIdDatoInmueble");
        });

        modelBuilder.Entity<EntBms>(entity =>
        {
            entity.HasKey(e => e.iIdBms).HasName("PK__BMS__9B045F82B0BD58EE");

            entity.ToTable("BMS", "General");

            entity.Property(e => e.iIdBms).HasColumnName("iIdBMS");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dPrecioUnitario).HasColumnName("dPrecioUnitario");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iCantidad).HasColumnName("iCantidad");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdSubfamilia).HasColumnName("iIdSubfamilia");
            entity.Property(e => e.nCodigoArmonizado)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("nCodigoArmonizado");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
            entity.Property(e => e.sUnidadMedida)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sUnidadMedida");

            entity.HasOne(d => d.Familia).WithMany(p => p.Bms)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BMS_iIdFamilia");

            entity.HasOne(d => d.Subfamilia).WithMany(p => p.Bms)
                .HasForeignKey(d => d.iIdSubfamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BMS_iIdSubfamilia");
        });

        modelBuilder.Entity<EntCaracteristicaBien>(entity =>
        {
            entity.HasKey(e => e.iIdCaracteristicaBien).HasName("PK__Caracter__0B130FBBE56A08AC");

            entity.ToTable("CaracteristicasBienes", "Catalogo");

            entity.Property(e => e.iIdCaracteristicaBien).HasColumnName("iIdCaracteristicaBien");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdSubfamilia).HasColumnName("iIdSubfamilia");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sEtiqueta)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sEtiqueta");

            entity.HasOne(d => d.Familia).WithMany(p => p.CaracteristicasBienes)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CaracteristicasBienes_iIdFamilia");

            entity.HasOne(d => d.Subfamilia).WithMany(p => p.CaracteristicasBienes)
                .HasForeignKey(d => d.iIdSubfamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CaracteristicasBienes_iIdSubfamilia");
        });

        modelBuilder.Entity<EntCatalogo>(entity =>
        {
            entity.HasKey(e => e.iIdCatalogo).HasName("PK__Catalogo__22F71DB45F46ABBC");

            entity.ToTable("Catalogos", "Sistema");

            entity.Property(e => e.iIdCatalogo).HasColumnName("iIdCatalogo");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdModulo).HasColumnName("iIdModulo");
            entity.Property(e => e.iIdPermiso).HasColumnName("iIdPermiso");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Catalogos)
                .HasForeignKey(d => d.iIdModulo)
                .HasConstraintName("FK_Catalogos_iIdModulo");

            entity.HasOne(d => d.Permiso).WithMany(p => p.Catalogos)
                .HasForeignKey(d => d.iIdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catalogos_iIdPermiso");
        });

        modelBuilder.Entity<EntCentroTrabajoTurno>(entity =>
        {
            entity.HasKey(e => e.iIdCentroTrabajoTurno).HasName("PK__CentroTr__1F85847BFFD732F9");

            entity.ToTable("CentroTrabajoTurnos", "Catalogo");

            entity.Property(e => e.iIdCentroTrabajoTurno).HasColumnName("iIdCentroTrabajoTurno");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdCentroTrabajo).HasColumnName("iIdCentroTrabajo");
            entity.Property(e => e.iIdTurno).HasColumnName("iIdTurno");

            entity.HasOne(d => d.CentroTrabajo).WithMany(p => p.CentroTrabajoTurnos)
                .HasForeignKey(d => d.iIdCentroTrabajo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CentroTrabajoTurnos_iIdCentrosTrabajo");

            entity.HasOne(d => d.Turno).WithMany(p => p.CentroTrabajoTurnos)
                .HasForeignKey(d => d.iIdTurno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CentroTrabajoTurnos_iIdTurno");
        });

        modelBuilder.Entity<EntCentroTrabajo>(entity =>
        {
            entity.HasKey(e => e.iIdCentroTrabajo).HasName("PK__CentrosT__B9EC0BA036364F32");

            entity.ToTable("CentrosTrabajo", "Catalogo");

            entity.Property(e => e.iIdCentroTrabajo).HasColumnName("iIdCentroTrabajo");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdMunicipio).HasColumnName("iIdMunicipio");
            entity.Property(e => e.iIdPeriodo).HasColumnName("iIdPeriodo");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.sClave)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("sClave");
            entity.Property(e => e.sDireccion)
                .IsRequired()
                .HasColumnName("sDireccion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Municipio).WithMany(p => p.CentrosTrabajos)
                .HasForeignKey(d => d.iIdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CentrosTrabajo_iIdMunicipio");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.CentrosTrabajos)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CentrosTrabajo_iIdUnidadesAdministrativas");
        });

        modelBuilder.Entity<EntClaseVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdClaseVehicular).HasName("PK__ClasesVe__99F76CB244AFF5AF");

            entity.ToTable("ClasesVehiculares", "Catalogo");

            entity.Property(e => e.iIdClaseVehicular).HasColumnName("iIdClaseVehicular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntClaveVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdClaveVehicular).HasName("PK__ClavesVe__7D9FC51A2925E926");

            entity.ToTable("ClavesVehiculares", "Catalogo");

            entity.Property(e => e.iIdClaveVehicular).HasColumnName("iIdClaveVehicular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntColor>(entity =>
        {
            entity.HasKey(e => e.iIdColor).HasName("PK__Colores__C17DA53921018504");

            entity.ToTable("Colores", "Catalogo");

            entity.Property(e => e.iIdColor).HasColumnName("iIdColor");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sCodigoRGB)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("sCodigoRGB");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntColumnasTabla>(entity =>
        {
            entity.HasKey(e => e.iIdColumnaTabla).HasName("PK__Columnas__2C76C9E53F8A3CC5");

            entity.ToTable("ColumnasTablas", "Sistema");

            entity.Property(e => e.iIdColumnaTabla).HasColumnName("iIdColumnaTabla");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdCatalogo).HasColumnName("iIdCatalogo");
            entity.Property(e => e.iIdSubModulo).HasColumnName("iIdSubModulo");
            entity.Property(e => e.iTamanio).HasColumnName("iTamanio");
            entity.Property(e => e.sClave)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sClave");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
            entity.Property(e => e.sTipoDato)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sTipoDato");

            entity.HasOne(d => d.Catalogo).WithMany(p => p.ColumnasTablas)
                .HasForeignKey(d => d.iIdCatalogo)
                .HasConstraintName("FK_ColumnasTablas_iIdCatalogo");

            entity.HasOne(d => d.SubModulo).WithMany(p => p.ColumnasTablas)
                .HasForeignKey(d => d.iIdSubModulo)
                .HasConstraintName("FK_ColumnasTablas_iIdSubmodulo");
        });

        modelBuilder.Entity<EntCombustibleVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdCombustibleVehicular).HasName("PK__Combusti__C91CB5FD7C1B0D1F");

            entity.ToTable("CombustiblesVehiculares", "Catalogo");

            entity.Property(e => e.iIdCombustibleVehicular).HasColumnName("iIdCombustibleVehicular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntConceptoMovimiento>(entity =>
        {
            entity.HasKey(e => e.iIdConceptoMovimiento).HasName("PK__Concepto__80B8460FC399087C");

            entity.ToTable("ConceptosMovimientos", "Catalogo");

            entity.Property(e => e.iIdConceptoMovimiento).HasColumnName("iIdConceptoMovimiento");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdTipoMovimiento).HasColumnName("iIdTipoMovimiento");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.ConceptosMovimientos)
                .HasForeignKey(d => d.iIdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConceptosMovimientos_iIdTipoMovimiento");
        });

        modelBuilder.Entity<EntCuenta>(entity =>
        {
            entity.HasKey(e => e.iIdCuenta).HasName("PK__Cuentas__E3924335583874CA");

            entity.ToTable("Cuentas", "General");

            entity.Property(e => e.iIdCuenta).HasColumnName("iIdCuenta");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iNivel).HasColumnName("iNivel");
            entity.Property(e => e.sClave)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("sClave");
            entity.Property(e => e.sNivelCompleto)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("sNivelCompleto");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntDatoGeneral>(entity =>
        {
            entity.HasKey(e => e.iIdDatoGeneral).HasName("PK__DatosGen__D07A5446D92CD2B9");

            entity.ToTable("DatosGenerales", "Patrimonio");

            entity.Property(e => e.iIdDatoGeneral).HasColumnName("iIdDatoGeneral");
            entity.Property(e => e.iIdClaseVehicular).HasColumnName("iIdClaseVehicular");
            entity.Property(e => e.iIdClaveVehicular).HasColumnName("iIdClaveVehicular");
            entity.Property(e => e.iIdColor).HasColumnName("iIdColor");
            entity.Property(e => e.iIdCombustibleVehicular).HasColumnName("iIdCombustibleVehicular");
            entity.Property(e => e.iIdLineaVehicular).HasColumnName("iIdLineaVehicular");
            entity.Property(e => e.iIdMarca).HasColumnName("iIdMarca");
            entity.Property(e => e.iIdTipoVehicular).HasColumnName("iIdTipoVehicular");
            entity.Property(e => e.iIdVersionVehicular).HasColumnName("iIdVersionVehicular");

            entity.HasOne(d => d.ClaseVehicular).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdClaseVehicular)
                .HasConstraintName("FK_DatosGenerales_iIdClaseVehicular");

            entity.HasOne(d => d.ClaveVehicular).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdClaveVehicular)
                .HasConstraintName("FK_DatosGenerales_iIdClaveVehicular");

            entity.HasOne(d => d.Color).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdColor)
                .HasConstraintName("FK_DatosGenerales_iIdColor");

            entity.HasOne(d => d.CombustibleVehicular).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdCombustibleVehicular)
                .HasConstraintName("FK_DatosGenerales_iIdCombustibleVehicular");

            entity.HasOne(d => d.LineaVehicular).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdLineaVehicular)
                .HasConstraintName("FK_DatosGenerales_iIdLineaVehicular");

            entity.HasOne(d => d.Marca).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdMarca)
                .HasConstraintName("FK_DatosGenerales_iIdMarca");

            entity.HasOne(d => d.TipoVehicular).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdTipoVehicular)
                .HasConstraintName("FK_DatosGenerales_iIdTipoVehicular");

            entity.HasOne(d => d.VersionVehicular).WithMany(p => p.DatosGenerales)
                .HasForeignKey(d => d.iIdVersionVehicular)
                .HasConstraintName("FK_DatosGenerales_iIdVersionVehicular");
        });

        modelBuilder.Entity<EntDatoInmueble>(entity =>
        {
            entity.HasKey(e => e.iIdDatoInmueble).HasName("PK__DatosInm__6775C0745F38E0DB");

            entity.ToTable("DatosInmuebles", "Patrimonio");

            entity.Property(e => e.iIdDatoInmueble).HasColumnName("iIdDatoInmueble");
            entity.Property(e => e.dtFechaAltaSistema)
                .HasColumnType("date")
                .HasColumnName("dtFechaAltaSistema");
            entity.Property(e => e.iIdDatoRegistral).HasColumnName("iIdDatoRegistral");
            entity.Property(e => e.iIdEstadoGeneral).HasColumnName("iIdEstadoGeneral");
            entity.Property(e => e.iIdTipoAfectacion).HasColumnName("iIdTipoAfectacion");
            entity.Property(e => e.iIdTipoDomninio).HasColumnName("iIdTipoDomninio");
            entity.Property(e => e.iIdTipoInmueble).HasColumnName("iIdTipoInmueble");
            entity.Property(e => e.iIdUsoInmueble).HasColumnName("iIdUsoInmueble");
            entity.Property(e => e.sAfectante)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("sAfectante");
            entity.Property(e => e.sNomenclatura).HasColumnName("sNomenclatura");
            entity.Property(e => e.sPublicacion)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sPublicacion");

            entity.HasOne(d => d.DatosRegistral).WithMany(p => p.DatosInmuebles)
                .HasForeignKey(d => d.iIdDatoRegistral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdInformacionRegistral");

            entity.HasOne(d => d.EstadoGeneral).WithMany(p => p.DatosInmuebles)
                .HasForeignKey(d => d.iIdEstadoGeneral)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdEstadoGeneral");

            entity.HasOne(d => d.TipoAfectacion).WithMany(p => p.DatosInmuebles)
                .HasForeignKey(d => d.iIdTipoAfectacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdTipoAfectacion");

            entity.HasOne(d => d.TiposDominio).WithMany(p => p.DatosInmuebles)
                .HasForeignKey(d => d.iIdTipoDomninio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdTipoDomninio");

            entity.HasOne(d => d.TipoInmueble).WithMany(p => p.DatosInmuebles)
                .HasForeignKey(d => d.iIdTipoInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdTipoInmueble");

            entity.HasOne(d => d.UsoInmueble).WithMany(p => p.DatosInmuebles)
                .HasForeignKey(d => d.iIdUsoInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdUsoInmueble");
        });

        modelBuilder.Entity<EntDatoRegistral>(entity =>
        {
            entity.HasKey(e => e.iIdDatoRegistral).HasName("PK__DatosReg__EFB05DA4A077515B");

            entity.ToTable("DatosRegistrales", "Patrimonio");

            entity.Property(e => e.iIdDatoRegistral).HasColumnName("iIdDatoRegistral");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dSuperficie).HasColumnName("dSuperficie");
            entity.Property(e => e.dSuperficieContruccion).HasColumnName("dSuperficieContruccion");
            entity.Property(e => e.dValorConstruccion).HasColumnName("dValorConstruccion");
            entity.Property(e => e.dValorInicial).HasColumnName("dValorInicial");
            entity.Property(e => e.dValorTerreno).HasColumnName("dValorTerreno");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iFolioCatastro).HasColumnName("iFolioCatastro");
            entity.Property(e => e.iFolioElectronico).HasColumnName("iFolioElectronico");
            entity.Property(e => e.iIdOrigenValor).HasColumnName("iIdOrigenValor");
            entity.Property(e => e.nCodigoPostal)
                .HasColumnType("numeric(10, 0)")
                .HasColumnName("nCodigoPostal");
            entity.Property(e => e.sAsentamiento)
                .HasMaxLength(255)
                .HasColumnName("sAsentamiento");
            entity.Property(e => e.sCalle)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("sCalle");
            entity.Property(e => e.sCruzamimiento1)
                .HasMaxLength(50)
                .HasColumnName("sCruzamimiento1");
            entity.Property(e => e.sCruzamimiento2)
                .HasMaxLength(50)
                .HasColumnName("sCruzamimiento2");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
            entity.Property(e => e.sNumeroExterior)
                .HasMaxLength(50)
                .HasColumnName("sNumeroExterior");
            entity.Property(e => e.sNumeroInterior)
                .HasMaxLength(50)
                .HasColumnName("sNumeroInterior");
            entity.Property(e => e.sPropietario)
                .HasMaxLength(255)
                .HasColumnName("sPropietario");
            entity.Property(e => e.sTablaje)
                .HasMaxLength(255)
                .HasColumnName("sTablaje");

            entity.HasOne(d => d.OrigenValor).WithMany(p => p.DatosRegistrales)
                .HasForeignKey(d => d.iIdOrigenValor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_iIdOrigenValor");
        });

        modelBuilder.Entity<EntDatoVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdDatoVehicular).HasName("PK__DatosVeh__6F810684C3314EC0");

            entity.ToTable("DatosVehiculares", "Patrimonio");

            entity.Property(e => e.iIdDatoVehicular).HasColumnName("iIdDatoVehicular");
            entity.Property(e => e.iAnioEmision).HasColumnName("iAnioEmision");
            entity.Property(e => e.iAnioModelo).HasColumnName("iAnioModelo");
            entity.Property(e => e.iNumeroMotor).HasColumnName("iNumeroMotor");
            entity.Property(e => e.nNumeroEconomico)
                .HasColumnType("numeric(30, 0)")
                .HasColumnName("nNumeroEconomico");
            entity.Property(e => e.sNumeroPlaca)
                .HasMaxLength(20)
                .HasColumnName("sNumeroPlaca");
        });

        modelBuilder.Entity<EntDepreciacion>(entity =>
        {
            entity.HasKey(e => e.iIdDepreciacion).HasName("PK__Deprecia__474B8FF9EB640343");

            entity.ToTable("Depreciaciones", "Patrimonio");

            entity.Property(e => e.iIdDepreciacion).HasColumnName("iIdDepreciacion");
            entity.Property(e => e.dDepreciacionFiscal)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("dDepreciacionFiscal");
            entity.Property(e => e.dDepreciaionAcumulada)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("dDepreciaionAcumulada");
            entity.Property(e => e.dTasa)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("dTasa");
            entity.Property(e => e.dValorLibros).HasColumnName("dValorLibros");
            entity.Property(e => e.dtFecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("dtFecha");
            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
        });

        modelBuilder.Entity<EntDetalleAlta>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleAlta).HasName("PK__Detalles__31BE241794DE35FC");

            entity.ToTable("DetallesAltas", "Patrimonio");

            entity.Property(e => e.iIdDetalleAlta).HasColumnName("iIdDetalleAlta");
            entity.Property(e => e.dPrecioDepreciado).HasColumnName("dPrecioDepreciado");
            entity.Property(e => e.dPrecioDesechable).HasColumnName("dPrecioDesechable");
            entity.Property(e => e.dPrecioUnitario).HasColumnName("dPrecioUnitario");
            entity.Property(e => e.dtFechaAdquisicion)
                .HasColumnType("date")
                .HasColumnName("dtFechaAdquisicion");
            entity.Property(e => e.dtFechaInicioUso)
                .HasColumnType("date")
                .HasColumnName("dtFechaInicioUso");
            entity.Property(e => e.iAniosVida).HasColumnName("iAniosVida");
            entity.Property(e => e.iIdBms).HasColumnName("iIdBMS");
            entity.Property(e => e.iIdEstadoFisico).HasColumnName("iIdEstadoFisico");
            entity.Property(e => e.iIdEtapa).HasColumnName("iIdEtapa");
            entity.Property(e => e.iIdFactura).HasColumnName("iIdFactura");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdLicitacion).HasColumnName("iIdLicitacion");
            entity.Property(e => e.iIdMunicipio).HasColumnName("iIdMunicipio");
            entity.Property(e => e.iIdSolicitud).HasColumnName("iIdSolicitud");
            entity.Property(e => e.iIdSubfamilia).HasColumnName("iIdSubfamilia");
            entity.Property(e => e.iIdTipoAdquisicion).HasColumnName("iIdTipoAdquisicion");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUbicacion).HasColumnName("iIdUbicacion");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.iNumeroBienes).HasColumnName("iNumeroBienes");
            entity.Property(e => e.iIdDatoInmueble).HasColumnName("idDatoInmueble");
            entity.Property(e => e.sCaracteristicas).HasColumnName("sCaracteristicas");
            entity.Property(e => e.sCuentaActivo)
                .HasMaxLength(50)
                .HasColumnName("sCuentaActivo");
            entity.Property(e => e.sCuentaActualizacion)
                .HasMaxLength(50)
                .HasColumnName("sCuentaActualizacion");
            entity.Property(e => e.sCuentaPorPagar).HasColumnName("sCuentaPorPagar");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sFolioAnterior)
                .HasMaxLength(10)
                .HasColumnName("sFolioAnterior");
            entity.Property(e => e.sFolioBien).HasColumnName("sFolioBien");
            entity.Property(e => e.sNoSeries).HasColumnName("sNoSeries");
            entity.Property(e => e.sObservacionBien).HasColumnName("sObservacionBien");
            entity.Property(e => e.sObservacionResponsable).HasColumnName("sObservacionResponsable");
            entity.Property(e => e.sOrdenCompra).HasColumnName("sOrdenCompra");
            entity.Property(e => e.sPartidaEspecifica)
                .HasMaxLength(50)
                .HasColumnName("sPartidaEspecifica");
            entity.Property(e => e.sReferenciaConac)
                .HasMaxLength(50)
                .HasColumnName("sReferenciaCONAC");
            entity.Property(e => e.sRequisicion).HasColumnName("sRequisicion");
            entity.Property(e => e.sResguardantes).HasColumnName("sResguardantes");
            entity.Property(e => e.sSustituyeBv)
                .HasMaxLength(50)
                .HasColumnName("sSustituyeBV");

            entity.HasOne(d => d.Bms).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdBms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdBMS");

            entity.HasOne(d => d.EstadoFisico).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdEstadoFisico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdEstadoFisico");

            entity.HasOne(d => d.Etapa).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdEtapa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdEtapa");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdFactura)
                .HasConstraintName("FK_DetallesAltas_iIdFactura");

            entity.HasOne(d => d.Familia).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdFamilia");

            entity.HasOne(d => d.Licitacion).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdLicitacion)
                .HasConstraintName("FK_DetallesAltas_iIdLicitacion");

            entity.HasOne(d => d.Municipio).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdMunicipio");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdSolicitud");

            entity.HasOne(d => d.Subfamilia).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdSubfamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdSubfamilia");

            entity.HasOne(d => d.TipoAdquisicion).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdTipoAdquisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdTipoAdquisicion");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdTipoBien");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdUbicacion");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesAltas_iIdUnidadAdministrativa");

            entity.HasOne(d => d.DatosInmueble).WithMany(p => p.DetallesAlta)
                .HasForeignKey(d => d.iIdDatoInmueble)
                .HasConstraintName("FK_DetallesAltas_iIdDatosInmueblesAltas");
        });

        modelBuilder.Entity<EntDetalleBaja>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleBaja).HasName("PK__Detalles__30C0102688312FD2");

            entity.ToTable("DetallesBajas", "Patrimonio");

            entity.Property(e => e.iIdDetalleBaja).HasColumnName("iIdDetalleBaja");
            entity.Property(e => e.iIdBaja).HasColumnName("iIdBaja");
            entity.Property(e => e.iIdBajaInmueble).HasColumnName("iIdBajaInmueble");
            entity.Property(e => e.iIdSolicitud).HasColumnName("iIdSolicitud");

            entity.HasOne(d => d.Baja).WithMany(p => p.DetallesBajas)
                .HasForeignKey(d => d.iIdBaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesBajas_iIdBaja");

            entity.HasOne(d => d.BajaInmueble).WithMany(p => p.DetallesBajas)
                .HasForeignKey(d => d.iIdBajaInmueble)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesBajas_iIdBajaInmueble");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.DetallesBajas)
                .HasForeignKey(d => d.iIdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesBajas_iIdSolicitud");
        });

        modelBuilder.Entity<EntDetalleDesincorporacion>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleDesincorporacion).HasName("PK__Detalles__AA4AE52E6444EBCF");

            entity.ToTable("DetallesDesincorporaciones", "Patrimonio");

            entity.Property(e => e.iIdDetalleDesincorporacion).HasColumnName("iIdDetalleDesincorporacion");
            entity.Property(e => e.dtFechaPublicacion)
                .HasColumnType("date")
                .HasColumnName("dtFechaPublicacion");
            entity.Property(e => e.iIdEmpleado).HasColumnName("iIdEmpleado");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.sDescripcionDesincorporacion)
                .IsRequired()
                .HasColumnName("sDescripcionDesincorporacion");
            entity.Property(e => e.sFolioBien)
                .IsRequired()
                .HasColumnName("sFolioBien");
            entity.Property(e => e.sNumeroPublicacion)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNumeroPublicacion");
            entity.Property(e => e.sObservaciones)
                .IsRequired()
                .HasColumnName("sObservaciones");

            entity.HasOne(d => d.Empleado).WithMany(p => p.DetallesDesincorporaciones)
                .HasForeignKey(d => d.iIdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDesincorporaciones_iIdEmpleado");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.DetallesDesincorporaciones)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDesincorporaciones_iIdTipoBien");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.DetallesDesincorporaciones)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDesincorporaciones_iIdUnidadAdministrativa");
        });

        modelBuilder.Entity<EntDetalleDestinoFinal>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleDestinoFinal).HasName("PK__Detalles__9A03571F466E843F");

            entity.ToTable("DetallesDestinoFinales", "Patrimonio");

            entity.Property(e => e.iIdDetalleDestinoFinal).HasColumnName("iIdDetalleDestinoFinal");
            entity.Property(e => e.iIdAfectacion).HasColumnName("iIdAfectacion");
            entity.Property(e => e.iIdDetalleDestruccion).HasColumnName("iIdDetalleDestruccion");
            entity.Property(e => e.iIdDetalleEnagenacion).HasColumnName("iIdDetalleEnagenacion");
            entity.Property(e => e.iIdEmpleado).HasColumnName("iIdEmpleado");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.sFolioBien)
                .IsRequired()
                .HasColumnName("sFolioBien");
            entity.Property(e => e.sObservaciones)
                .IsRequired()
                .HasColumnName("sObservaciones");

            entity.HasOne(d => d.Afectacion).WithMany(p => p.DetallesDestinoFinales)
                .HasForeignKey(d => d.iIdAfectacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDestinoFinales_iIdAfectacion");

            entity.HasOne(d => d.DetalleDestruccion).WithMany(p => p.DetallesDestinoFinales)
                .HasForeignKey(d => d.iIdDetalleDestruccion)
                .HasConstraintName("FK_DetallesDestinoFinales_iIdDetalleDestruccion");

            entity.HasOne(d => d.DetalleEnagenacion).WithMany(p => p.DetallesDestinoFinales)
                .HasForeignKey(d => d.iIdDetalleEnagenacion)
                .HasConstraintName("FK_DetallesDestinoFinales_iIdDetalleEnagenacion");

            entity.HasOne(d => d.Empleado).WithMany(p => p.DetallesDestinoFinales)
                .HasForeignKey(d => d.iIdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDestinoFinales_iIdEmpleado");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.DetallesDestinoFinales)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDestinoFinales_iIdTipoBien");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.DetallesDestinoFinales)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesDestinoFinales_iIdUnidadAdministrativa");
        });

        modelBuilder.Entity<EntDetalleDestruccion>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleDestruccion).HasName("PK__Detalles__60F6C0F7F3E8F9B3");

            entity.ToTable("DetallesDestrucciones", "Patrimonio");

            entity.Property(e => e.iIdDetalleDestruccion).HasColumnName("iIdDetalleDestruccion");
            entity.Property(e => e.dtFecha)
                .HasColumnType("date")
                .HasColumnName("dtFecha");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sFolio)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sFolio");
        });

        modelBuilder.Entity<EntDetalleEnagenacion>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleEnagenacion).HasName("PK__Detalles__04C2C2CCB1064020");

            entity.ToTable("DetallesEnagenaciones", "Patrimonio");

            entity.Property(e => e.iIdDetalleEnagenacion).HasColumnName("iIdDetalleEnagenacion");
            entity.Property(e => e.dImporte).HasColumnName("dImporte");
            entity.Property(e => e.dImporteAvaluo).HasColumnName("dImporteAvaluo");
            entity.Property(e => e.dtFecha)
                .HasColumnType("date")
                .HasColumnName("dtFecha");
            entity.Property(e => e.sAvaluo)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sAvaluo");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sFolio)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sFolio");
        });

        modelBuilder.Entity<EntDetalleModificacion>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleModificacion).HasName("PK__Detalles__AD199F0024DAE5C0");

            entity.ToTable("DetallesModificaciones", "Patrimonio");

            entity.Property(e => e.iIdDetalleModificacion).HasColumnName("iIdDetalleModificacion");
            entity.Property(e => e.dPrecioDepreciado).HasColumnName("dPrecioDepreciado");
            entity.Property(e => e.dPrecioDesechable).HasColumnName("dPrecioDesechable");
            entity.Property(e => e.dPrecioUnitario).HasColumnName("dPrecioUnitario");
            entity.Property(e => e.dtFechaAdquisicion)
                .HasColumnType("date")
                .HasColumnName("dtFechaAdquisicion");
            entity.Property(e => e.dtFechaInicioUso)
                .HasColumnType("date")
                .HasColumnName("dtFechaInicioUso");
            entity.Property(e => e.iAniosVida).HasColumnName("iAniosVida");
            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
            entity.Property(e => e.iIdBms).HasColumnName("iIdBMS");
            entity.Property(e => e.iIdDatoInmueble).HasColumnName("iIdDatoInmueble");
            entity.Property(e => e.iIdEstadoFisico).HasColumnName("iIdEstadoFisico");
            entity.Property(e => e.iIdEtapa).HasColumnName("iIdEtapa");
            entity.Property(e => e.iIdFactura).HasColumnName("iIdFactura");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdLicitacion).HasColumnName("iIdLicitacion");
            entity.Property(e => e.iIdMunicipio).HasColumnName("iIdMunicipio");
            entity.Property(e => e.iIdSolicitud).HasColumnName("iIdSolicitud");
            entity.Property(e => e.iIdSubfamilia).HasColumnName("iIdSubfamilia");
            entity.Property(e => e.iIdTipoAdquisicion).HasColumnName("iIdTipoAdquisicion");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUbicacion).HasColumnName("iIdUbicacion");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.iNumeroBienes).HasColumnName("iNumeroBienes");
            entity.Property(e => e.sCaracteristicas).HasColumnName("sCaracteristicas");
            entity.Property(e => e.sCuentaActivo)
                .HasMaxLength(50)
                .HasColumnName("sCuentaActivo");
            entity.Property(e => e.sCuentaActualizacion)
                .HasMaxLength(50)
                .HasColumnName("sCuentaActualizacion");
            entity.Property(e => e.sCuentaPorPagar).HasColumnName("sCuentaPorPagar");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sFolioAnterior)
                .HasMaxLength(10)
                .HasColumnName("sFolioAnterior");
            entity.Property(e => e.sFolioBien).HasColumnName("sFolioBien");
            entity.Property(e => e.sNoSeries).HasColumnName("sNoSeries");
            entity.Property(e => e.sObservacionBien).HasColumnName("sObservacionBien");
            entity.Property(e => e.sObservacionResponsable).HasColumnName("sObservacionResponsable");
            entity.Property(e => e.sOrdenCompra).HasColumnName("sOrdenCompra");
            entity.Property(e => e.sPartidaEspecifica)
                .HasMaxLength(50)
                .HasColumnName("sPartidaEspecifica");
            entity.Property(e => e.sReferenciaConac)
                .HasMaxLength(50)
                .HasColumnName("sReferenciaCONAC");
            entity.Property(e => e.sRequisicion).HasColumnName("sRequisicion");
            entity.Property(e => e.sResguardantes).HasColumnName("sResguardantes");
            entity.Property(e => e.sSustituyeBv)
                .HasMaxLength(50)
                .HasColumnName("sSustituyeBV");

            entity.HasOne(d => d.Bien).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdBien");

            entity.HasOne(d => d.Bms).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdBms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdBMS");

            entity.HasOne(d => d.DatoInmueble).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdDatoInmueble)
                .HasConstraintName("FK_DetallesModificaciones_iIdDatosInmueblesModificaciones");

            entity.HasOne(d => d.EstadoFisico).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdEstadoFisico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdEstadoFisico");

            entity.HasOne(d => d.Etapa).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdEtapa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdEtapa");

            entity.HasOne(d => d.Familia).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdFamilia");

            entity.HasOne(d => d.Municipio).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdMunicipio");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdSolicitud");

            entity.HasOne(d => d.Subfamilia).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdSubfamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdSubfamilia");

            entity.HasOne(d => d.TipoAdquisicion).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdTipoAdquisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdTipoAdquisicion");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdTipoBien");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdUbicacion");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.DetallesModificaciones)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesModificaciones_iIdUnidadAdministrativa");
        });

        modelBuilder.Entity<EntDetalleMovimiento>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleMovimiento).HasName("PK__Detalles__A0550FB39EF6C5C0");

            entity.ToTable("DetallesMovimientos", "Patrimonio");

            entity.Property(e => e.iIdDetalleMovimiento).HasColumnName("iIdDetalleMovimiento");
            entity.Property(e => e.iIdMunicipio).HasColumnName("iIdMunicipio");
            entity.Property(e => e.iIdNuevaUnidadAdministrativa).HasColumnName("iIdNuevaUnidadAdministrativa");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iIdUbicacion).HasColumnName("iIdUbicacion");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.sFolioBien)
                .IsRequired()
                .HasColumnName("sFolioBien");
            entity.Property(e => e.sResponsable).HasColumnName("sResponsable");

            entity.HasOne(d => d.Municipio).WithMany(p => p.DetallesMovimientos)
                .HasForeignKey(d => d.iIdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesMovimientos_iIdMunicipio");

            entity.HasOne(d => d.NuevaUnidadAdministrativa).WithMany(p => p.DetallesMovimientoIIdNuevaUnidadAdministrativaNavigations)
                .HasForeignKey(d => d.iIdNuevaUnidadAdministrativa)
                .HasConstraintName("FK_DetallesMovimientos_iIdNuevaUnidadAdministrativa");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.DetallesMovimientos)
                .HasForeignKey(d => d.iIdTipoBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesMovimientos_iIdTipoBien");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.DetallesMovimientos)
                .HasForeignKey(d => d.iIdUbicacion)
                .HasConstraintName("FK_DetallesMovimientos_iIdUbicacion");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.DetallesMovimientoIIdUnidadAdministrativaNavigations)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesMovimientos_iIdUnidadAdministrativa");
        });

        modelBuilder.Entity<EntDetalleSolicitud>(entity =>
        {
            entity.HasKey(e => e.iIdDetalleSolicitud).HasName("PK__Detalles__27101719C0E583E6");

            entity.ToTable("DetallesSolicitudes", "Patrimonio");

            entity.Property(e => e.iIdDetalleSolicitud).HasColumnName("iIdDetalleSolicitud");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdDetalleAlta).HasColumnName("iIdDetalleAlta");
            entity.Property(e => e.iIdDetalleBaja).HasColumnName("iIdDetalleBaja");
            entity.Property(e => e.iIdDetalleDesincorporacion).HasColumnName("iIdDetalleDesincorporacion");
            entity.Property(e => e.iIdDetalleDestinoFinal).HasColumnName("iIdDetalleDestinoFinal");
            entity.Property(e => e.iIdDetalleModificacion).HasColumnName("iIdDetalleModificacion");
            entity.Property(e => e.iIdDetalleMovimiento).HasColumnName("iIdDetalleMovimiento");
            entity.Property(e => e.iIdEtapa).HasColumnName("iIdEtapa");
            entity.Property(e => e.iIdSolicitud).HasColumnName("iIdSolicitud");

            entity.HasOne(d => d.DetalleAlta).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdDetalleAlta)
                .HasConstraintName("FK_DetallesSolicitudes_iIdDetalleAlta");

            entity.HasOne(d => d.DetalleBaja).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdDetalleBaja)
                .HasConstraintName("FK_DetallesSolicitudes_iIdDetalleBaja");

            entity.HasOne(d => d.DetalleDesincorporacion).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdDetalleDesincorporacion)
                .HasConstraintName("FK_DetallesSolicitudes_iIdDetalleDesincorporacion");

            entity.HasOne(d => d.DetalleDestinoFinal).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdDetalleDestinoFinal)
                .HasConstraintName("FK_DetallesSolicitudes_iIdDetalleDestinoFinal");

            entity.HasOne(d => d.DetalleModificacion).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdDetalleModificacion)
                .HasConstraintName("FK_DetallesSolicitudes_iIdDetalleModificacion");

            entity.HasOne(d => d.DetalleMovimiento).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdDetalleMovimiento)
                .HasConstraintName("FK_DetallesSolicitudes_iIdDetalleMovimiento");

            entity.HasOne(d => d.Etapa).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdEtapa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesSolicitudes_iIdEtapa");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.DetallesSolicitudes)
                .HasForeignKey(d => d.iIdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetallesSolicitudes_iIdSolicitud");
        });

        modelBuilder.Entity<EntDocumento>(entity =>
        {
            entity.HasKey(e => e.iIdDocumento).HasName("PK__Document__5506EB498AAC10BE");

            entity.ToTable("Documentos", "Catalogo");

            entity.Property(e => e.iIdDocumento).HasColumnName("iIdDocumentos");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdMotivoTramite).HasColumnName("iIdMotivoTramite");
            entity.Property(e => e.iIdSubModulo).HasColumnName("iIdSubModulo");
            entity.Property(e => e.iIdTipoTramite).HasColumnName("iIdTipoTramite");
            entity.Property(e => e.sAbreviacion)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("sAbreviacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.MotivoTramite).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.iIdMotivoTramite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documentos_iIdMotivoTramite");

            entity.HasOne(d => d.SubModulo).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.iIdSubModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documentos_iIdModulo");

            entity.HasOne(d => d.TipoTramite).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.iIdTipoTramite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documentos_iIdTipoTramite");
        });

        modelBuilder.Entity<EntEmpleado>(entity =>
        {
            entity.HasKey(e => e.iIdEmpleado).HasName("PK__Empleado__AD520645D6391172");

            entity.ToTable("Empleados", "Seguridad");

            entity.Property(e => e.iIdEmpleado).HasColumnName("iIdEmpleado");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaIngreso)
                .HasColumnType("date")
                .HasColumnName("dtFechaIngreso");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdNombramiento).HasColumnName("iIdNombramiento");
            entity.Property(e => e.iIdPersona).HasColumnName("iIdPersona");
            entity.Property(e => e.iIdUsuario).HasColumnName("iIdUsuario");

            entity.HasOne(d => d.Nombramiento).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.iIdNombramiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_iIdNombramiento");

            entity.HasOne(d => d.Persona).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.iIdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_iIdPersona");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.iIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleados_iIdUsuario");
        });

        modelBuilder.Entity<EntEstadoFisico>(entity =>
        {
            entity.HasKey(e => e.iIdEstadoFisico).HasName("PK__EstadosF__B8DBE8994F9DBBC2");

            entity.ToTable("EstadosFisicos", "Catalogo");

            entity.Property(e => e.iIdEstadoFisico).HasColumnName("iIdEstadoFisico");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntEstadoGeneral>(entity =>
        {
            entity.HasKey(e => e.iIdEstadoGeneral).HasName("PK__EstadosG__CFEBEA803730D179");

            entity.ToTable("EstadosGenerales", "Catalogo");

            entity.Property(e => e.iIdEstadoGeneral).HasColumnName("iIdEstadoGeneral");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntEtapa>(entity =>
        {
            entity.HasKey(e => e.iIdEtapa).HasName("PK__Etapas__CB53046F1A50ABC1");

            entity.ToTable("Etapas", "Patrimonio");

            entity.Property(e => e.iIdEtapa).HasColumnName("iIdEtapa");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntEtapaTramite>(entity =>
        {
            entity.HasKey(e => e.iIdEtapaTramite).HasName("PK__EtapasTr__925533C9B5793230");

            entity.ToTable("EtapasTramites", "Patrimonio");

            entity.Property(e => e.iIdEtapaTramite).HasColumnName("iIdEtapaTramite");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdEtapaOrigen).HasColumnName("iIdEtapaOrigen");
            entity.Property(e => e.iIdEtapaDestino).HasColumnName("iIdEtapaDestino");
            entity.Property(e => e.iIdTipoTramite).HasColumnName("iIdTipoTramite");

            entity.HasOne(d => d.EtapaOrigen).WithMany(p => p.EtapasTramitesOrigen)
                .HasForeignKey(d => d.iIdEtapaOrigen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EtapasTramites_iIdEtapaOrigen");

            entity.HasOne(d => d.EtapaDestino).WithMany(p => p.EtapasTramitesDestino)
                .HasForeignKey(d => d.iIdEtapaDestino)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EtapasTramites_iIdEtapaDestino");

             entity.HasOne(d => d.TipoTramite).WithMany(p => p.EtapasTramites)
                .HasForeignKey(d => d.iIdTipoTramite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EtapasTramites_iIdTipoTramite");
        });

        modelBuilder.Entity<EntFactura>(entity =>
        {
            entity.HasKey(e => e.iIdFactura).HasName("PK__Facturas__40F839C2353EA414");

            entity.ToTable("Facturas", "Patrimonio");

            entity.Property(e => e.iIdFactura).HasColumnName("iIdFactura");
            entity.Property(e => e.dtFecha)
                .HasColumnType("date")
                .HasColumnName("dtFecha");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iGarantiaDias).HasColumnName("iGarantiaDias");
            entity.Property(e => e.iIdDatoVehicular).HasColumnName("iIdDatoVehicular");
            entity.Property(e => e.sFolioFactura)
                .HasMaxLength(20)
                .HasColumnName("sFolioFactura");

            entity.HasOne(d => d.DatoVehicular).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.iIdDatoVehicular)
                .HasConstraintName("FK_Facturas_iIdDatoVehicular");
        });

        modelBuilder.Entity<EntFamilia>(entity =>
        {
            entity.HasKey(e => e.iIdFamilia).HasName("PK__Familias__63F8F27CBA68F05B");

            entity.ToTable("Familias", "Catalogo", tb => tb.HasTrigger("TRG_Familia_UpdateINumeroCuenta"));

            entity.Property(e => e.iIdFamilia)
                .ValueGeneratedNever()
                .HasColumnName("iIdFamilia");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.iNumeroCuenta).HasColumnName("iNumeroCuenta");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.TipoBien).WithMany(p => p.Familia)
                .HasForeignKey(d => d.iIdTipoBien)
                .HasConstraintName("FK_Familias_iIdTipoBien");
        });

        modelBuilder.Entity<EntFuenteFinanciamiento>(entity =>
        {
            entity.HasKey(e => e.iIdFuenteFinanciamiento).HasName("PK__FuentesF__150B2ED7CFB167E6");

            entity.ToTable("FuentesFinanciamiento", "Almacen");

            entity.Property(e => e.iIdFuenteFinanciamiento).HasColumnName("iIdFuenteFinanciamiento");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sClaveCompleta)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sClaveCompleta");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntHistorial>(entity =>
        {
            entity.HasKey(e => e.iIdHistorial).HasName("PK__Historia__6D1A674A5F7F9FBC");

            entity.ToTable("Historiales", "Patrimonio");

            entity.Property(e => e.iIdHistorial).HasColumnName("iIdHistorial");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
            entity.Property(e => e.iIdModulo).HasColumnName("iIdModulo");
            entity.Property(e => e.iIdSolicitud).HasColumnName("iIdSolicitud");
            entity.Property(e => e.iIdSubModulo).HasColumnName("iIdSubModulo");

            entity.HasOne(d => d.Bien).WithMany(p => p.Historiales)
                .HasForeignKey(d => d.iIdBien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Depreciaciones_iIdBien");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Historiales)
                .HasForeignKey(d => d.iIdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historiales_iIdModulo");

            entity.HasOne(d => d.Solicitud).WithMany(p => p.Historiales)
                .HasForeignKey(d => d.iIdSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historiales_iIdSolicitud");

            entity.HasOne(d => d.SubModulo).WithMany(p => p.Historiales)
                .HasForeignKey(d => d.iIdSubModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historiales_iIdSubModulo");
        });

        modelBuilder.Entity<EntLicitacion>(entity =>
        {
            entity.HasKey(e => e.iIdLicitacion).HasName("PK__Licitaci__A1CF2C2E9CA57796");

            entity.ToTable("Licitaciones", "Patrimonio");

            entity.Property(e => e.iIdLicitacion).HasColumnName("iIdLicitacion");
            entity.Property(e => e.dtFecha)
                .HasColumnType("date")
                .HasColumnName("dtFecha");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iNumeroLicitacion).HasColumnName("iNumeroLicitacion");
            entity.Property(e => e.sObservaciones).HasColumnName("sObservaciones");
        });

        modelBuilder.Entity<EntLineaVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdLineaVehicular).HasName("PK__LineasVe__432F6A745E1D072F");

            entity.ToTable("LineasVehiculares", "Catalogo");

            entity.Property(e => e.iIdLineaVehicular).HasColumnName("iIdLineaVehicular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntMarca>(entity =>
        {
            entity.HasKey(e => e.iIdMarca).HasName("PK__Marcas__297E604DA230FCF0");

            entity.ToTable("Marcas", "Catalogo");

            entity.Property(e => e.iIdMarca).HasColumnName("iIdMarca");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");
            entity.Property(e => e.sObservaciones).HasColumnName("sObservaciones");
        });

        modelBuilder.Entity<EntMetodoAdquisicion>(entity =>
        {
            entity.HasKey(e => e.iIdMetodoAdquisicion).HasName("PK__MetodosA__06B2CF47DA9F6382");

            entity.ToTable("MetodosAdquisicion", "Almacen");

            entity.Property(e => e.iIdMetodoAdquisicion).HasColumnName("iIdMetodoAdquisicion");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntMetodoCosteo>(entity =>
        {
            entity.HasKey(e => e.iIdMetodoCosteo).HasName("PK__MetodosC__60D75273472B34A1");

            entity.ToTable("MetodosCosteo", "Almacen");

            entity.Property(e => e.iIdMetodoCosteo).HasColumnName("iIdMetodoCosteo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sAbreviacion)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("sAbreviacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntModulo>(entity =>
        {
            entity.HasKey(e => e.iIdModulo).HasName("PK__Modulos__091CACC3E4633978");

            entity.ToTable("Modulos", "Sistema");

            entity.Property(e => e.iIdModulo).HasColumnName("iIdModulo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdPermiso).HasColumnName("iIdPermiso");
            entity.Property(e => e.sAbreviacion)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("sAbreviacion");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Permiso).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.iIdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modulos_iIdPermiso");
        });

        modelBuilder.Entity<EntMotivoTramite>(entity =>
        {
            entity.HasKey(e => e.iIdMotivoTramite).HasName("PK__MotivosT__2F10899C4E02B046");

            entity.ToTable("MotivosTramites", "Patrimonio");

            entity.Property(e => e.iIdMotivoTramite).HasColumnName("iIdMotivoTramite");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdTipoTramite).HasColumnName("iIdTipoTramite");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.TiposTramite).WithMany(p => p.MotivosTramites)
                .HasForeignKey(d => d.iIdTipoTramite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MotivosTramites_iIdTipoTramite");
        });

        modelBuilder.Entity<EntMovimiento>(entity =>
        {
            entity.HasKey(e => e.iIdMovimiento).HasName("PK__Movimien__99B69AD00E0FACCD");

            entity.ToTable("Movimientos", "Almacen");

            entity.Property(e => e.iIdMovimiento).HasColumnName("iIdMovimiento");
            entity.Property(e => e.dImporteTotal).HasColumnName("dImporteTotal");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.dtFechaResepcion)
                .HasColumnType("date")
                .HasColumnName("dtFechaResepcion");
            entity.Property(e => e.iIdAlmacen).HasColumnName("iIdAlmacen");
            entity.Property(e => e.iIdConceptoMovimiento).HasColumnName("iIdConceptoMovimiento");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iIdFuenteFinanciamiento).HasColumnName("iIdFuenteFinanciamiento");
            entity.Property(e => e.iIdMetodoAdquisicion).HasColumnName("iIdMetodoAdquisicion");
            entity.Property(e => e.iIdProgramaOperativo).HasColumnName("iIdProgramaOperativo");
            entity.Property(e => e.iIdProveedor).HasColumnName("iIdProveedor");
            entity.Property(e => e.iIdTipoMovimiento).HasColumnName("iIdTipoMovimiento");
            entity.Property(e => e.sNumeroFactura)
                .HasMaxLength(255)
                .HasColumnName("sNumeroFactura");
            entity.Property(e => e.sObservaciones).HasColumnName("sObservaciones");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimientos_iIdAlmacen");

            entity.HasOne(d => d.ConceptoMovimiento).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdConceptoMovimiento)
                .HasConstraintName("FK_Movimientos_iIdConceptoMovimiento");

            entity.HasOne(d => d.Familia).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdFamilia)
                .HasConstraintName("FK_Movimientos_iIdFamilia");

            entity.HasOne(d => d.FuenteFinanciamiento).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdFuenteFinanciamiento)
                .HasConstraintName("FK_Movimientos_iIdFuenteFinanciamiento");

            entity.HasOne(d => d.MetodoAdquisicion).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdMetodoAdquisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimientos_iIdMetodoAdquisicion");

            entity.HasOne(d => d.IIdProgramaOperativoNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdProgramaOperativo)
                .HasConstraintName("FK_Movimientos_iIdProgramaOperativo");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdProveedor)
                .HasConstraintName("FK_Movimientos_iIdProveedor");

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.iIdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movimientos_iIdTipoMovimiento");
        });

        modelBuilder.Entity<EntMovimientoBien>(entity =>
        {
            entity.HasKey(e => e.iIdMovimientoBien).HasName("PK__Movimien__5230CCD48995684D");

            entity.ToTable("MovimientosBienes", "Almacen");

            entity.Property(e => e.iIdMovimientoBien).HasColumnName("iIdMovimientoBien");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdBien).HasColumnName("iIdBien");
            entity.Property(e => e.iIdBms).HasColumnName("iIdBMS");
            entity.Property(e => e.iIdMovimiento).HasColumnName("iIdMovimiento");

            entity.HasOne(d => d.Bien).WithMany(p => p.MovimientosBienes)
                .HasForeignKey(d => d.iIdBien)
                .HasConstraintName("FK_MovimientosBienes_iIdBien");

            entity.HasOne(d => d.Bms).WithMany(p => p.MovimientosBienes)
                .HasForeignKey(d => d.iIdBms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientosBienes_iIdBMS");

            entity.HasOne(d => d.Movimiento).WithMany(p => p.MovimientosBienes)
                .HasForeignKey(d => d.iIdMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientosBienes_iIdMovimiento");
        });

        modelBuilder.Entity<EntMunicipio>(entity =>
        {
            entity.HasKey(e => e.iIdMunicipio).HasName("PK__Municipi__D31789DFC21F17C2");

            entity.ToTable("Municipios", "General");

            entity.Property(e => e.iIdMunicipio).HasColumnName("iIdMunicipio");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntNacionalidad>(entity =>
        {
            entity.HasKey(e => e.iIdNacionalidad).HasName("PK__Nacional__435DAE1AFAA51251");

            entity.ToTable("Nacionalidades", "General");

            entity.Property(e => e.iIdNacionalidad).HasColumnName("iIdNacionalidad");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntNombramiento>(entity =>
        {
            entity.HasKey(e => e.iIdNombramiento).HasName("PK__Nombrami__425CC5BCBADE9DC5");

            entity.ToTable("Nombramientos", "General");

            entity.Property(e => e.iIdNombramiento).HasColumnName("iIdNombramiento");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntOrigenValor>(entity =>
        {
            entity.HasKey(e => e.iIdOrigenValor).HasName("PK__Origenes__E9F1435C7AB8AE51");

            entity.ToTable("OrigenesValores", "Catalogo");

            entity.Property(e => e.iIdOrigenValor).HasColumnName("iIdOrigenValor");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sOrigen)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("sOrigen");
        });

        modelBuilder.Entity<EntPeriodo>(entity =>
        {
            entity.HasKey(e => e.iIdPeriodo).HasName("PK__Periodos__93D9B9104F62A082");

            entity.ToTable("Periodos", "General");

            entity.Property(e => e.iIdPeriodo)
                .ValueGeneratedNever()
                .HasColumnName("iIdPeriodo");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaFinal)
                .HasColumnType("date")
                .HasColumnName("dtFechaFinal");
            entity.Property(e => e.dtFechaInicio)
                .HasColumnType("date")
                .HasColumnName("dtFechaInicio");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
        });

        modelBuilder.Entity<EntPermiso>(entity =>
        {
            entity.HasKey(e => e.iIdPermiso).HasName("PK__Permisos__6E83624B599432E9");

            entity.ToTable("Permisos", "Seguridad");

            entity.Property(e => e.iIdPermiso).HasColumnName("iIdPermiso");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntPersona>(entity =>
        {
            entity.HasKey(e => e.iIdPersona).HasName("PK__Personas__CB475B379A67DA15");

            entity.ToTable("Personas", "Seguridad");

            entity.Property(e => e.iIdPersona).HasColumnName("iIdPersona");
            entity.Property(e => e.bHombre).HasColumnName("bHombre");
            entity.Property(e => e.dtFechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("dtFechaNacimiento");
            entity.Property(e => e.iIdNacionalidad).HasColumnName("iIdNacionalidad");
            entity.Property(e => e.sNombres)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("sNombres");
            entity.Property(e => e.sPrimerNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sPrimerNombre");
            entity.Property(e => e.sRfc)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("sRFC");
            entity.Property(e => e.sSegundoNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sSegundoNombre");

            entity.HasOne(d => d.Nacionalidad).WithMany(p => p.Personas)
                .HasForeignKey(d => d.iIdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personas_iIdNacionalidad");
        });

        modelBuilder.Entity<EntProgramasOperativo>(entity =>
        {
            entity.HasKey(e => e.iIdProgramaOperativo).HasName("PK__Programa__FC480E3149379B34");

            entity.ToTable("ProgramasOperativos", "Almacen");

            entity.Property(e => e.iIdProgramaOperativo).HasColumnName("iIdProgramaOperativo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntProveedor>(entity =>
        {
            entity.HasKey(e => e.iIdProveedor).HasName("PK__Proveedo__DA7D86475A3BE0BF");

            entity.ToTable("Proveedores", "Almacen");

            entity.Property(e => e.iIdProveedor).HasColumnName("iIdProveedor");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntResguardante>(entity =>
        {
            entity.HasKey(e => e.iIdResguardante).HasName("PK__Resguard__F8A9B4DF033458B5");

            entity.ToTable("Resguardantes", "Catalogo");

            entity.Property(e => e.iIdResguardante).HasColumnName("iIdResguardante");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.bResponsable).HasColumnName("bResponsable");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdPeriodo).HasColumnName("iIdPeriodo");
            entity.Property(e => e.iIdPersona).HasColumnName("iIdPersona");
            entity.Property(e => e.iIdTipoResponsable).HasColumnName("iIdTipoResponsable");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.iNoConvenio).HasColumnName("iNoConvenio");
            entity.Property(e => e.sObservaciones).HasColumnName("sObservaciones");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Resguardantes)
                .HasForeignKey(d => d.iIdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resguardantes_iIdPeriodo");

            entity.HasOne(d => d.Persona).WithMany(p => p.Resguardantes)
                .HasForeignKey(d => d.iIdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resguardantes_iIdPersona");

            entity.HasOne(d => d.TipoResponsable).WithMany(p => p.Resguardantes)
                .HasForeignKey(d => d.iIdTipoResponsable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resguardantes_iIdTipoResponsable");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.Resguardantes)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resguardantes_UnidadesAdministrativas");
        });

        modelBuilder.Entity<EntRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__87A2FA5D8A6AE9D5");

            entity.ToTable("Roles", "Seguridad");

            entity.Property(e => e.Id).HasColumnName("iIdRol");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");
            entity.Property(e => e.NormalizedName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombreNormalizado");
            entity.Property(e => e.ConcurrencyStamp)
                 .IsConcurrencyToken()
                 .HasColumnName("sSelloDeConcorrencia")
                 .HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<EntRolPermiso>(entity =>
        {
            entity.HasKey(e => e.iIdRolPermiso).HasName("PK__RolesPer__D69F977FC4ADCBF8");

            entity.ToTable("RolesPermisos", "Seguridad");

            entity.Property(e => e.iIdRolPermiso).HasColumnName("iIdRolPermiso");
            entity.Property(e => e.iIdPermiso).HasColumnName("iIdPermiso");
            entity.Property(e => e.iIdRol).HasColumnName("iIdRol");

            entity.HasOne(d => d.Permiso).WithMany(p => p.RolesPermisos)
                .HasForeignKey(d => d.iIdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesPermisos_iIdPermiso");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolesPermisos)
                .HasForeignKey(d => d.iIdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesPermisos_iIdRol");
        });

        modelBuilder.Entity<EntSeccion>(entity =>
        {
            entity.HasKey(e => e.iIdSeccion).HasName("PK__Seccione__D29229B708366729");

            entity.ToTable("Secciones", "Sistema");

            entity.Property(e => e.iIdSeccion).HasColumnName("iIdSeccion");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntSeguimiento>(entity =>
        {
            entity.HasKey(e => e.iIdSeguimiento).HasName("PK__Seguimie__4C9AC15206F9509C");

            entity.ToTable("Seguimientos", "Patrimonio");

            entity.Property(e => e.iIdSeguimiento).HasColumnName("iIdSeguimiento");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaHora");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdDetalleSolicitud).HasColumnName("iIdDetalleSolicitud");
            entity.Property(e => e.iIdEtapa).HasColumnName("iIdEtapa");
            entity.Property(e => e.iIdModulo).HasColumnName("iIdModulo");
            entity.Property(e => e.iIdSubModulo).HasColumnName("iIdSubModulo");
            entity.Property(e => e.iIdUsuario).HasColumnName("iIdUsuario");

            entity.HasOne(d => d.DetalleSolicitud).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.iIdDetalleSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_iIdDetalleSolicitud");

            entity.HasOne(d => d.Etapa).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.iIdEtapa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_iIdEtapa");

            entity.HasOne(d => d.Modulo).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.iIdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_iIdModulo");

            entity.HasOne(d => d.SubModulo).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.iIdSubModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_iIdSubModulo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.iIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimientos_iIdUsuario");
        });

        modelBuilder.Entity<EntSolicitud>(entity =>
        {
            entity.HasKey(e => e.iIdSolicitud).HasName("PK__Solicitu__B36AE9393E87D0CD");

            entity.ToTable("Solicitudes", "Patrimonio");

            entity.Property(e => e.iIdSolicitud).HasColumnName("iIdSolicitud");
            entity.Property(e => e.dtFechaAfectacion)
                .HasColumnType("date")
                .HasColumnName("dtFechaAfectacion");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdAfectacion).HasColumnName("iIdAfectacion");
            entity.Property(e => e.iIdEmpleado).HasColumnName("iIdEmpleado");
            entity.Property(e => e.iIdEtapa).HasColumnName("iIdEtapa");
            entity.Property(e => e.iIdMotivoTramite).HasColumnName("iIdMotivoTramite");
            entity.Property(e => e.iIdPeriodo).HasColumnName("iIdPeriodo");
            entity.Property(e => e.iIdTipoTramite).HasColumnName("iIdTipoTramite");
            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.sDocumentoReferencia).HasColumnName("sDocumentoReferencia");
            entity.Property(e => e.sObservaciones).HasColumnName("sObservaciones");

            entity.HasOne(d => d.Afectacion).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdAfectacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdAfectacionSolicitud");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdEmpleado");

            entity.HasOne(d => d.Etapa).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdEtapa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdEtapa");

            entity.HasOne(d => d.MotivoTramite).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdMotivoTramite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdMotivoTramite");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdPeriodo");

            entity.HasOne(d => d.TiposTramite).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdTipoTramite)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdTipoTramite");

            entity.HasOne(d => d.UnidadAdministrativa).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.iIdUnidadAdministrativa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Solicitudes_iIdUnidadAdministrativa");
        });

        modelBuilder.Entity<EntSubModulo>(entity =>
        {
            entity.HasKey(e => e.iIdSubModulo).HasName("PK__SubModul__934F29C8F8E314D0");

            entity.ToTable("SubModulos", "Sistema");

            entity.Property(e => e.iIdSubModulo).HasColumnName("iIdSubModulo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdModulo).HasColumnName("iIdModulo");
            entity.Property(e => e.iIdPermiso).HasColumnName("iIdPermiso");
            entity.Property(e => e.iIdSeccion).HasColumnName("iIdSeccion");
            entity.Property(e => e.sAbreviacion)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("sAbreviacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Modulo).WithMany(p => p.SubModulos)
                .HasForeignKey(d => d.iIdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubModulos_iIdModulo");

            entity.HasOne(d => d.Permiso).WithMany(p => p.SubModulos)
                .HasForeignKey(d => d.iIdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubModulos_iIdPermiso");

            entity.HasOne(d => d.Seccion).WithMany(p => p.SubModulos)
                .HasForeignKey(d => d.iIdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubModulos_iIdSeccion");
        });

        modelBuilder.Entity<EntSubfamilia>(entity =>
        {
            entity.HasKey(e => e.iIdSubfamilia).HasName("PK__Subfamil__492436A89E6949F8");

            entity.ToTable("Subfamilias", "Catalogo", tb => tb.HasTrigger("TRG_Subfamilia_UpdateINumeroCuenta"));

            entity.Property(e => e.iIdSubfamilia)
                .ValueGeneratedNever()
                .HasColumnName("iIdSubfamilia");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dValorRecuperable).HasColumnName("dValorRecuperable");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdFamilia).HasColumnName("iIdFamilia");
            entity.Property(e => e.iNumeroCuenta).HasColumnName("iNumeroCuenta");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Familia).WithMany(p => p.Subfamilia)
                .HasForeignKey(d => d.iIdFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subfamilias_iIdFamilia");
        });

        modelBuilder.Entity<EntTipoAdquisicion>(entity =>
        {
            entity.HasKey(e => e.iIdTipoAdquisicion).HasName("PK__TiposAdq__EEEF1254E43B7DDE");

            entity.ToTable("TiposAdquisiciones", "Catalogo");

            entity.Property(e => e.iIdTipoAdquisicion).HasColumnName("iIdTipoAdquisicion");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoAfectacion>(entity =>
        {
            entity.HasKey(e => e.iIdTipoAfectacion).HasName("PK__TiposAfe__83D25A256D08CF76");

            entity.ToTable("TiposAfectaciones", "Catalogo");

            entity.Property(e => e.iIdTipoAfectacion).HasColumnName("iIdTipoAfectacion");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoBien>(entity =>
        {
            entity.HasKey(e => e.iIdTipoBien).HasName("PK__TiposBie__4B7388D5539DAE6D");

            entity.ToTable("TiposBienes", "Catalogo");

            entity.Property(e => e.iIdTipoBien).HasColumnName("iIdTipoBien");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoBienInmueble>(entity =>
        {
            entity.HasKey(e => e.iIdTipoBienInmueble).HasName("PK__TiposBie__87E3D89DA277842F");

            entity.ToTable("TiposBienesInmuebles", "Patrimonio");

            entity.Property(e => e.iIdTipoBienInmueble).HasColumnName("iIdTipoBienInmueble");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iNivel).HasColumnName("iNivel");
            entity.Property(e => e.sClave)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sClave");
            entity.Property(e => e.sClaveCompleta)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("sClaveCompleta");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoDominio>(entity =>
        {
            entity.HasKey(e => e.iIdTipoDominio).HasName("PK__TiposDom__C78CD359EE573C1B");

            entity.ToTable("TiposDominios", "Patrimonio");

            entity.Property(e => e.iIdTipoDominio).HasColumnName("iIdTipoDominio");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoInmueble>(entity =>
        {
            entity.HasKey(e => e.iIdTipoInmueble).HasName("PK__TiposInm__49B853B922078C6C");

            entity.ToTable("TiposInmuebles", "Catalogo");

            entity.Property(e => e.iIdTipoInmueble).HasColumnName("iIdTipoInmueble");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.iIdTipoMovimiento).HasName("PK__TiposMov__F82CF26CA667C3FC");

            entity.ToTable("TiposMovimientos", "Almacen");

            entity.Property(e => e.iIdTipoMovimiento).HasColumnName("iIdTipoMovimiento");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoNivel>(entity =>
        {
            entity.HasKey(e => e.iIdTipoNivel).HasName("PK__TiposNiv__D770DD7B453AB8A8");

            entity.ToTable("TiposNiveles", "General");

            entity.Property(e => e.iIdTipoNivel).HasColumnName("iIdTipoNivel");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iNivel).HasColumnName("iNivel");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoResponsable>(entity =>
        {
            entity.HasKey(e => e.iIdTipoResponsable).HasName("PK__TiposRes__02F6E9C9B8A896AE");

            entity.ToTable("TiposResponsables", "General");

            entity.Property(e => e.iIdTipoResponsable).HasColumnName("iIdTipoResponsable");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion).HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTipoTramite>(entity =>
        {
            entity.HasKey(e => e.iIdTipoTramite).HasName("PK__TiposTra__813A81752F550D06");

            entity.ToTable("TiposTramites", "Patrimonio");

            entity.Property(e => e.iIdTipoTramite).HasColumnName("iIdTipoTramite");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdSubModulo).HasColumnName("iIdSubModulo");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.SubModulo).WithMany(p => p.TiposTramites)
                .HasForeignKey(d => d.iIdSubModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TiposTramites_iIdModulo");
        });

        modelBuilder.Entity<EntTipoVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdTipoVehicular).HasName("PK__TiposVeh__5F0D0A5FBFCFF84D");

            entity.ToTable("TiposVehiculares", "Catalogo");

            entity.Property(e => e.iIdTipoVehicular).HasColumnName("iIdTipoVehicular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntTitular>(entity =>
        {
            entity.HasKey(e => e.iIdTitular).HasName("PK__Titulare__EF0E0BAAA21D90D9");

            entity.ToTable("Titulares", "Catalogo");

            entity.Property(e => e.iIdTitular).HasColumnName("iIdTitular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdCentroTrabajoTurno).HasColumnName("iIdCentroTrabajoTurno");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.CentroTrabajoTurno).WithMany(p => p.Titulares)
                .HasForeignKey(d => d.iIdCentroTrabajoTurno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Titulares_iIdCentroTrabajoTurno");
        });

        modelBuilder.Entity<EntTurno>(entity =>
        {
            entity.HasKey(e => e.iIdTurno).HasName("PK__Turnos__500F725A491F3FA7");

            entity.ToTable("Turnos", "Catalogo");

            entity.Property(e => e.iIdTurno).HasColumnName("iIdTurno");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntUbicacion>(entity =>
        {
            entity.HasKey(e => e.iIdUbicacion).HasName("PK__Ubicacio__D58FC05B12FF04F8");

            entity.ToTable("Ubicaciones", "Catalogo");

            entity.Property(e => e.iIdUbicacion).HasColumnName("iIdUbicacion");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
        });

        modelBuilder.Entity<EntUnidadAdministrativa>(entity =>
        {
            entity.HasKey(e => e.iIdUnidadAdministrativa).HasName("PK__Unidades__D77F6B63230E50D4");

            entity.ToTable("UnidadesAdministrativas", "General");

            entity.Property(e => e.iIdUnidadAdministrativa).HasColumnName("iIdUnidadAdministrativa");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdPeriodo).HasColumnName("iIdPeriodo");
            entity.Property(e => e.iIdTipoNivel).HasColumnName("iIdTipoNivel");
            entity.Property(e => e.sNivelCompleto)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("sNivelCompleto");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Periodo).WithMany(p => p.UnidadesAdministrativas)
                .HasForeignKey(d => d.iIdPeriodo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnidadAdmistrativa_iIdPeriodo");

            entity.HasOne(d => d.TipoNivel).WithMany(p => p.UnidadesAdministrativas)
                .HasForeignKey(d => d.iIdTipoNivel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UnidadesAdministrativas_iIdTipoNivel");
        });

        modelBuilder.Entity<EntUsoInmueble>(entity =>
        {
            entity.HasKey(e => e.iIdUsoInmueble).HasName("PK__UsosInmu__07C98802D1A7AD5A");

            entity.ToTable("UsosInmuebles", "Catalogo");

            entity.Property(e => e.iIdUsoInmueble).HasColumnName("iIdUsoInmueble");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntUsuario>(entity =>
        {
            // se agg manual el pk id
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__A271047F24F29A25");

            entity.ToTable("Usuarios", "Seguridad");

            entity.Property(e => e.Id).HasColumnName("iIdUsuario");
            entity.Property(e => e.EmailConfirmed).HasColumnName("bEmailVerificado");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("sNumero");
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasColumnName("sContraseniaHash");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("sEmail");
            entity.Property(e => e.NormalizedEmail)
                .HasMaxLength(250)
                .HasColumnName("sEmailNormalizado");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("sUsuario");
            entity.Property(e => e.NormalizedUserName)
                .HasMaxLength(100)
                .HasColumnName("sUsuarioNormalizado");
			entity.Property(e => e.SecurityStamp)
                 .IsConcurrencyToken()
                 .HasColumnName("sSelloDeSeguridad")
                 .HasDefaultValueSql("(newid())");
             entity.Property(e => e.ConcurrencyStamp)
                 .HasColumnName("sSelloDeConcorrencia")
                 .HasDefaultValueSql("(newid())");
             entity.Property(e => e.TwoFactorEnabled)
                 .HasColumnName("bHabilitarDosFactores");
             entity.Property(e => e.LockoutEnabled)
                 .HasColumnName("bBloqueoHabilitado");
             entity.Property(e => e.LockoutEnd)
                 .HasColumnName("dtFinDeBloqueo")
                 .HasColumnType("datetimeoffset");
             entity.Property(e => e.AccessFailedCount)
                 .HasColumnName("iContadorFallosDeAcceso");
             entity.Property(e => e.PhoneNumberConfirmed)
                 .HasColumnName("bTelefonoConfirmado");

        });

        modelBuilder.Entity<EntUsuarioPermiso>(entity =>
        {
            entity.HasKey(e => e.iIdUsuarioPermiso).HasName("PK__Usuarios__883428D11651BC3E");

            entity.ToTable("UsuariosPermisos", "Seguridad");

            entity.Property(e => e.iIdUsuarioPermiso).HasColumnName("iIdUsuarioPermiso");
            entity.Property(e => e.iIdPermiso).HasColumnName("iIdPermiso");
            entity.Property(e => e.iIdUsuario).HasColumnName("iIdUsuario");

            entity.HasOne(d => d.Permiso).WithMany(p => p.UsuariosPermisos)
                .HasForeignKey(d => d.iIdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuariosPermisos_iIdPermiso");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuariosPermisos)
                .HasForeignKey(d => d.iIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuariosPermisos_iIdUsuario");
        });

          modelBuilder.Entity<EntUsuarioRol>(entity =>
        {
            entity.ToTable("UsuariosRoles", "Seguridad").HasKey(e => new { e.RoleId, e.UserId });

            entity.Property(e => e.RoleId).HasColumnName("iIdRol");
            entity.Property(e => e.UserId).HasColumnName("iIdUsuario");

            entity.HasOne(d => d.Rol).WithMany(e => e.UsuarioRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuariosRoles_iIdRolUsuario");

            entity.HasOne(d => d.Usuario).WithMany(e => e.UsuarioRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuariosRoles_iIdUsuario");
        });


          modelBuilder.Entity<EntVersionVehicular>(entity =>
        {
            entity.HasKey(e => e.iIdVersionVehicular).HasName("PK__Versione__350D2B2C8729296B");

            entity.ToTable("VersionesVehiculares", "Catalogo");

            entity.Property(e => e.iIdVersionVehicular).HasColumnName("iIdVersionVehicular");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.sDescripcion)
                .IsRequired()
                .HasColumnName("sDescripcion");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<EntZona>(entity =>
        {
            entity.HasKey(e => e.iIdZona).HasName("PK__Zonas__F19B8E6683987BB2");

            entity.ToTable("Zonas", "Catalogo");

            entity.Property(e => e.iIdZona).HasColumnName("iIdZona");
            entity.Property(e => e.bActivo).HasColumnName("bActivo");
            entity.Property(e => e.dtFechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaCreacion");
            entity.Property(e => e.dtFechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dtFechaModificacion");
            entity.Property(e => e.iIdAlmacen).HasColumnName("iIdAlmacen");
            entity.Property(e => e.sNombre)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.Almacen).WithMany(p => p.Zonas)
                .HasForeignKey(d => d.iIdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zonas_iIdAlmacen");
        });

          // Configuración de la tabla AspNetUserClaims
          modelBuilder.Entity<IdentityUserClaim<long>>()
              .ToTable("AspNetUserClaims")
              .HasKey(c => c.Id);  // Definir la clave primaria

          // Configuración de la tabla AspNetUserLogins
          modelBuilder.Entity<IdentityUserLogin<long>>()
              .ToTable("AspNetUserLogins")
              .HasNoKey();  // Definir la clave primaria, puedes ajustar si es necesario

          // Configuración de la tabla AspNetRoleClaims
          modelBuilder.Entity<IdentityRoleClaim<long>>()
              .ToTable("AspNetRoleClaims")
              .HasKey(r => r.Id);  // Definir la clave primaria

          // Configuración de la tabla AspNetUserTokens
          modelBuilder.Entity<IdentityUserToken<long>>()
              .ToTable("AspNetUserTokens")
              .HasNoKey();  // Definir la clave primaria compuesta

          modelBuilder.ApplyConfiguration(new BusPersonaConfiguracion());
          modelBuilder.ApplyConfiguration(new BusUsuarioConfiguracion());
          modelBuilder.ApplyConfiguration(new BusEmpleadoConfiguracion());

          OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
