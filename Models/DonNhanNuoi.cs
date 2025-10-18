using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("DonNhanNuoi")]
public partial class DonNhanNuoi
{
    [Key]
    public int MaDon { get; set; }

    public int? MaNguoiDung { get; set; }

    public int? MaThuCung { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayGui { get; set; }

    [StringLength(500)]
    public string? LyDo { get; set; }

    [StringLength(200)]
    public string? DiaChiNhan { get; set; }

    [StringLength(50)]
    public string? TrangThai { get; set; }

    [InverseProperty("MaDonNavigation")]
    public virtual ICollection<GiaoHang> GiaoHangs { get; set; } = new List<GiaoHang>();

    [ForeignKey("MaNguoiDung")]
    [InverseProperty("DonNhanNuois")]
    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }

    [ForeignKey("MaThuCung")]
    [InverseProperty("DonNhanNuois")]
    public virtual ThuCung? MaThuCungNavigation { get; set; }
}
