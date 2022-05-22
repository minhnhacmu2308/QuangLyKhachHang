using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachHang.Models
{
    public class NguoiDung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idNguoiDung { get; set; }

        [StringLength(255)]
        public string hoTen { get; set; }

        [StringLength(255)]
        public string soDienThoai { get; set; }
        public string gioiTinh { get; set; }

        [StringLength(255)]
        public string diaChi { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string ngheNghiep { get; set; }

        public string loaiKhachHang { get; set; }

        public int role { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }

    }
}