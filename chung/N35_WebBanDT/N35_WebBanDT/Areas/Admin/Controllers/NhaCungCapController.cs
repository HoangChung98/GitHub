using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N35_WebBanDT.Models.Entities;
using N35_WebBanDT.Models.Functions;
namespace N35_WebBanDT.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: Admin/NhaCC
        NhaCungCapF nccf = new NhaCungCapF();
        
        public ActionResult DanhSachNhaCungCap()
        {
            var list = nccf.NhaCungCaps.ToList();
            return View(list);
        }
        public ActionResult ChiTietNhaCungCap(string id)
        {
            var model = nccf.ChitietNhaCungCap(id);
            return View(model);
        }
        public ActionResult Them()
        {
            MyDBContext db = new MyDBContext();
            
            ViewBag.IDNCC = new SelectList(db.NhaCungCaps, "IDNCC", "TenNCC");
            return View();
        }
        [HttpPost]
        public ActionResult Them(NhaCungCap model)
        {
            NhaCungCapF spf = new NhaCungCapF();
            try
            {
                if (spf.InSert(model))
                {
                    return RedirectToAction("DanhSachNhaCungCap");
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
        public ActionResult Sua(string id)
        {
            MyDBContext db = new MyDBContext();
            var model = nccf.ChitietNhaCungCap(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sua(NhaCungCap model)
        {

            try
            {
                if (nccf.Update(model))
                {
                    return RedirectToAction("DanhSachNhaCungCap");
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
        public ActionResult Xoa(string id)
        {
            MyDBContext db = new MyDBContext();
            NhaCungCapF nccf = new NhaCungCapF();
            NhaCungCap model = nccf.ChitietNhaCungCap(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Xoa(NhaCungCap model)
        {
            NhaCungCapF nccf = new NhaCungCapF();
            try
            {
                if (nccf.Delete(model.IDNCC))
                {
                    return RedirectToAction("DanhSachNhaCungCap");
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