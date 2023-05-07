using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.DAL;
public class Vehicles : Entity
{

    [Display(Name = "Propietario")]
    [MaxLength(50, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
    public string Owner { get; set; }

    [Display(Name = "Numero de placa")]
    [MaxLength(7, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
    [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
    public string NumberPlate { get; set; }

    public ICollection<Services> services { get; set; }

    public VehicleDetails VehicleDetails { get; set; }  


}
