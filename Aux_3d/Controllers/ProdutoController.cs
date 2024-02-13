using Aux_3d.Repositories;
using Aux_3d.Repositories.Interfaces;
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
            var produtos =  _produtoRepository.Produtos.ToList();
            return View(produtos);
        }
    }
}
