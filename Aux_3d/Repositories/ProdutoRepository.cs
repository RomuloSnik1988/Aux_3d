using Aux_3d.Context;
using Aux_3d.Models;
using Aux_3d.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aux_3d.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext contexto)
    {
            _context = contexto;
    }

    public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);

    public IEnumerable<Produto> ProdutosPreferidos => _context.Produtos.
                                 Where(p => p.IsProdutoPreferido).Include(c => c.Categoria);

    public Produto GetProdutoById(int ProdutoId)
    {
        return _context.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);
    }
}
