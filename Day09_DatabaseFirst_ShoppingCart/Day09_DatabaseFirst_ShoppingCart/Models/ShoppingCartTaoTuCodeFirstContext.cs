using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day09_DatabaseFirst_ShoppingCart.Models;

public partial class ShoppingCartTaoTuCodeFirstContext : DbContext
{
    public ShoppingCartTaoTuCodeFirstContext()
    {
    }

    public ShoppingCartTaoTuCodeFirstContext(DbContextOptions<ShoppingCartTaoTuCodeFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TRINHVAN\\\\\\\\SQLEXPRESS,1433; Database=ShoppingCart_TaoTuCodeFirst; Trusted_Connection=True; User Instance=False; MultipleActiveResultSets=True; Encrypt=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasIndex(e => e.HoaDonId, "IX_ChiTietHoaDons_HoaDonID");

            entity.HasIndex(e => e.SanPhamId, "IX_ChiTietHoaDons_SanPhamID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.ChiTietHoaDons).HasForeignKey(d => d.HoaDonId);

            entity.HasOne(d => d.SanPham).WithMany(p => p.ChiTietHoaDons).HasForeignKey(d => d.SanPhamId);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasIndex(e => e.KhachHangId, "IX_HoaDons_KhachHangID");

            entity.HasIndex(e => e.QuanTriId, "IX_HoaDons_QuanTriID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KhachHangId).HasColumnName("KhachHangID");
            entity.Property(e => e.QuanTriId).HasColumnName("QuanTriID");
            entity.Property(e => e.TongTriGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.KhachHang).WithMany(p => p.HoaDons).HasForeignKey(d => d.KhachHangId);

            entity.HasOne(d => d.QuanTri).WithMany(p => p.HoaDons).HasForeignKey(d => d.QuanTriId);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasIndex(e => e.LoaiSanPhamId, "IX_SanPhams_LoaiSanPhamID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoaiSanPhamId).HasColumnName("LoaiSanPhamID");

            entity.HasOne(d => d.LoaiSanPham).WithMany(p => p.SanPhams).HasForeignKey(d => d.LoaiSanPhamId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
