using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvtDay10LabCf.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    tvtMaLoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tvtTenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    tvtLoaiId = table.Column<long>(type: "bigint", nullable: false),
                    tvtTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvtSan_Pham", x => x.tvtId);
                    table.ForeignKey(
                        name: "FK_TvtSan_Pham_TvtLoai_San_Pham_tvtLoaiId",
                        column: x => x.tvtLoaiId,
                        principalTable: "TvtLoai_San_Pham",
                        principalColumn: "tvtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvtSan_Pham_tvtLoaiId",
                table: "TvtSan_Pham",
                column: "tvtLoaiId");
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
