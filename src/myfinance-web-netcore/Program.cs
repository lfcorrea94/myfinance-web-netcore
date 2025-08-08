using myfinance_web_netcore_infra;
using myfinance_web_netcore_infra.Interfaces;
using myfinance_web_netcore_infra.Repositories;
using myfinance_web_netcore_service.Interfaces;
using myfinance_web_netcore_service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registra os serviços e contextos no conteiner DI (dependency injection)
builder.Services.AddDbContext<MyFinanceDbContext>();

builder.Services.AddScoped<IPlanoContaService, PlanoContaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();

// Repositories
builder.Services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
