using Aux_3d.Models;
using Microsoft.EntityFrameworkCore;

namespace Aux_3d.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoDetalhe> PedidosDetalhe { get; set; }


}
