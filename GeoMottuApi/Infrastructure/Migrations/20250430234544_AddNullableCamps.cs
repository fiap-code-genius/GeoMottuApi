using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableCamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO");

            migrationBuilder.AlterColumn<string>(
                name: "PLACA_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CD_IOT_PLACA",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                columns: new[] { "PLACA_MOTO", "CD_IOT_PLACA", "CHASSI_MOTO" },
                unique: true,
                filter: "\"PLACA_MOTO\" IS NOT NULL AND \"CD_IOT_PLACA\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO");

            migrationBuilder.AlterColumn<string>(
                name: "PLACA_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CD_IOT_PLACA",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_GEOMOTTU_MOTO_PLACA_MOTO_CD_IOT_PLACA_CHASSI_MOTO",
                table: "TB_GEOMOTTU_MOTO",
                columns: new[] { "PLACA_MOTO", "CD_IOT_PLACA", "CHASSI_MOTO" },
                unique: true);
        }
    }
}
