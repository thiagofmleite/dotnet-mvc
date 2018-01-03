using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {

        [Route("Produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            var dao = new ProdutosDAO();
            var produtos = dao.Lista();

            ViewBag.Produtos = produtos;

            return View(produtos);
            
        }

        public ActionResult Form()
        {
            CategoriasDAO categoriasDao = new CategoriasDAO();
            var categorias = categoriasDao.Lista();
            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            int idInformatica = 1;
            ViewBag.Produto = produto;

            if (produto.CategoriaId.Equals(idInformatica) && produto.Preco >= 100)
            {
                ModelState.AddModelError("produto.Invalido", "Informática ou preço maior ou igual R$ 100");
            }
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);

                return RedirectToAction("Index", "Produto");
            }
            else
            {
                CategoriasDAO categoriasDao = new CategoriasDAO();
                ViewBag.Categorias = categoriasDao.Lista();
                return View("Form");
            }
            
        }

        [Route("Produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;

            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);
            return Json(produto);
        }
    }
}