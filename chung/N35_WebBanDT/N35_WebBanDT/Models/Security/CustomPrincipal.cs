using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using N35_WebBanDT.Models.Entities;
namespace N35_WebBanDT.Models.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account Account;
        public CustomPrincipal(Account account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.TaiKhoan);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });// Lấy ra danh sách quyền
            // kiểm tra xem người dùng có tồn tại nhóm quyền có tồn tại trong danh sách quyền không
            bool kq = roles.Any(r => this.Account.Quyens.Contains(r));
            return kq;
        }
    }
}