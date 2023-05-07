using System.ComponentModel.DataAnnotations;

namespace WashingCarDB.DAL.Entities;
public class Vehicle : Entity
{

    [Display(Name = "Propietario")]
    [MaxLength(50, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
    public string Owner { get; set; }

    [Display(Name = "Numero de placa")]
    [MaxLength(7, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
    public string NumberPlate { get; set; }

    public Service? Service { get; set; }


}
