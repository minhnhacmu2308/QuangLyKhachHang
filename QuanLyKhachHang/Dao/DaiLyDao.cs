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

        public void Add(DaiLy daiLy)
        {
            myDb.daiLies.Add(daiLy);
            myDb.SaveChanges();
        }

        public void Delete(int idDaiLy)
        {
            var obj = myDb.daiLies.FirstOrDefault(x => x.idDaiLy == idDaiLy);
            myDb.daiLies.Remove(obj);
            myDb.SaveChanges();
        }

        public bool checkExist(string tenDaiLy)
        {
            var obj = myDb.daiLies.FirstOrDefault(x => x.tenDaiLy == tenDaiLy);
            if (obj != null) { return true; }
            return false;
        }

        public void Update(DaiLy daiLy)
        {
            var obj = myDb.daiLies.FirstOrDefault(x => x.idDaiLy == daiLy.idDaiLy);
            obj.chuDaiLy = daiLy.chuDaiLy;
            obj.tenDaiLy = daiLy.tenDaiLy;
            obj.nganhBuonBan = daiLy.nganhBuonBan;
            obj.diaChi = daiLy.diaChi;         
            myDb.SaveChanges();
        }

        public DaiLy GetDaiLyById(int id)
        {
            return myDb.daiLies.FirstOrDefault(x => x.idDaiLy == id);
        }
    }
}