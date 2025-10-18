using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("NguoiDung")]
[Index("Email", Name = "UQ__NguoiDun__A9D105342356BA11", IsUnique = true)]
public partial class NguoiDung
{
    [Key]
    public int MaNguoiDung { get; set; }

    [StringLength(100)]
    public string HoTen { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string MatKhau { get; set; } = null!;

    [StringLength(50)]
    public string? VaiTro { get; set; }

    [StringLength(20)]
    public string? SoDienThoai { get; set; }

    [StringLength(200)]
    public string? DiaChi { get; set; }

    [StringLength(255)]
    public string? AnhDaiDien { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayDangKy { get; set; }

    [StringLength(30)]
    public string? TrangThai { get; set; }

    [InverseProperty("MaNguoiDungNavigation")]
    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<ChamSocThuCung> ChamSocThuCungs { get; set; } = new List<ChamSocThuCung>();

    [InverseProperty("MaNguoiDungNavigation")]
    public virtual ICollection<DonNhanNuoi> DonNhanNuois { get; set; } = new List<DonNhanNuoi>();

    [InverseProperty("MaShipperNavigation")]
    public virtual ICollection<GiaoHang> GiaoHangs { get; set; } = new List<GiaoHang>();

    [InverseProperty("MaNguoiDungNavigation")]
    public virtual ICollection<ThongBao> ThongBaos { get; set; } = new List<ThongBao>();
}
