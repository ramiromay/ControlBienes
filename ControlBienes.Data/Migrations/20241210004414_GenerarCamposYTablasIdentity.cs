using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlBienes.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenerarCamposYTablasIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "Personas",
                columns: new[] { "iIdPersona", "bHombre", "dtFechaNacimiento", "iIdNacionalidad", "sNombres", "sPrimerNombre", "sRFC", "sSegundoNombre" },
                values: new object[] { 1L, true, new DateTime(2024, 12, 9, 18, 44, 13, 998, DateTimeKind.Local).AddTicks(2843), 1L, "Administrador", "", "RRRRRRRRRR", "" });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "Usuarios",
                columns: new[] { "iIdUsuario", "AccessFailedCount", "ConcurrencyStamp", "sEmail", "bEmailVerificado", "LockoutEnabled", "LockoutEnd", "sEmailNormalizado", "sUsuarioNormalizado", "sContraseniaHash", "sNumero", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "sUsuario" },
                values: new object[] { 1L, 0, "2935de34-8ec6-4388-9596-c5379439b33c", "administrador@sicba.com", true, false, null, "ADMINISTRADOR@SICBA.COM", "ADMINISTRADOR", "AQAAAAEAACcQAAAAEJM8u9v79l1yXx5xoHVfu13YzB0FEdvjSI+fLW5Q6VAkz08z+4SyWvwPslmEjoF8RQ==", "99999999", true, null, false, "administrador" });

            migrationBuilder.InsertData(
                schema: "Seguridad",
                table: "Empleados",
                columns: new[] { "iIdEmpleado", "bActivo", "dtFechaIngreso", "iIdNombramiento", "iIdPersona", "iIdUsuario" },
                values: new object[] { 1L, true, new DateTime(2024, 12, 9, 18, 44, 13, 999, DateTimeKind.Local).AddTicks(7704), 6L, 1L, 1L });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anaqueles",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaracteristicasBienes",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "ColumnasTablas",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "DatosGenerales",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Depreciaciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Documentos",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "EtapasTramites",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Historiales",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "MovimientosBienes",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "Resguardantes",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "RolesPermisos",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Seguimientos",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "TiposBienesInmuebles",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Titulares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "UsuariosPermisos",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "UsuariosRoles",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Zonas",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Catalogos",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "ClasesVehiculares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "ClavesVehiculares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Colores",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "CombustiblesVehiculares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "LineasVehiculares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Marcas",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "TiposVehiculares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "VersionesVehiculares",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Bienes",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "Movimientos",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "TiposResponsables",
                schema: "General");

            migrationBuilder.DropTable(
                name: "DetallesSolicitudes",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "CentroTrabajoTurnos",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Almacenes",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "ConceptosMovimientos",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "FuentesFinanciamiento",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "MetodosAdquisicion",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "ProgramasOperativos",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "Proveedores",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "DetallesAltas",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesBajas",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesDesincorporaciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesDestinoFinales",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesModificaciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesMovimientos",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "CentrosTrabajo",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Turnos",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Cuentas",
                schema: "General");

            migrationBuilder.DropTable(
                name: "MetodosCosteo",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "TiposMovimientos",
                schema: "Almacen");

            migrationBuilder.DropTable(
                name: "Facturas",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Licitaciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Bajas",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "BajasInmuebles",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesDestrucciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DetallesEnagenaciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Solicitudes",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "DatosVehiculares",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Bienes",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Afectaciones",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Empleados",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Etapas",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "MotivosTramites",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "BMS",
                schema: "General");

            migrationBuilder.DropTable(
                name: "DatosInmuebles",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "EstadosFisicos",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Municipios",
                schema: "General");

            migrationBuilder.DropTable(
                name: "TiposAdquisiciones",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Ubicaciones",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "UnidadesAdministrativas",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Nombramientos",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Personas",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "Seguridad");

            migrationBuilder.DropTable(
                name: "TiposTramites",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Subfamilias",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "EstadosGenerales",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "DatosRegistrales",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "TiposAfectaciones",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "TiposDominios",
                schema: "Patrimonio");

            migrationBuilder.DropTable(
                name: "TiposInmuebles",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "UsosInmuebles",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Periodos",
                schema: "General");

            migrationBuilder.DropTable(
                name: "TiposNiveles",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Nacionalidades",
                schema: "General");

            migrationBuilder.DropTable(
                name: "SubModulos",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "Familias",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "OrigenesValores",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Modulos",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "Secciones",
                schema: "Sistema");

            migrationBuilder.DropTable(
                name: "TiposBienes",
                schema: "Catalogo");

            migrationBuilder.DropTable(
                name: "Permisos",
                schema: "Seguridad");
        }
    }
}
