using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N35_WebBanDT.Models.Entities;
using N35_WebBanDT.Models.Functions;
using N35_WebBanDT.Models.Security;

namespace N35_WebBanDT.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult TrangChu()
        {
            MyDBContext Db = new MyDBContext();
            var lst = Db.SanPhams.SqlQuery("select top 8 * from SanPham order by DonGiaB desc").ToList();
            return View(lst);
        }
        
        public ActionResult DanhSachSanPham()
        {
            SanPhamF SPF = new SanPhamF();
            var lst = SPF.SanPhams.ToList();
            return View(lst);
        }
   
        public ActionResult ChiTietSanPham(string id)
        {
            SanPhamF SPF = new SanPhamF();
            var sp = SPF.ChitietSanPham(id);
            return View(sp);
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            HangF hf = new HangF();
            var lst = hf.Hangs.ToList();
            return PartialView("MenuH",lst);
        }
        [HttpPost]
        public ActionResult TimKiem(string TuKhoa)
        {
            SanPhamF SPF = new SanPhamF();
            var model = SPF.SanPhams.Where(x => x.TenSanPham.Contains(TuKhoa)).ToList();
            return View("DanhSachSanPham",model);
        }
        public ActionResult SanPhamDM(string id)
        {
            SanPhamF SPF = new SanPhamF();
            var model = SPF.SanPhams.Where(x => x.IDHang == id).ToList();
            return View("DanhSachSanPham", model);
        }
    }
}