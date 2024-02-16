using Aux_3d.Context;
using Aux_3d.Models;
using Aux_3d.Repositories;
using Aux_3d.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Referencia a Conexão com o Banco de Dados
string mySqlConection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(mySqlConection));

//Adicionando as injeções de dependencias
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

//
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

//Adicionando serviços de memoria cache e Session
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern: "Produto/{action}/{categoria?}",
    defaults: new { Controller = "Produto", action = "List" });

app.MapControllerRoute(  
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
