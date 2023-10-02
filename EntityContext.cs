using Microsoft.EntityFrameworkCore;

namespace ChangeDetectorComplexEntityCosmos;

public class EntityContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new Interceptor());
        optionsBuilder.UseCosmos("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            "Entities");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>()
            .HasKey(e => e.Id);
        modelBuilder.Entity<Entity>()
            .OwnsOne<Complex>(e => e.Complex);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Entity> Entities { get; set; }
}