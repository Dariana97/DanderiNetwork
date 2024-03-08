using DanderiNetwork.Infraestructure.Identity;
using DanderiNetwork.Infraestructure.Identity.Entities;
using DanderiNetwork.Infraestructure.Identity.Seeds;
using DanderiNetwork.Infraestructure.Shared;
using DanderiNetwork.Infraestructure.Persistence;
using Microsoft.AspNetCore.Identity;
using DanderiNetwork.Core.Application;
using DanderiNetworkApp.Middlewares;
using DanderiNetworkApp.Midleware;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);
builder.Services.AddScoped<LoginAuthorize>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ValidateUserSession, ValidateUserSession>();
builder.Services.AddApplicationLayer();




var app = builder.Build();



using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
     
        await DefaultUser.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {

    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
