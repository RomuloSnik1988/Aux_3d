using Aux_3d.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aux_3d.Components;

public class CategoriaMenu : ViewComponent
{
    private readonly ICategoriaRepository _categoriarepository;

    public CategoriaMenu(ICategoriaRepository categoriarepository)
    {
        _categoriarepository = categoriarepository;
    }

    public IViewComponentResult Invoke()
    {
        var categorias = _categoriarepository.Categorias.OrderBy(c => c.CategoriaNome);
        return View(categorias);
    }
}
