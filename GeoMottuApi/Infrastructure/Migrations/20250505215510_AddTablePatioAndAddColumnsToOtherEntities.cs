using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTablePatioAndAddColumnsToOtherEntities : Migration
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
                    DT_REGISTRO_FILIAL = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_FILIAL", x => x.ID_FILIAL);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_FILIAL");
        }
    }
}
