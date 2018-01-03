﻿using System;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            object valorSession = Session["contador"];
            int contador = Convert.ToInt32(valorSession);
            contador++;
            Session["contador"] = contador;

            return View(contador);
        }
    }
}