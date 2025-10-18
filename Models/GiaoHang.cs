using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("GiaoHang")]
public partial class GiaoHang
{
    [Key]
    public int MaGiaoHang { get; set; }

    public int? MaDon { get; set; }

    public int? MaShipper { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayGiao { get; set; }

    [StringLength(50)]
    public string? TrangThaiGiao { get; set; }

    [StringLength(200)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaDon")]
    [InverseProperty("GiaoHangs")]
    public virtual DonNhanNuoi? MaDonNavigation { get; set; }

    [ForeignKey("MaShipper")]
    [InverseProperty("GiaoHangs")]
    public virtual NguoiDung? MaShipperNavigation { get; set; }
}
