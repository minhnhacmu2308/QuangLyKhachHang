using QuanLyKhachHang.Dao;
using QuanLyKhachHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachHang.Controllers
{
    public class NguoiDungController : Controller
    {
        NguoiDungDao nguoiDungDao = new NguoiDungDao();
        // GET: NguoiDung
        public ActionResult Index(string msg)
        {
            ViewBag.List = nguoiDungDao.GetAll();
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Add(NguoiDung nguoiDung)
        {
            bool checkExist = nguoiDungDao.checkExistEmail(nguoiDung.email);
            if (checkExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                nguoiDungDao.Add(nguoiDung);
                return RedirectToAction("Index", new { msg = "1" });
            }

        }

        [HttpPost]
        public ActionResult Delete(NguoiDung nguoiDung)
        {
            nguoiDungDao.Delete(nguoiDung.idNguoiDung);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(NguoiDung nguoiDung)
        {
            nguoiDungDao.Update(nguoiDung);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}