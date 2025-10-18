using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("ThongBao")]
public partial class ThongBao
{
    [Key]
    public int MaThongBao { get; set; }

    public int? MaNguoiDung { get; set; }

    [StringLength(500)]
    public string? NoiDung { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayGui { get; set; }

    public bool? DaDoc { get; set; }

    [ForeignKey("MaNguoiDung")]
    [InverseProperty("ThongBaos")]
    public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
}
