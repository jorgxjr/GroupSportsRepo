using GroupSportsWeb.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GroupSportsWeb.Controllers
{
    public class BIEmbeddedController : Controller
    {
        [Authorize]       
        public ActionResult Index()
        {
            ViewBag.Link = "https://app.powerbi.com/view?r=eyJrIjoiOTI4MTVjNDctYzgyMi00MTRiLWI5ZjQtNjQ1NzEzNzRjOWUwIiwidCI6IjBlMGNiMDYwLTA5YWQtNDlmNS1hMDA1LTY4YjliNDlhYTFmNiIsImMiOjR9&refresh=1";
            return View();
        }

    }
}