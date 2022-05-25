﻿using QuanLyKhachHang.Models;
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

        public void Add(HopDong hopDong)
        {
            myDb.hopDongs.Add(hopDong);
            myDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = myDb.hopDongs.FirstOrDefault(x => x.idHopDong == id);
            myDb.hopDongs.Remove(obj);
            myDb.SaveChanges();
        }
        public void Update(HopDong hopDong)
        {
            var obj = myDb.hopDongs.FirstOrDefault(x => x.idHopDong == hopDong.idHopDong);
            obj.idDaiLy = hopDong.idDaiLy;
            obj.idNguoiDung = hopDong.idNguoiDung;
            obj.ngayKy = hopDong.ngayKy;
            obj.thoiHan = hopDong.thoiHan;
            obj.tongTien = hopDong.tongTien;
            myDb.SaveChanges();
        }
    }
}