using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvtDay10LabCf.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TvtLoai_San_Pham",
                columns: table => new
                {
                    tvtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvtMaLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtTenLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvtLoai_San_Pham", x => x.tvtId);
                });

            migrationBuilder.CreateTable(
                name: "TvtSan_Pham",
                columns: table => new
                {
                    tvtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvtMaSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvtSoLuong = table.Column<int>(type: "int", nullable: false),
                    tvtDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tvtMaLoai = table.Column<long>(type: "bigint", nullable: false),
                    tvtTrangThai = table.Column<bool>(type: "bit", nullable: false),
                    TvtLoai_San_PhamtvtId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvtSan_Pham", x => x.tvtId);
                    table.ForeignKey(
                        name: "FK_TvtSan_Pham_TvtLoai_San_Pham_TvtLoai_San_PhamtvtId",
                        column: x => x.TvtLoai_San_PhamtvtId,
                        principalTable: "TvtLoai_San_Pham",
                        principalColumn: "tvtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvtSan_Pham_TvtLoai_San_PhamtvtId",
                table: "TvtSan_Pham",
                column: "TvtLoai_San_PhamtvtId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvtSan_Pham");

            migrationBuilder.DropTable(
                name: "TvtLoai_San_Pham");
        }
    }
}
