using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WashingCarDB.DAL.Entities;
using WashingCarDB.Helper;

namespace WashingCarDB.Services
{
    public class DropDownListsHelper : IDropDownListsHelper
    {
        private readonly DatabaseContext _context;

        public DropDownListsHelper(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLVehiclesAsync()
        {
            List<SelectListItem> listVehicles = await _context.Vehicles
                .Select(c => new SelectListItem
                {
                    Text = c.NumberPlate, //Col
                    Value = c.Id.ToString(), //Guid                    
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            listVehicles.Insert(0, new SelectListItem
            {
                Text = "Selecione una Vehicles...",
                Value = Guid.Empty.ToString(), //Cambio el 0 por Guid.Empty ya que debo manejar el mismo tipo de dato en todo el DDL
                Selected = true //Le coloco esta propiedad para que me salga seleccionada por defecto desde la UI
            });

            return listVehicles;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync()
        {
            List<SelectListItem> listServices = await _context.Services
                .Select(c => new SelectListItem
                {
                    Text = c.Name, //Col
                    Value = c.Id.ToString(), //Guid                    
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            listServices.Insert(0, new SelectListItem
            {
                Text = "Selecione un servicio...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listServices;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync(Guid serviceId)
        {
            List<SelectListItem> listServices = await _context.Services
                 .Where(s => s.Id == serviceId)
                 .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString(),
                })
                .OrderBy(s => s.Text)
                .ToListAsync();

            listServices.Insert(0, new SelectListItem
            {
                Text = "Selecione un servicio...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listServices;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLVehiclesDetailsAsync()
        {
            List<SelectListItem> listVehiclesDetails = await _context.VehiclesDetails
                .Select(c => new SelectListItem
                {
                    Text = "Detalle", //Col
                    Value = c.Id.ToString(), //Guid                    
                })
                .OrderBy(c => c.Text)
                .ToListAsync();

            listVehiclesDetails.Insert(0, new SelectListItem
            {
                Text = "Selecione un servicio...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listVehiclesDetails;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLVehiclesAsync(string numberPlate)
        {
            List<SelectListItem> listStatesByCountryId = await _context.Vehicles
                .Where(s => s.NumberPlate == numberPlate)
                .Select(s => new SelectListItem
                {
                    Text = "numberPlate",
                    Value = s.Id.ToString(),
                })
                .OrderBy(s => s.Text)
                .ToListAsync();

            listStatesByCountryId.Insert(0, new SelectListItem
            {
                Text = "Selecione un vehicle...",
                Value = Guid.Empty.ToString(),
                Selected = true
            });

            return listStatesByCountryId;
        }

    }
}
