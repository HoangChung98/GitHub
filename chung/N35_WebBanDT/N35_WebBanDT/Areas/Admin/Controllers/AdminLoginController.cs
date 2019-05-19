using N35_WebBanDT.Models.Entities;
using N35_WebBanDT.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N35_WebBanDT.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        public ActionResult AdminLogin(string ReturnUrl)
        {
            ViewBag.ReturnURL = ReturnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(NguoiDung model, string ReturnUrl)
        {
            if (String.IsNullOrEmpty(model.TaiKhoan))
            {
                ModelState.AddModelError("", "Chưa nhập tên đăng nhập");
                return View("AdminLogin", model);
            }
            if (String.IsNullOrEmpty(model.MatKhau))
            {
                ModelState.AddModelError("", "Chưa nhập mật khẩu");
                return View("AdminLogin", model);
            }
            var acc = new NguoiDungF().Login(model.TaiKhoan, model.MatKhau);


            if (acc == null)
            {
                ModelState.AddModelError("", "Người dùng không tồn tại");
                return View("AdminLogin", model);
            }
            else
            {
                Session["Login"] = acc;
                if (string.IsNullOrEmpty(ReturnUrl))
                {

                    return View("AdminLogin");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }

        }
    }
}