using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestEntityCoreAuthorsBooks.Data;
using TestEntityCoreAuthorsBooks.Helpers;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.AutomapperProfiles;
using TestEntityCoreAuthorsBooks.ProgrammData.Common;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Data;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager Configuration = builder.Configuration;
IServiceCollection services = builder.Services;

// Add services to the container.
string connection = Configuration.GetConnectionString("DefaultConnection");

services.AddDbContext<ApplicationDbContext>
    (options =>
    {
        options.UseSqlServer(connection);
    });

IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
services.Configure<AppSettings>(appSettingsSection);

services.AddDatabaseDeveloperPageExceptionFilter();

services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 1;   // минимальная длина
    options.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
    options.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
    options.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
    options.Password.RequireDigit = false; // требуются ли цифры
});

services.AddDependencyInjection();
services.AddRazorPages().AddRazorRuntimeCompilation();

services.AddRazorPages();

services.AddAutoMapper(typeof(EntityDtoProfile));

services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "1";
                    options.ClientSecret = "1";
                }
            );
services.AddAuthorization(options =>
{

    options.AddPolicy("EditRolePolicy", policy => policy.RequireAssertion(context =>
        context.User.IsInRole("Admin") &&
        context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true") ||
        context.User.IsInRole("Super Admin")
    ));


    options.AddPolicy("CreateRolePolicy",
        policy => policy.RequireClaim("Create Role", "true"));

    options.AddPolicy("DeleteRolePolicy",
        policy => policy.RequireClaim("Delete Role", "true"));

    options.AddPolicy("AdminRolePolicy",
        policy => policy.RequireRole("Admin", "Super Admin"));

});

WebApplication app = builder.Build();

app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Author}/{action=ShowAllPage}/{id?}");

app.MapRazorPages();

app.Run();
