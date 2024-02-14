using Aux_3d.Models;
using Microsoft.EntityFrameworkCore;

namespace Aux_3d.Context;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

}
