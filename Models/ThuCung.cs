using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("ThuCung")]
public partial class ThuCung
{
    [Key]
    public int MaThuCung { get; set; }

    [StringLength(100)]
    public string TenThuCung { get; set; } = null!;

    [StringLength(10)]
    public string? GioiTinh { get; set; }

    public int? Tuoi { get; set; }

    [StringLength(500)]
    public string? MoTa { get; set; }

    [StringLength(255)]
    public string? Anh { get; set; }

    [StringLength(50)]
    public string? TrangThai { get; set; }

    public int? MaLoai { get; set; }

    [InverseProperty("MaThuCungNavigation")]
    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    [InverseProperty("MaThuCungNavigation")]
    public virtual ICollection<ChamSocThuCung> ChamSocThuCungs { get; set; } = new List<ChamSocThuCung>();

    [InverseProperty("MaThuCungNavigation")]
    public virtual ICollection<DonNhanNuoi> DonNhanNuois { get; set; } = new List<DonNhanNuoi>();

    [ForeignKey("MaLoai")]
    [InverseProperty("ThuCungs")]
    public virtual DanhMucLoai? MaLoaiNavigation { get; set; }
}
