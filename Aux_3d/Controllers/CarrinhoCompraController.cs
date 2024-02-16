using Aux_3d.Models;
using Aux_3d.Repositories.Interfaces;
using Aux_3d.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aux_3d.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository lancheRepository, CarrinhoCompra carrinhocompra)
        {
            _produtoRepository = lancheRepository;
            _carrinhoCompra = carrinhocompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
        public IActionResult AdicionarItemNoCarrinhoCompra(int produtoid)
        {
            var produtoselecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoid);
            if(produtoselecionado == null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoselecionado);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoCompra(int produtoId)
        {
            var _produtoselecionado = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId==produtoId);

            if(_produtoselecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(_produtoselecionado);
            }
            return RedirectToAction("Index");
        }

    }
}
