using Aux_3d.Repositories;
using Aux_3d.Repositories.Interfaces;
using Aux_3d.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Aux_3d.Controllers
{
    public class ProdutoController : Controller
    {
       private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List()
        {
            //ViewData["Titulo"] = "Todos os Produtos";

            //var produtos =  _produtoRepository.Produtos.ToList();
            //return View(produtos);

            var produtosListViewmodel = new ProdutoListViewModel();
            produtosListViewmodel.Produtos = _produtoRepository.Produtos;
            produtosListViewmodel.CategoriaAtual = "Categoria Atual";

            return View(produtosListViewmodel);
        }
    }
}
