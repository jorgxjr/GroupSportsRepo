using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupSportsWeb.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}