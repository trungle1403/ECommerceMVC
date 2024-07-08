using ECommerceMVC.Data;
using ECommerceMVC.Repositories;
using ECommerceMVC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EcommerceMvcContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceMVC"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
    pattern: "{controller=Products}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.Run();
