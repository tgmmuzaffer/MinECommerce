using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinECommerce.Context;
using MinECommerce.Entity;
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
    .AddEntityFrameworkStores<UserContext>(); 
builder.Services.AddControllersWithViews();

#region Services
builder.Services.AddScoped<ICreateDefaultUser, CreateDefaultUser>();

#endregion

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<UserContext>();
    dataContext.Database.Migrate();

    var serviceprovider = scope.ServiceProvider;
    var userService = serviceprovider.GetRequiredService<ICreateDefaultUser>();
    userService.CreateDefUser();
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
