using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WashingCarDB.DAL.Entities;
using WashingCarDB.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DatabaseContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(io =>
{
    io.User.RequireUniqueEmail = true; //Valida que el email no est� repetido
    io.Password.RequireDigit = false;
    io.Password.RequiredUniqueChars = 0;
    io.Password.RequireLowercase = false;
    io.Password.RequireNonAlphanumeric = false;
    io.Password.RequireUppercase = false;
    io.Password.RequiredLength = 6;

}).AddEntityFrameworkStores<DatabaseContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Unauthorized";
    options.AccessDeniedPath = "/Account/Unauthorized";
});


builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddTransient<Seeder>();
builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<IDropDownListsHelper, DropDownListsHelper>();

var app = builder.Build();

SeederData();
void SeederData()
{
    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope? scope = scopedFactory.CreateScope())
    {
        Seeder? service = scope.ServiceProvider.GetService<Seeder>();
        service.SeederAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
