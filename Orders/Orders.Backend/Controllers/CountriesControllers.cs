using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CountriesControllers : ControllerBase
{
    private readonly DataContext _context;

    public CountriesControllers(DataContext context)
    {
        _context = context;
    }

    [HttpGet] //para obtener todos los datos//
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Countries.ToListAsync()); //devuelve la lista de paises//
    }

    [HttpPost] //para crear un nuevo dato//
    public async Task<IActionResult> PostAsync(Country country)
    {
        _context.Countries.Add(country);//para agregar un nuevo pais//
        await _context.SaveChangesAsync();//para guardar los cambios en la base de datos//
        return Ok(country); //devuelve el pais creado//
    }
}