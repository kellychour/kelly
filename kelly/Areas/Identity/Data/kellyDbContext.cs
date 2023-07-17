using kelly.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using kelly.Models;

namespace kelly.Areas.Identity.Data;

public class kellyDbContext : IdentityDbContext<kellyUser>
{
    public kellyDbContext(DbContextOptions<kellyDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new kellyUserEntityConfiguration());
    }

    public DbSet<kelly.Models.Order>? Order { get; set; }

    public DbSet<kelly.Models.Product>? Product { get; set; }
}

public class kellyUserEntityConfiguration : IEntityTypeConfiguration<kellyUser>
{
    public void Configure(EntityTypeBuilder<kellyUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }

}