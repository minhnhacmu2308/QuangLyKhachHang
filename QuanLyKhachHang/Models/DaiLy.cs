using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachHang.Models
{
    public class DaiLy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDaiLy { get; set; }

        [StringLength(255)]
        public string chuDaiLy { get; set; }

        [StringLength(255)]
        public string tenDaiLy { get; set; }

        public string diaChi { get; set; }

        public string nganhBuonBan { get; set; }

        public virtual ICollection<HopDong> HopDongs { get; set; }

    }
}