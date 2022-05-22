using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachHang.Models
{
    public class HopDong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHopDong { get; set; }

        [StringLength(255)]
        public string ngayKy { get; set; }

        [StringLength(255)]
        public string thoiHan { get; set; }

        public int tongTien { get; set; }

        public int idNguoiDung { get; set; }

        public int idDaiLy { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        public virtual DaiLy DaiLy { get; set; }


    }
}