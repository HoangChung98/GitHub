using N35_WebBanDT.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N35_WebBanDT.Models.Functions;
namespace N35_WebBanDT.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnURL = ReturnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(NguoiDung model, string ReturnUrl)
        {
            if (String.IsNullOrEmpty(model.TaiKhoan))
            {
                ModelState.AddModelError("", "Chưa nhập tên đăng nhập");
                return View("Login", model);
            }
            if (String.IsNullOrEmpty(model.MatKhau))
            {
                ModelState.AddModelError("", "Chưa nhập mật khẩu");
                return View("Login", model);
            }
            var acc = new NguoiDungF().Login(model.TaiKhoan, model.MatKhau);


            if (acc == null)
            {
                ModelState.AddModelError("", "Người dùng không tồn tại");
                return View("Login", model);
            }
            else
            {
                Session["Login"] = acc;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return RedirectToAction("TrangChu", "SanPham");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }


        }
    }
}