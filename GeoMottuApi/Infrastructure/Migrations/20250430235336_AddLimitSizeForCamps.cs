using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLimitSizeForCamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MOTO_MODELO",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "CD_IOT_PLACA",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MOTO_MODELO",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CD_IOT_PLACA",
                table: "TB_GEOMOTTU_MOTO",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
