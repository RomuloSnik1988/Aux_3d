using Aux_3d.Context;
using Aux_3d.Models;
using Aux_3d.Repositories.Interfaces;

namespace Aux_3d.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDBContext _context;

    public CategoriaRepository(AppDBContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categorias;
}
