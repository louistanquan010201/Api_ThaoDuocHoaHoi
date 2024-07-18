using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowChoThanh.Migrations.ThaoDuocHoaHoiDb
{
    /// <inheritdoc />
    public partial class e4eq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    MaDanhMuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.MaDanhMuc);
                });

            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnhKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "MayHoaHois",
                columns: table => new
                {
                    MaMay = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MoTaMay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiamGia = table.Column<int>(type: "int", nullable: false),
                    MaDanhMuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayThem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MayHoaHois", x => x.MaMay);
                    table.ForeignKey(
                        name: "FK_MayHoaHois_DanhMucs_MaDanhMuc",
                        column: x => x.MaDanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "MaDanhMuc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    MaThanhToan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.MaThanhToan);
                    table.ForeignKey(
                        name: "FK_ThanhToans_khachHangs_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "khachHangs",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnhMayHoaHois",
                columns: table => new
                {
                    MaAnh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMay = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LinkAnh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnhMayHoaHois", x => x.MaAnh);
                    table.ForeignKey(
                        name: "FK_AnhMayHoaHois_MayHoaHois_MaMay",
                        column: x => x.MaMay,
                        principalTable: "MayHoaHois",
                        principalColumn: "MaMay",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThanhToans",
                columns: table => new
                {
                    MaChiTietThanhToan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMay = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaThanhToan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietThanhToans", x => x.MaChiTietThanhToan);
                    table.ForeignKey(
                        name: "FK_ChiTietThanhToans_MayHoaHois_MaMay",
                        column: x => x.MaMay,
                        principalTable: "MayHoaHois",
                        principalColumn: "MaMay",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietThanhToans_ThanhToans_MaThanhToan",
                        column: x => x.MaThanhToan,
                        principalTable: "ThanhToans",
                        principalColumn: "MaThanhToan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnhMayHoaHois_MaMay",
                table: "AnhMayHoaHois",
                column: "MaMay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhToans_MaMay",
                table: "ChiTietThanhToans",
                column: "MaMay");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThanhToans_MaThanhToan",
                table: "ChiTietThanhToans",
                column: "MaThanhToan");

            migrationBuilder.CreateIndex(
                name: "IX_MayHoaHois_MaDanhMuc",
                table: "MayHoaHois",
                column: "MaDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_MaKhachHang",
                table: "ThanhToans",
                column: "MaKhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnhMayHoaHois");

            migrationBuilder.DropTable(
                name: "ChiTietThanhToans");

            migrationBuilder.DropTable(
                name: "MayHoaHois");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "khachHangs");
        }
    }
}
