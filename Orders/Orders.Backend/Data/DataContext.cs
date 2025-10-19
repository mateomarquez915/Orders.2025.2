using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;

namespace Orders.Backend.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }

    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Metodo que se ejecuta cuando se crea el modelo de datos//
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<City>().HasIndex(x => new { x.StateId, x.Name }).IsUnique();
        modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<State>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
        disableCascadingDelete(modelBuilder);
    }

    private void disableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relations = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relation in relations)
        {
            relation.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}