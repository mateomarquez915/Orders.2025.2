using Orders.Shared.Entities;

namespace Orders.Backend.Data;

public class seedDb
{
    private readonly DataContext _context;

    public seedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckCategoriesASync();
    }

    private async Task CheckCategoriesASync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Calzado" });
            _context.Categories.Add(new Category { Name = "Tecnologia" });
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country { Name = "Colombia" });
            _context.Countries.Add(new Country { Name = "Bolivia" });
            await _context.SaveChangesAsync();
        }
    }
}