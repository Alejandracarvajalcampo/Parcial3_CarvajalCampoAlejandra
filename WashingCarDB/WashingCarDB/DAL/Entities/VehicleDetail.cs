using System.ComponentModel.DataAnnotations;


namespace WashingCarDB.DAL.Entities;

public class VehicleDetail: Entity
{

    [Display(Name = "Fecha de creacion")]
    public DateTime? CreationDate { get; set; }

    [Display(Name = "Fecha de entrega")]
    public DateTime? DeliveryDate { get; set; }

    [Display(Name = "Vehiculo")]
    public Vehicle? Vehicle { get; set; }

}
