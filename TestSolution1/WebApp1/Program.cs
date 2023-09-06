global using Microsoft.AspNetCore.Mvc.Rendering;
global using Microsoft.EntityFrameworkCore;
global using WebApp1.Data;
global using WebApp1.Dtos.CategoryDtos;
global using WebApp1.Dtos.InventoryDtos;
global using WebApp1.Models;
global using WebApp1.Models.CategoryModel;
global using WebApp1.Models.InventoryModel;
global using WebApp1.Service.CategoryService;
global using WebApp1.Service.InventoryService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
