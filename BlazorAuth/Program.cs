using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorAuth.Data;
using BlazorAuth.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configure database:
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<BlazorAuthUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<BlazorAuthRole>()
    .AddEntityFrameworkStores<IdentityContext>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddSingleton<SessionState>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Logging.AddConsole();


// Password policy:
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
});

var app = builder.Build();
app.UseMiddleware<BlazorCookieLoginMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Error");


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
;

app.Run();