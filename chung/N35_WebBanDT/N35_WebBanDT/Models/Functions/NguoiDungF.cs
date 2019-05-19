using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using N35_WebBanDT.Models.Entities;
namespace N35_WebBanDT.Models.Functions
{
    public class NguoiDungF
    {
        private MyDBContext context;

        public NguoiDungF()
        {
            context = new MyDBContext();

        }
        public Account Login(string username, string pass)
        {
            var result = context.NguoiDungs.Where(a => a.TaiKhoan.Equals(username) &&
                                                       a.MatKhau.Equals(pass)).FirstOrDefault();
            Account t = null;
            if (result != null)
            {
                t = new Account();
                t.TaiKhoan = result.TaiKhoan;
                t.MatKhau = result.MatKhau;
                t.Quyens = (from a in context.Quyens
                            join b in context.QuyenNguoiDungs
                            on a.IDQuyen equals b.IDQuyen
                            where (a.TenQuyen != null && b.TaiKhoan.Equals(username))
                            select a.TenQuyen).ToList();
            }
            return t;
        }
    }
}