using Aux_3d.Models;

namespace Aux_3d.ViewModels;

public class PedidoProdutoViewModel
{
    public Pedido Pedido { get; set; }

    public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
}
