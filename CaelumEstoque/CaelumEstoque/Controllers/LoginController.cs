﻿using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario usuario = dao.Busca(login, senha);

            if (usuario != null)
            {
                Session["usuarioLogado"] = usuario;
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}