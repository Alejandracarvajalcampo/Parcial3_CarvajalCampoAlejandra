using Microsoft.AspNetCore.Mvc.Rendering;

namespace WashingCarDB.Helper
{

    public interface IDropDownListsHelper
    {

        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();
        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync(Guid serviceId);

    }
}

