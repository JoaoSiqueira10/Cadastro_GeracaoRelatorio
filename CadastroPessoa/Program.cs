using CadastroPessoa.Context;
using CadastroPessoa.Services;
using FastReport.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//String de conexão automatica (nao recomendada)
builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer("Data Source=DESKTOP-S42DPI7;Initial Catalog=CadastroPessoa;Integrated Security=True;TrustServerCertificate=True"));

FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

//singleton
builder.Services.AddScoped<IPessoaService, PessoaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseFastReport();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
