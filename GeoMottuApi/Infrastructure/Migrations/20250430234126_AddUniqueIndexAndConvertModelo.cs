using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexAndConvertModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CD_IOT_PLACA",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                columns: new[] { "PLACA_MOTO", "CD_IOT_PLACA", "CHASSI_MOTO" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO");

            migrationBuilder.AlterColumn<string>(
                name: "CD_IOT_PLACA",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");
        }
    }
}
