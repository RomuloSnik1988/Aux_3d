using Aux_3d.Context;
using Aux_3d.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace Aux_3d.Areas.Services;

public class RelatorioVendasServices
{
    private readonly AppDbContext context;

    public RelatorioVendasServices(AppDbContext _context)
    {
        context = _context;
    }
    public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
    {
        var resultado = from obj in context.Pedidos select obj;

        if (minDate.HasValue)
        {
            resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
        }
        if (maxDate.HasValue)
        {
            resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
        }
        return await resultado
                    .Include(p => p.PedidoItens)
                    .ThenInclude(p => p.Produto)
                    .OrderByDescending(x => x.PedidoEnviado)
                    .ToListAsync();
    }

    
}
