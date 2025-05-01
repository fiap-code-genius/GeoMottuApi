using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateTablesPatioAndUsuarioAndChangesOnMotoCamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MOTO_ID",
                table: "TB_GEOMOTTU_MOTO",
                newName: "ID_MOTO");

            migrationBuilder.CreateTable(
                name: "TB_GEOMOTTU_PATIO",
                columns: table => new
                {
                    ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CAPC_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    REFERENCIA_PATIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_PATIO", x => x.ID_PATIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_GEOMOTTU_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_USUARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    SENHA_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_REGISTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_GEOMOTTU_USUARIO_EMAIL_FUNCIONARIO",
                table: "TB_GEOMOTTU_USUARIO",
                column: "EMAIL_FUNCIONARIO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_PATIO");

            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_USUARIO");

            migrationBuilder.RenameColumn(
                name: "ID_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                newName: "MOTO_ID");
        }
    }
}
