using System.ComponentModel.DataAnnotations;


namespace WashingCarDB.DAL.Entities;

public class VehicleDetail: Entity
{

    [Display(Name = "Fecha de creacion")]
    public string CreationDate { get; set; }

    [Display(Name = "Fecha de entrega")]
    public string? DeliveryDate { get; set; }

    public ICollection<Vehicle>? Vehicles { get; set; }

}
