using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Webnhannuoi.Models;

[Table("DanhMucLoai")]
public partial class DanhMucLoai
{
    [Key]
    public int MaLoai { get; set; }

    [StringLength(50)]
    public string TenLoai { get; set; } = null!;

    [InverseProperty("MaLoaiNavigation")]
    public virtual ICollection<ThuCung> ThuCungs { get; set; } = new List<ThuCung>();
}
