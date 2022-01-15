using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Persistence.Context;
using Persistence.Services;
using Persistence.UnitOfWork;
using RihalChallenges;
using System.Reflection;

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

    //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddMudServices();
    services.AddDbContext<ApplicationDbContext>(x =>
    {
        x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.ImplicitlyValidateChildProperties = true;
        fv.ImplicitlyValidateRootCollectionElements = true;

        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });

    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>(); 
    services.AddScoped<StudentService>();
    services.AddScoped<ClassService>();
    services.AddScoped<CountryService>();
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
        ApplicationSeed.SeedCountries(context).Wait();
        ApplicationSeed.SeedClasses(context).Wait();
    }
}

