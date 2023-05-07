using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.DAL;

public class VehicleDetails: Entity
{

    [Display(Name = "Fecha de creacion")]
    public string CreationDate { get; set; }

    [Display(Name = "Fecha de entrega")]
    public string DeliveryDate { get; set; }

    public ICollection<Vehicles> Vehicles { get; set; }

}
