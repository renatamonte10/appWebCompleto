using AppWebCompleto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebCompleto.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login1()
        {
            if (Session["Erro"] != null)
            {
                ViewBag.Erro = Session["Erro"].ToString();

            }
            return View();

        }

        [HttpPost]
        public ActionResult ChecarLogin()
        {
            var usuario = new Usuarios();
            usuario.Email = Request["Email"];
            usuario.Senha = Request["PassWord"];

            if (usuario.Login())
            {
                Session["Autorizado"] = "OK";
                Session.Remove("Erro");
                return RedirectToAction("Index", "Home");
            }
            else
                Session["Erro"] = "Senha ou usuário inválidos";
                return RedirectToAction("Login1", "Login");
        }
    }
}