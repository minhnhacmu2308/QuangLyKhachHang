using QuanLyKhachHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachHang.Dao
{
    public class NguoiDungDao
    {
        DBQLContext myDb = new DBQLContext();
        public List<NguoiDung> GetAll()
        {
            return myDb.nguoiDungs.Where(x => x.role == 2).ToList();
        }

        public List<NguoiDung> ThanThiet()
        {
            return myDb.nguoiDungs.Where(x => x.loaiKhachHang == "Thân Thiết").ToList();
        }
        public List<NguoiDung> Nhanvien()
        {
            return myDb.nguoiDungs.Where(x => x.role == 1).ToList();
        }

        public List<NguoiDung> GetKhachHang()
        {
            return myDb.nguoiDungs.Where(x => x.role == 2).ToList();
        }
        public void Add(NguoiDung nguoiDung)
        {
            myDb.nguoiDungs.Add(nguoiDung);
            myDb.SaveChanges();
        }
        public bool checkExistEmail(string email)
        {
            var obj = myDb.nguoiDungs.FirstOrDefault(x => x.email == email);
            if (obj != null) { return true; }
            return false;
        }
        public NguoiDung getId(int id)
        {
            return myDb.nguoiDungs.FirstOrDefault(x => x.idNguoiDung == id);
        }
        public void Delete(int id)
        {
            var nguoiDung = myDb.nguoiDungs.FirstOrDefault(x => x.idNguoiDung == id);
            myDb.nguoiDungs.Remove(nguoiDung);
            myDb.SaveChanges();
        }

        public void Update(NguoiDung nguoiDung)
        {
            var obj = myDb.nguoiDungs.FirstOrDefault(x => x.idNguoiDung == nguoiDung.idNguoiDung);
            obj.hoTen = nguoiDung.hoTen;
            obj.soDienThoai = nguoiDung.soDienThoai;
            obj.diaChi = nguoiDung.diaChi;
            obj.gioiTinh = nguoiDung.gioiTinh;
            obj.email = nguoiDung.email;
            obj.ngheNghiep = nguoiDung.ngheNghiep;
            obj.loaiKhachHang = nguoiDung.loaiKhachHang;
            myDb.SaveChanges();
        }
    }
}