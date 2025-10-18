using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Webnhannuoi.Models;

namespace Webnhannuoi.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiDang> BaiDangs { get; set; }

    public virtual DbSet<ChamSocThuCung> ChamSocThuCungs { get; set; }

    public virtual DbSet<DanhMucLoai> DanhMucLoais { get; set; }

    public virtual DbSet<DonNhanNuoi> DonNhanNuois { get; set; }

    public virtual DbSet<GiaoHang> GiaoHangs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<ThongBao> ThongBaos { get; set; }

    public virtual DbSet<ThuCung> ThuCungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-JB4U48JA\\SQLEXPRESS01;Initial Catalog=WebNhanNuoi;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiDang>(entity =>
        {
            entity.HasKey(e => e.MaBaiDang).HasName("PK__BaiDang__BF5D50C577CAB44A");

            entity.Property(e => e.NgayDang).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThai).HasDefaultValue("Chờ duyệt");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.BaiDangs).HasConstraintName("FK__BaiDang__MaNguoi__5BE2A6F2");

            entity.HasOne(d => d.MaThuCungNavigation).WithMany(p => p.BaiDangs).HasConstraintName("FK__BaiDang__MaThuCu__5CD6CB2B");
        });

        modelBuilder.Entity<ChamSocThuCung>(entity =>
        {
            entity.HasKey(e => e.MaChamSoc).HasName("PK__ChamSocT__5F6188644A39AF97");

            entity.Property(e => e.NgayKiemTra).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TiemPhong).HasDefaultValue(false);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.ChamSocThuCungs).HasConstraintName("FK__ChamSocTh__MaNha__571DF1D5");

            entity.HasOne(d => d.MaThuCungNavigation).WithMany(p => p.ChamSocThuCungs).HasConstraintName("FK__ChamSocTh__MaThu__5629CD9C");
        });

        modelBuilder.Entity<DanhMucLoai>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__DanhMucL__730A57595B93E6AB");
        });

        modelBuilder.Entity<DonNhanNuoi>(entity =>
        {
            entity.HasKey(e => e.MaDon).HasName("PK__DonNhanN__3D89F56849D8CE19");

            entity.Property(e => e.NgayGui).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThai).HasDefaultValue("Chờ lễ tân xử lý");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.DonNhanNuois).HasConstraintName("FK__DonNhanNu__MaNgu__619B8048");

            entity.HasOne(d => d.MaThuCungNavigation).WithMany(p => p.DonNhanNuois).HasConstraintName("FK__DonNhanNu__MaThu__628FA481");
        });

        modelBuilder.Entity<GiaoHang>(entity =>
        {
            entity.HasKey(e => e.MaGiaoHang).HasName("PK__GiaoHang__81CCF4FDDD337099");

            entity.Property(e => e.TrangThaiGiao).HasDefaultValue("Đang chờ giao");

            entity.HasOne(d => d.MaDonNavigation).WithMany(p => p.GiaoHangs).HasConstraintName("FK__GiaoHang__MaDon__6754599E");

            entity.HasOne(d => d.MaShipperNavigation).WithMany(p => p.GiaoHangs).HasConstraintName("FK__GiaoHang__MaShip__68487DD7");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D762AADA075B");

            entity.Property(e => e.NgayDangKy).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThai).HasDefaultValue("Hoạt động");
            entity.Property(e => e.VaiTro).HasDefaultValue("Người dùng");
        });

        modelBuilder.Entity<ThongBao>(entity =>
        {
            entity.HasKey(e => e.MaThongBao).HasName("PK__ThongBao__04DEB54E684011F8");

            entity.Property(e => e.DaDoc).HasDefaultValue(false);
            entity.Property(e => e.NgayGui).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.ThongBaos).HasConstraintName("FK__ThongBao__MaNguo__6C190EBB");
        });

        modelBuilder.Entity<ThuCung>(entity =>
        {
            entity.HasKey(e => e.MaThuCung).HasName("PK__ThuCung__59E3EA925A8D9333");

            entity.Property(e => e.TrangThai).HasDefaultValue("Đang được chăm sóc");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.ThuCungs).HasConstraintName("FK__ThuCung__MaLoai__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
