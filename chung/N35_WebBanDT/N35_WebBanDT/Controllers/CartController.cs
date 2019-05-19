using N35_WebBanDT.Models.Entities;
using N35_WebBanDT.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N35_WebBanDT.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(string idsanpham, int soluong)
        {
            var sp = new SanPhamF().ChitietSanPham(idsanpham);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPham.IDSanPham == idsanpham))
                {
                    foreach(var item in list)
                    {
                        if (item.SanPham.IDSanPham == idsanpham)
                        {
                            item.Soluong += soluong;
                        }
                               
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.SanPham = sp;
                    item.Soluong = soluong;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            
            else
            {
                var item = new CartItem();
                item.SanPham = sp;
                item.Soluong = soluong;
                var list = new List<CartItem>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");  
        }
        public static void XoaSP(SanPham idsanpham)
        {
     
        }
    }
}