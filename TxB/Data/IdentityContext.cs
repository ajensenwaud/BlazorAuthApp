using TxB.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TxB.Data;

public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public override DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    private ILogger<IdentityContext> Logger { get; set; }

    public DbSet<Word> Words => Set<Word>();

    public DbSet<Topic> Topics => Set<Topic>();

    public DbSet<Rating> Ratings => Set<Rating>();

    public DbSet<Proposition> Propositions => Set<Proposition>();
    

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

        var userRole = new ApplicationRole
        {
            Name = "User", NormalizedName = "USER", Id = Guid.NewGuid(), ConcurrencyStamp = Guid.NewGuid().ToString()
        };
        var adminRole = new ApplicationRole
        {
            Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid(), ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var techTopic = new Topic
        {
            Id = 1,
            TopicName = "Tech"
        };
        
        var txbTopic = new Topic
        {
            Id = 2,
            TopicName = "TxB"
        };
        

        builder.Entity<ApplicationRole>().HasData(userRole);
        builder.Entity<ApplicationRole>().HasData(adminRole);
        builder.Entity<Topic>().HasData(techTopic);
        builder.Entity<Topic>().HasData(txbTopic);
        var hasher = new PasswordHasher<ApplicationUser>();

        // Seed admin user (change to your own liking)
        var admin = new ApplicationUser
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
        builder.Entity<ApplicationUser>().HasData(admin);
        
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