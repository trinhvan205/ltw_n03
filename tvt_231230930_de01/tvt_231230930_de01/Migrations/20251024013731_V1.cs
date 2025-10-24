using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tvt_231230930_de01.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TvtComputer",
                columns: table => new
                {
                    tvtComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvtComName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtComprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tvtComImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtComStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvtComputer", x => x.tvtComId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvtComputer");
        }
    }
}
