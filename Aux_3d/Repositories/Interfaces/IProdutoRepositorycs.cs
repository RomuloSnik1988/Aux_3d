using Aux_3d.Models;

namespace Aux_3d.Repositories.Interfaces;

public interface IProdutoRepositorycs
{
    IEnumerable<Produto> Produtos { get; }

    IEnumerable<Produto> ProdutosPreferidos { get;}

    Produto GetProdutoById(int ProdutoId);
}
