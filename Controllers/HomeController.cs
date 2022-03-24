﻿using AppWebCompleto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebCompleto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Autorizado"] != null)
                return View();
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        public ActionResult Veiculo()
        {
            ViewBag.Title = "Vende-se";
            ViewBag.Message = "Relação de carros";

            if(Session["Autorizado"] != null)
            {
                var lista = Veiculos.GetCarros();
                ViewBag.Lista = lista;

                return View();

            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
                
        }

        public ActionResult Contact()
        {
            if (Session["Autorizado"] != null) { 
                ViewBag.Title = "Contatos";
                ViewBag.Message = "Social";

            return View();
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }

        [HttpPost]
        public void EnviarMensagem()
        {

        }
    }
}