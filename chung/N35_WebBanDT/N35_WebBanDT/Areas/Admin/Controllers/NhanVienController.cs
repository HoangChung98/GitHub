using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N35_WebBanDT.Models.Entities;
using N35_WebBanDT.Models.Functions;
namespace N35_WebBanDT.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        NhanVienF nvf = new NhanVienF();
        // GET: Admin/NhanVien
        public ActionResult DanhSachNhanVien()
        {
            var list = nvf.NhanViens.ToList();
            return View(list);
        }
        public ActionResult ChiTietNhanVien(string id)
        {
            var model = nvf.ChitietNhanVien(id);
            return View(model);
        }
        public ActionResult Sua(string id)
        {
            MyDBContext db = new MyDBContext();
            var model = nvf.ChitietNhanVien(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sua(NhanVien model)
        {
        
            try
            {
                if (nvf.Update(model))
                {
                    return RedirectToAction("DanhSachNhanVien");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}