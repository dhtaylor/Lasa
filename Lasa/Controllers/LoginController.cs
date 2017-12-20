using Lasa.BusinessLayer;
using Lasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lasa.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            LoginHelper lh = new LoginHelper();
            Login l = lh.GetLogin("test");

            return View(l);
        }

        [HttpPost]
        public ActionResult Index(Login l)
        {
            LoginHelper lh = new LoginHelper();
            lh.Save(l);

            return View();
        }
    }
}