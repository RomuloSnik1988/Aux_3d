using Aux_3d.Context;
using Aux_3d.Models;
using Microsoft.EntityFrameworkCore;

namespace Aux_3d.Areas.Services;

public class RelatorioProdutoService
{
    private readonly AppDbContext _context;

    public RelatorioProdutoService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Produto>> GetProdutosReport()
    {
        var produtos = await _context.Produtos.ToListAsync();

        if (produtos == null)

            return default(IEnumerable<Produto>);

        return produtos;

    }
    public async Task<IEnumerable<Categoria>> GetCategoriasReport()
    {
        var categorias = await _context.Categorias.ToListAsync();

        if (categorias == null)

            return default(IEnumerable<Categoria>);

        return categorias;
    }
}
