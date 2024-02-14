using Aux_3d.Models;
using Aux_3d.Repositories.Interfaces;
using Aux_3d.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aux_3d.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhocompra;

        public CarrinhoCompraController(IProdutoRepository lancheRepository, CarrinhoCompra carrinhocompra)
        {
            _produtoRepository = lancheRepository;
            _carrinhocompra = carrinhocompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhocompra.GetCarrinhoCompraItens();
            _carrinhocompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhocompra,
                CarrinhoCompraTotal = _carrinhocompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
        public IActionResult AdicionarItemNoCarrinhoCompra(int produtoid)
        {
            var produtoselecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoid);
            if(produtoselecionado == null)
            {
                _carrinhocompra.AdicionarAoCarrinho(produtoselecionado);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoCompra(int produtoId)
        {
            var _produtoselecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId==produtoId);

            if(_produtoselecionado != null)
            {
                _carrinhocompra.RemoverDoCarrinho(_produtoselecionado);
            }
            return RedirectToAction("Index");
        }

    }
}
