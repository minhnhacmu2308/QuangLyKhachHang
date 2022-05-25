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
            ViewBag.ListKH = nguoiDungDao.GetKhachHang();
            ViewBag.ListDL = daiLyDao.GetAll();
            ViewBag.Msg = msg;
            return View();
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