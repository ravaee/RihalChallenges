using AutoMapper;
using Common.Middlewares;
using Common.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Persistence.Context;
using Persistence.Services;
using Persistence.UnitOfWork;
using RihalChallenges;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app);

void ConfigureServices(IServiceCollection services)
{

    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new UserProfile());
    });
    IMapper autoMapper = mappingConfig.CreateMapper();
    builder.Services.AddSingleton(autoMapper);

    services.AddMudServices();
    services.AddDbContext<ApplicationDbContext>(x =>
    {
        x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();


    services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.ImplicitlyValidateChildProperties = true;
        fv.ImplicitlyValidateRootCollectionElements = true;

        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

    services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
    services.AddRazorPages();
    services.AddServerSideBlazor();

    services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>(); 
    services.AddScoped<StudentService>();
    services.AddScoped<ClassService>();
    services.AddScoped<CountryService>();
    services.AddScoped<AccountService>();
    services.AddScoped<DataService>();
    
}

void Configure(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");

        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseCookiePolicy();
    app.UseAuthentication();

    app.UseMiddleware<BlazorCookieLoginMiddleware>();

    app.Use(async (context, next) => {

        if (context.Request.Path
                .Equals("/Logout", System.StringComparison.OrdinalIgnoreCase))
        {
            context.Response.Cookies.Delete(".AspNetCore.Identity.Application", new CookieOptions()
            {
                Secure = true,
            });
        }
        await next();
    });

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    Seeder();

    app.Run();

}


void Seeder()
{

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetService<ApplicationDbContext>();
        var userManager = services.GetService<UserManager<ApplicationUser>>();
        ApplicationSeed.SeedCountries(context).Wait();
        ApplicationSeed.SeedClasses(context).Wait();
        ApplicationSeed.SeedAdminUser(userManager).Wait();
    }
}
