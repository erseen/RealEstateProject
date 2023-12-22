using Emlak.Api.Extensions;
using Emlak.Api.Identity;
using Emlak.Api.Repository;
using Emlak.Api.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


///Identity Knfigurasyonu ////



builder.Services.AddNewtonSoft();
builder.Services.RegisterEstateRepository();
builder.Services.RegisterRealEstateService();
builder.Services.RegisterWorkPlaceRepository();
builder.Services.RegisterWorkPlaceService();
builder.Services.ConfigureAutoMapper();
builder.Services.CorsPolicy();
builder.Services.RegisterAuthenticationService();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddResponseCache();
builder.Services.AddResponseCaching();

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ApplicationContext; Integrated Security = True;"));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    //pasword
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    //Lockout
    options.Lockout.MaxFailedAccessAttempts = 5;
    //Oturum açýk kalma süresi 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

});

/// Identity Konfigurasyonu Sonu


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
