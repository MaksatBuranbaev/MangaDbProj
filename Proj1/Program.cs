using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proj1.Data;
using Proj1.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Proj1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proj1Context") ?? throw new InvalidOperationException("Connection string 'Proj1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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
    pattern: "{controller=Manga}/{action=Index}/{id?}");

app.Run();
