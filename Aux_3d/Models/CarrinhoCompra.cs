using Aux_3d.Context;
using Aux_3d.Migrations;
using Microsoft.Identity.Client;
using System.Data.Entity;

namespace Aux_3d.Models;

public class CarrinhoCompra
{
    private readonly AppDBContext _context;

    public CarrinhoCompra(AppDBContext context)
    {
        _context = context;
    }

    public string CarrinhoCompraId { get; set; }

    public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        //Definindo uma sessão
        ISession session = 
            services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        //Obtendo um serviço do tipo do nosso contexto
        var context = services.GetService<AppDBContext>();

        //Obtendo ou gerando o ID do carrinho de compras
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

        //Atribui o Id do carrinho
        session.SetString("CarrinhoId", carrinhoId);

        //Retorna o carrinho com o contexto e ID atribuido ou obtido
        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId
        };
               
    }
    public void AdicionarAoCarrinho(Produto produto)
    {   
        var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
            s => s.Produto.ProdutoId == produto.ProdutoId &&
            s.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Produto = produto,
                Quantidade = 1
            };
            _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
        }
        else
        {
            carrinhoCompraItem.Quantidade++;
        }
        _context.SaveChanges();
    }
    public int RemoverDoCarrinho(Produto produto)
    {
        var carrrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
            s => s.Produto.ProdutoId == produto.ProdutoId &&
            s.CarrinhoCompraId == CarrinhoCompraId);
        
       var quantidadelocal = 0;

        if(carrrinhoCompraItem != null)
        {
            if(carrrinhoCompraItem.Quantidade > 1)
            {
                carrrinhoCompraItem.Quantidade--;
                quantidadelocal = carrrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrrinhoCompraItem);
            }
        }
        _context.SaveChanges();
        return quantidadelocal;
    }
    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        return CarrinhoCompraItens ??
                (CarrinhoCompraItens =
                _context.CarrinhoCompraItens
                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Include(s => s.Produto)
                .ToList());
    }
    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItens
                            .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }
    public decimal GetCarrinhoCompraTotal()
    {
        var total = _context.CarrinhoCompraItens
                    .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                    .Select(c => c.Produto.Preco * c.Quantidade).Sum();

        return total;
    }
  
}
