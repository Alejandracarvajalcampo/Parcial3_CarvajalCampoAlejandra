using Microsoft.AspNetCore.Mvc.Rendering;

namespace WashingCarDB.Helper
{

    public interface IDropDownListsHelper
    {
        Task<IEnumerable<SelectListItem>> GetDDLVehiclesAsync();

        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();
        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync(Guid serviceId);

        Task<IEnumerable<SelectListItem>> GetDDLVehiclesDetailsAsync();

        Task<IEnumerable<SelectListItem>> GetDDLVehiclesAsync(String stateId);
    }
}

