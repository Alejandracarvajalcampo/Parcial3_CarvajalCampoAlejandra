
using System.ComponentModel.DataAnnotations;

namespace WashingCarDB.DAL.Entities;
public class Service: Entity
{

    [Display  (Name = "Servicios")]
    [MaxLength (100, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
    public String Name { get; set; }
    public Decimal Price { get; set; }

    public Vehicle? Vehicle { get; set; }


}


