using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MinECommerce.Context;
using MinECommerce.Entity;
using MinECommerce.Service.IServices;
using MinECommerce.Service.Services;
using MinECommerce.Ui.Areas.Identity.Data;
using MinECommerce.Ui.Data;
using MinECommerce.Ui.IServices;
using MinECommerce.Ui.Services;
//using MinECommerce.Service.IServices;
//using MinECommerce.Service.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MinECommerceUiContextConnection") ?? throw new InvalidOperationException("Connection string 'MinECommerceUiContextConnection' not found.");




#region Contextses
builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(connectionString));


#endregion

builder.Services.AddDefaultIdentity<MinECommerceUiUser>(options => options.SignIn.RequireConfirmedAccount = false)
//builder.Services.AddIdentity<MinECommerceUiUser, MinECommerceUiUserRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<UserContext>(); 
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthorization(options => {
    options.AddPolicy("readpolicy",
        builder => builder.RequireRole("SysAdmin", "Admin", "Customer"));
    options.AddPolicy("halfwritepolicy",
        builder => builder.RequireRole("SysAdmin", "Admin"));
    options.AddPolicy("writepolicy",
        builder => builder.RequireRole("SysAdmin"));
});
#region Services
builder.Services.AddScoped<ICreateDefaultUserService, CreateDefaultUserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IFeatureDescriptionService, FeatureDescriptionService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IProductService, ProductService>();

#endregion

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    dataContext.Database.Migrate();

    var serviceprovider = scope.ServiceProvider;
    var userService = serviceprovider.GetRequiredService<ICreateDefaultUserService>();
    userService.CreateDefUser();
    var roleService=serviceprovider.GetRequiredService<IRoleService>();
    roleService.Create();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
