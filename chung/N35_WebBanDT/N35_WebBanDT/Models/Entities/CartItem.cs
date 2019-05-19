using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace N35_WebBanDT.Models.Entities
{
    [Serializable]
    public class CartItem
    {
        public SanPham SanPham { get; set; }
        public int Soluong { get; set; }
    }
}