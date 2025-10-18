using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("BaiDang")]
public partial class BaiDang
{
    [Key]
    public int MaBaiDang { get; set; }

    public int? MaNguoiDung { get; set; }

    public int? MaThuCung { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayDang { get; set; }

    [StringLength(200)]
    public string? TieuDe { get; set; }

    [StringLength(1000)]
    public string? NoiDung { get; set; }

    [StringLength(50)]
    public string? TrangThai { get; set; }

    [ForeignKey("MaNguoiDung")]
    [InverseProperty("BaiDangs")]
    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }

    [ForeignKey("MaThuCung")]
    [InverseProperty("BaiDangs")]
    public virtual ThuCung? MaThuCungNavigation { get; set; }
}
