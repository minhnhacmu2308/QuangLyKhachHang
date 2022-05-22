using QuanLyKhachHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachHang.Dao
{
    public class HopDongDao
    {
        DBQLContext myDb = new DBQLContext();
        public List<HopDong> GetAll()
        {
            return myDb.hopDongs.ToList();
        }
    }
}