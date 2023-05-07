using Microsoft.AspNetCore.Mvc.Rendering;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.Models
{
    public class VehicleViewModel : Vehicle
    {

        public Guid ServiceId { get;set; }

        public IEnumerable<SelectListItem> Services { get; set; }
    }
}
