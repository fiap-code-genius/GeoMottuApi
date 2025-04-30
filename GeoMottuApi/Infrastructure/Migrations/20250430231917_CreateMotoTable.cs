using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoMottuApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateMotoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_GEOMOTTU_MOTO",
                columns: table => new
                {
                    MOTO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PLACA_MOTO = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    CHASSI_MOTO = table.Column<string>(type: "NVARCHAR2(17)", maxLength: 17, nullable: false),
                    CD_IOT_PLACA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MOTO_MODELO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MOTOR_MOTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GEOMOTTU_MOTO", x => x.MOTO_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_GEOMOTTU_MOTO");
        }
    }
}
