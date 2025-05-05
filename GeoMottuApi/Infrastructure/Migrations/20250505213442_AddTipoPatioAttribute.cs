using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoPatioAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TIPO_PATIO",
                table: "TB_GEOMOTTU_PATIO",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TIPO_PATIO",
                table: "TB_GEOMOTTU_PATIO",
                type: "NUMBER(10)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);
        }
    }
}
