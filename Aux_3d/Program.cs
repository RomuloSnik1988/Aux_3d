using Aux_3d.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Referencia a Conex�o com o Banco de Dados
string mySqlConection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(mySqlConection));


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
