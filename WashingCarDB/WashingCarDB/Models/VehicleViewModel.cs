using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.Models
{
    public class VehicleViewModel : Vehicle
    {
        [Display(Name = "Servicio")]
        public Guid ServiceId { get;set; }

        public IEnumerable<SelectListItem> Services { get; set; }
    }
}
