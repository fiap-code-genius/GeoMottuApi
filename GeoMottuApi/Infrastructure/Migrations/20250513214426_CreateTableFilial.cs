using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableFilial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_GEOMOTTU_FILIAL",
                columns: table => new
                {
                    ID_FILIAL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_FILIAL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PAIS_FILIAL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ESTADO_FILIAL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ENDERECO_FILIAL = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_FILIAL", x => x.ID_FILIAL);
                });

            migrationBuilder.CreateTable(
                name: "TB_GEOMOTTU_MOTO",
                columns: table => new
                {
                    ID_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLACA_MOTO = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    CHASSI_MOTO = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    CD_IOT_PLACA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    MOTO_MODELO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MOTOR_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MOTO_PROPRIETARIO = table.Column<string>(type: "NVARCHAR2(150)", maxLength: 150, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_MOTO", x => x.ID_MOTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_GEOMOTTU_PATIO",
                columns: table => new
                {
                    ID_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CAPC_PATIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    REFERENCIA_PATIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TIPO_PATIO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
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
                    CadastradoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                columns: new[] { "PLACA_MOTO", "CD_IOT_PLACA", "CHASSI_MOTO" },
                unique: true,
                filter: "\"PLACA_MOTO\" IS NOT NULL AND \"CD_IOT_PLACA\" IS NOT NULL");

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
                name: "TB_GEOMOTTU_FILIAL");

            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_MOTO");

            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_PATIO");

            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_USUARIO");
        }
    }
}
