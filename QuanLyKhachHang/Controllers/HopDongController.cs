using QuanLyKhachHang.Dao;
using QuanLyKhachHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachHang.Controllers
{
    public class HopDongController : Controller
    {
        HopDongDao hopDongDao = new HopDongDao();
        NguoiDungDao nguoiDungDao = new NguoiDungDao();
        DaiLyDao daiLyDao = new DaiLyDao();
        // GET: NguoiDung
        public ActionResult Index(string msg)
        {
            ViewBag.List = hopDongDao.GetAll();
            ViewBag.ListKH = nguoiDungDao.Nhanvien();
            ViewBag.ListDL = daiLyDao.GetAll();
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Day(FormCollection form)
        {
            var day = form["day"];
            if (day == null)
            {
                return View();
            }
            else
            {
                DateTime ngay = DateTime.Parse(day);
                ViewBag.Ngay = day;
                ViewBag.List = hopDongDao.Ngay(ngay);
                return View();
            }

        }

        public ActionResult Month(FormCollection form)
        {
            var thang = form["thang"];
            if (thang == null)
            {
                return View();
            }
            else
            {
                int thangtangluong = Int32.Parse(thang);
                ViewBag.Thang = thang;
                ViewBag.List = hopDongDao.Thang(thangtangluong);
                return View();
            }

        }

        public ActionResult NhanVien(FormCollection form)
        {
            ViewBag.ListKH = nguoiDungDao.Nhanvien();
            var nv = form["nv"];
            if (nv == null)
            {
                return View();
            }
            else
            {
                int idnv = Int32.Parse(nv);
                ViewBag.NV = nguoiDungDao.getId(idnv).hoTen;
                ViewBag.List = hopDongDao.Nhanvien(idnv);
                return View();
            }

        }
        public ActionResult Add(HopDong hopDong)
        {           
             hopDong.createdAt = DateTime.Now;
             hopDongDao.Add(hopDong);
             return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult Delete(HopDong hopDong)
        {
            hopDongDao.Delete(hopDong.idHopDong);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(HopDong hopDong)
        {
            hopDongDao.Update(hopDong);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}