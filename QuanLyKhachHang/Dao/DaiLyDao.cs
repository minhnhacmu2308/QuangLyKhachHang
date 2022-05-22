using QuanLyKhachHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachHang.Dao
{
    public class DaiLyDao
    {
        DBQLContext myDb = new DBQLContext();

        public List<DaiLy> GetAll()
        {
            return myDb.daiLies.ToList();
        }
    }
}