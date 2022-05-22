using QuanLyKhachHang.Dao;
using QuanLyKhachHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyKhachHang.Controllers
{
    public class DaiLyController : Controller
    {
        DaiLyDao daiLyDao = new DaiLyDao();
        // GET: DaiLy
        public ActionResult Index(string msg)
        {
            ViewBag.List = daiLyDao.GetAll();
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Add(DaiLy daiLy)
        {
            bool checkExist = daiLyDao.checkExist(daiLy.tenDaiLy);
            if (checkExist)
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
            else
            {
                daiLyDao.Add(daiLy);
                return RedirectToAction("Index", new { msg = "1" });
            }

        }

        [HttpPost]
        public ActionResult Delete(DaiLy daiLy)
        {
            daiLyDao.Delete(daiLy.idDaiLy);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Update(DaiLy daiLy)
        {
                var check = daiLyDao.GetDaiLyById(daiLy.idDaiLy);
                if (check.tenDaiLy.Equals(daiLy.tenDaiLy))
                {
                    daiLyDao.Update(daiLy);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    var obj = daiLyDao.checkExist(daiLy.tenDaiLy);
                    if (obj == false)
                    {
                        daiLyDao.Update(daiLy);
                        return RedirectToAction("Index", new { msg = "1" });
                    }
                    else
                    {
                         return RedirectToAction("Index", new { msg = "2" });
                    }                  
                 }
        }
    }
}