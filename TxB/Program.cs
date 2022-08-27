using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TxB.Data;
using TxB.Services;
using TxB.Util;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

/* if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(connectionString)); 
} else { */ 
    builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));
//}

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<IdentityContext>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddSingleton<SessionState>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<WordService>();
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

// Initialize database 
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();
    if (!dbContext.Words.Any())
    {
        DataInitializer.SeedTxBData(dbContext);
    }
}

app.Run();