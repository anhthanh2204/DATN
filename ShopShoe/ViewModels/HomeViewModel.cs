using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopShoe.Models;

namespace ShopShoe.ViewModels
{
    public class HomeViewModel
    {
        public List<SanPham> ListNewProduct { get; set; }
        public List<SanPham> ListAdidas { get; set; }
        public List<SanPham> ListNikes { get; set; }
        public List<SanPham> ListConverse { get; set; }
        public List<SanPham> ListPumas { get; set; }
    }
}