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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel, GroupSports.DL.DM.DTO.LoginDTO loginDTO)
        {
            try
            {
                group_sportsEntities context = new group_sportsEntities();
                user objUsuario = context.user
                    .FirstOrDefault(x => x.username == objViewModel.userName && x.password == objViewModel.password);

              
                 
              
                FormsAuthentication.SetAuthCookie(objUsuario.username, false);
                Session["objUsuario"] = objUsuario;

                 var userDetails = context.user.Where(x => x.username == loginDTO.userName && x.password == loginDTO.password).FirstOrDefault();
                LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();

                Session["userID"] = userDetails.username;
                Session["userID2"] = lstCoachViewModel.findCoachIDByUser(userDetails.username);
                return RedirectToAction("Index", "Athletes");
            }
            catch (Exception ex)
            {
                TempData["MensajeLoginError"] = "Error! " + ex.Message.ToList();
                return View(objViewModel);
            }
            //LstCoachViewModel lstCoachViewModel = new LstCoachViewModel();
            //using (GroupSports.DL.DM.group_sportsEntities db = new GroupSports.DL.DM.group_sportsEntities())
            //{
            //    var userDetails = db.user.Where(x => x.username == loginDTO.userName && x.password == loginDTO.password).FirstOrDefault();
            //    if (userDetails == null)
            //    {
            //        return RedirectToAction("Index", "Coachs");
            //    }
            //    else
            //    {
            //        Session["userID"] = userDetails.username;
            //        Session["userID2"] = lstCoachViewModel.findCoachIDByUser(userDetails.username);
            //        return RedirectToAction("Index", "Athletes");

            //    }
            //}

        }

        [Authorize]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            LoginViewModel objViewModel = new LoginViewModel();
            return RedirectToAction("Login", "Home");
        }

    }
}