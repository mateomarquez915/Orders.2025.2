using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities;

public class Country
{
    public int Id { get; set; }

    [Display(Name = "Pais")] // Representa al name como el nombre pais//
    [MaxLength(100, ErrorMessage = "EL campo {0} no puede tener mas de {1} caracteres.")] //capacidad que va a tener en caracteres y muestra el error que esta//
    [Required(ErrorMessage = "El campo {0] es obligatorio.")]
    public string Name { get; set; } = null!; //No permite nulos en el campo//
}