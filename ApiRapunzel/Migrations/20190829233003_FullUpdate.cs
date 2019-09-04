using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRapunzel.Migrations
{
    public partial class FullUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Documento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCitas",
                columns: table => new
                {
                    IdEstadoCita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCitas", x => x.IdEstadoCita);
                });

            migrationBuilder.CreateTable(
                name: "Estilistas",
                columns: table => new
                {
                    IdEstilista = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estilistas", x => x.IdEstilista);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<string>(nullable: true),
                    Hora = table.Column<string>(nullable: true),
                    IdEstadoCita = table.Column<int>(nullable: false),
                    IdEstilista = table.Column<int>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Citas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_EstadoCitas_IdEstadoCita",
                        column: x => x.IdEstadoCita,
                        principalTable: "EstadoCitas",
                        principalColumn: "IdEstadoCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Estilistas_IdEstilista",
                        column: x => x.IdEstilista,
                        principalTable: "Estilistas",
                        principalColumn: "IdEstilista",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdCliente",
                table: "Citas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdEstadoCita",
                table: "Citas",
                column: "IdEstadoCita");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdEstilista",
                table: "Citas",
                column: "IdEstilista");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstadoCitas");

            migrationBuilder.DropTable(
                name: "Estilistas");
        }
    }
}
