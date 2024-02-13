using Aux_3d.Models;

namespace Aux_3d.Repositories.Interfaces;

public interface ICategoriaRepository 
{
    IEnumerable<Categoria> Categorias { get; }
}
