using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N35_WebBanDT.Models.Functions;
using N35_WebBanDT.Models.Entities;
using System.Web.Security;
using N35_WebBanDT.Models.Security;

namespace N35_WebBanDT.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc


        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            SanPhamF spf = new SanPhamF();
            var lst = spf.SanPhams.ToList();

            return View(lst);
        }
      
        public ActionResult Them()
        {
            MyDBContext db= new MyDBContext();
            ViewBag.IDHang = new SelectList(db.Hangs, "IDHang", "TenHang");
            ViewBag.IDNCC = new SelectList(db.NhaCungCaps, "IDNCC", "TenNCC");
            return View();
        }
        [HttpPost]
        public ActionResult Them(SanPham model)
        {
            SanPhamF spf = new SanPhamF();
            try
            {
                if (spf.InSert(model))
                {
                    return RedirectToAction("Index");
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
        public ActionResult XemChiTiet(string id)
        {
            SanPhamF spf = new SanPhamF();
            SanPham model = spf.ChitietSanPham(id);
            return View(model);
        }
        
        public ActionResult Sua(string id)
        {
            MyDBContext db = new MyDBContext();
            SanPhamF spf = new SanPhamF();
            SanPham model = spf.ChitietSanPham(id);
            ViewBag.IDHang = new SelectList(db.Hangs, "IDHang", "TenHang", model.IDHang);
            ViewBag.IDNCC = new SelectList(db.NhaCungCaps, "IDNCC", "TenNCC", model.IDNCC);
            return View(model);
        }
        [HttpPost]
        public ActionResult Sua(SanPham model)
        {
           SanPhamF spf = new SanPhamF();
            try
            {
                if (spf.Update(model))
                {
                    return RedirectToAction("Index");
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
            SanPhamF spf = new SanPhamF();
            SanPham model = spf.ChitietSanPham(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Xoa(SanPham model)
        {
            SanPhamF spf = new SanPhamF();
            try
            {
                if(spf.Delete(model.IDSanPham))
                {
                    return RedirectToAction("Index");
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