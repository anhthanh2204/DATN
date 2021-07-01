using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopShoe.Models;

namespace ShopShoe.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/Admin
        MyDb db = new MyDb();
        public ActionResult Index()
        {
            return View(db.Users.OrderByDescending(x => x.ID).ToList());
        }
        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }
        
    }
}