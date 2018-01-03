using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        [Route("Categorias", Name = "ListaCategorias")]
        public ActionResult Index()
        {
            var dao = new CategoriasDAO();
            var categorias = dao.Lista();

            ViewBag.Categorias = categorias;

            return View();
        }

        
        public ActionResult Form()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            CategoriasDAO dao = new CategoriasDAO();
            dao.Adiciona(categoria);

            return RedirectToAction("Index");
        }

    }
}