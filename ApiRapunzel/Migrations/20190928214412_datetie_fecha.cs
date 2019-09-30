using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRapunzel.Migrations
{
    public partial class datetie_fecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "Citas",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
