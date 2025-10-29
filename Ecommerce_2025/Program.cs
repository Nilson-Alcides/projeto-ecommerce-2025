

using Ecommerce_2025.Libraries.Login;
using Ecommerce_2025.Repositories.Contract;
using Ecommerce_2025.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//Adicionado para manipular a Sessão
builder.Services.AddHttpContextAccessor();

//Adicionar a Interface como um serviço 
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
//builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();

builder.Services.AddScoped<Ecommerce_2025.Libraries.Sessao.Sessao>();
builder.Services.AddScoped<LoginCliente>();
builder.Services.AddScoped<LoginColaborador>();


builder.Services.AddMemoryCache(); // Guardar os dados na memoria
builder.Services.AddSession(options =>
{

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseCookiePolicy();
app.UseSession();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
