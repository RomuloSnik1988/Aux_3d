﻿using Aux_3d.Context;
using Aux_3d.Models;
using Aux_3d.Repositories.Interfaces;
using System.Data.Entity;

namespace Aux_3d.Repositories;

public class ProdutoRepository : IProdutoRepositorycs
{
    private readonly AppDBContext _context;

    public ProdutoRepository(AppDBContext context)
    {
            _context = context;
    }

    public IEnumerable<Produto> Produtos => _context.Produtos.Include(c=> c.Categoria);

    public IEnumerable<Produto> ProdutosPreferidos => _context.Produtos.
                                 Where(p => p.IsProdutoPreferido).Include(c => c.Categoria);

    public Produto GetProdutoById(int ProdutoId)
    {
        return _context.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);
    }
}
