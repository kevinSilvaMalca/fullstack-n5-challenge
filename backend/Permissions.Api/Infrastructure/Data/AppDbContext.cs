using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<PermissionType> PermissionTypes => Set<PermissionType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PermissionType>().HasData(
            new PermissionType { Id = 1, Description = "Vacation" },
            new PermissionType { Id = 2, Description = "Sick Leave" },
            new PermissionType { Id = 3, Description = "Remote Work" }
        );
    }
}
