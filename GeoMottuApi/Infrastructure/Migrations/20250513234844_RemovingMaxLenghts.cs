using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovingMaxLenghts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TIPO_PATIO",
                table: "TB_GEOMOTTU_PATIO",
                newName: "TipoDoPatio");

            migrationBuilder.AlterColumn<string>(
                name: "MOTO_MODELO",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PAIS_FILIAL",
                table: "TB_GEOMOTTU_FILIAL",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoDoPatio",
                table: "TB_GEOMOTTU_PATIO",
                newName: "TIPO_PATIO");

            migrationBuilder.AlterColumn<string>(
                name: "MOTO_MODELO",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "PAIS_FILIAL",
                table: "TB_GEOMOTTU_FILIAL",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }
    }
}
