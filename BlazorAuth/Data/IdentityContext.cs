using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorAuth.Data;

public class IdentityContext : IdentityDbContext<BlazorAuthUser, BlazorAuthRole, Guid>
{
    private ILogger<IdentityContext> Logger { get; set; }

    public IdentityContext(DbContextOptions<IdentityContext> options, ILogger<IdentityContext> logger)
        : base(options)
    {
        Logger = logger;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        var userRole = new BlazorAuthRole
        {
            Name = "User", NormalizedName = "USER", Id = Guid.NewGuid(), ConcurrencyStamp = Guid.NewGuid().ToString()
        };
        var adminRole = new BlazorAuthRole
        {
            Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid(), ConcurrencyStamp = Guid.NewGuid().ToString()
        };
        

        builder.Entity<BlazorAuthRole>().HasData(userRole);
        builder.Entity<BlazorAuthRole>().HasData(adminRole);

        var hasher = new PasswordHasher<BlazorAuthUser>();
        
        // Seed admin user (change to your own liking)
        var admin = new BlazorAuthUser
        {
            Id = Guid.NewGuid(),
            UserName = "Admin",
            NormalizedUserName = "Admin",
            Email = "anders@jensenwaud.com",
            NormalizedEmail = "anders@jensenwaud.com",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "PlsResetMe!"),
            SecurityStamp = string.Empty,
            ConcurrencyStamp = string.Empty,
            PhoneNumber = "00000000",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            FirstName = "Anders Admin",
            LastName = "Jensen",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Is18OrAbove = true,
            ActivationKey = "",
            ResetKey = ""
        };
        builder.Entity<BlazorAuthUser>().HasData(admin);
        Logger.LogInformation($"Saved admin user with Id = {admin.Id} to the database");
            
        builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = userRole.Id,
                UserId = admin.Id 
            }
        );
        
        builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminRole.Id,
                UserId = admin.Id 
            }
        );
    }
}