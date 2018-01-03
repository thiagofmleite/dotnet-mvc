using Alura.MVC.Inicial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alura.MVC.Inicial.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // código da regra de negócio da aplicação
            var produtos = new List<Produto>();
            produtos.Add(new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Produto Teste 01",
                Quantidade = 12

            });

            ViewBag.Produtos = produtos;

            return View();
        }
    }
}