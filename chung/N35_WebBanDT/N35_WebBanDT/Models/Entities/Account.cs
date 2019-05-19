using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N35_WebBanDT.Models.Entities
{
    public class Account
    {
        
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public List<string> Quyens { get; set; }
        
    }
}