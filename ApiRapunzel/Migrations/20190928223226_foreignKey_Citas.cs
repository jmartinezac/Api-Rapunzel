using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRapunzel.Migrations
{
    public partial class foreignKey_Citas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_EstadoCitas_IdEstadoCita",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_IdEstadoCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "IdEstadoCita",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "EstadoCitaIdEstadoCita",
                table: "Citas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EstadoCitaIdEstadoCita",
                table: "Citas",
                column: "EstadoCitaIdEstadoCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_EstadoCitas_EstadoCitaIdEstadoCita",
                table: "Citas",
                column: "EstadoCitaIdEstadoCita",
                principalTable: "EstadoCitas",
                principalColumn: "IdEstadoCita",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_EstadoCitas_EstadoCitaIdEstadoCita",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_EstadoCitaIdEstadoCita",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "EstadoCitaIdEstadoCita",
                table: "Citas");

            migrationBuilder.AddColumn<int>(
                name: "IdEstadoCita",
                table: "Citas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_IdEstadoCita",
                table: "Citas",
                column: "IdEstadoCita");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_EstadoCitas_IdEstadoCita",
                table: "Citas",
                column: "IdEstadoCita",
                principalTable: "EstadoCitas",
                principalColumn: "IdEstadoCita",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
