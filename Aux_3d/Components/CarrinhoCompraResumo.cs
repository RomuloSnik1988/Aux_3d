using Aux_3d.Models;
using Aux_3d.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Aux_3d.Components;

public class CarrinhoCompraResumo : ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        //Colocando Produto no carrinho para testar
        //var itens = new List<CarrinhoCompraItem>()
        //{
        //    new CarrinhoCompraItem(),
        //    new CarrinhoCompraItem()
        //};
        var itens = _carrinhoCompra.GetCarrinhoCompraItens();

        _carrinhoCompra.CarrinhoCompraItens = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };
        return View(carrinhoCompraVM);
    }
}
