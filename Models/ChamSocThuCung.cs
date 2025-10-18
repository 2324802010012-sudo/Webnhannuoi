using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("ChamSocThuCung")]
public partial class ChamSocThuCung
{
    [Key]
    public int MaChamSoc { get; set; }

    public int? MaThuCung { get; set; }

    public int? MaNhanVien { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayKiemTra { get; set; }

    [StringLength(200)]
    public string? TinhTrangSucKhoe { get; set; }

    public bool? TiemPhong { get; set; }

    [StringLength(200)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("ChamSocThuCungs")]
    public virtual NguoiDung? MaNhanVienNavigation { get; set; }

    [ForeignKey("MaThuCung")]
    [InverseProperty("ChamSocThuCungs")]
    public virtual ThuCung? MaThuCungNavigation { get; set; }
}
