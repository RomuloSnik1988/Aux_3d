using Aux_3d.Models;

namespace Aux_3d.ViewModels;

public class ProdutoListViewModel
{
    public IEnumerable<Produto> Produtos { get; set; }

    public string CategoriaAtual  { get; set; }
}
