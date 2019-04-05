using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupSportsWeb.ViewModels;
using GroupSports.DL.DM;
using System.Web.Security;

namespace GroupSportsWeb.Controllers
{
    public class LoginController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }

        public ActionResult Login()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            try
            {
                group_sportsEntities context = new group_sportsEntities();
                user objUsuario = context.user
                    .FirstOrDefault(x => x.username == objViewModel.userName && x.password == objViewModel.password);

                if (objUsuario == null)
                {
                    TempData["MensajeLogin"] = "Error! usuario y contraseña incorrectas";
                    return View(objViewModel);
                }
                FormsAuthentication.SetAuthCookie(objUsuario.username, false);
                Session["idCoach"] = objUsuario.id;

                return RedirectToAction("Index", "Athletes");
            }
            catch (Exception ex)
            {
                TempData["MensajeLoginError"] = "Error! " + ex.Message.ToList();
                return View(objViewModel);
            }
        }

        [Authorize]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            LoginViewModel objViewModel = new LoginViewModel();
            return RedirectToAction("Login", "Login");
        }


    }
}