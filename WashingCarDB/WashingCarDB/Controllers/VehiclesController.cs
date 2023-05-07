
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WashingCarDB.DAL.Entities;
using WashingCarDB.Helper;
using WashingCarDB.Models;

namespace WashingCarDB.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IDropDownListsHelper _ddlHelper;

        public VehiclesController(DatabaseContext context, IDropDownListsHelper dropDownListsHelper)
        {
            _context = context;
            _ddlHelper = dropDownListsHelper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
              return _context.Vehicles != null ? 
                          View(await _context.Vehicles
                          .ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Categories'  is null.");
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            VehicleViewModel vehicleViewModel = new()
            {
                Id = Guid.NewGuid(),
                Services = await _ddlHelper.GetDDLServicesAsync(),
            };
            
            return View(vehicleViewModel);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
            
                vehicleViewModel.Id = Guid.NewGuid();
                vehicleViewModel.Service = await _context.Services.FindAsync(vehicleViewModel.ServiceId);
                vehicleViewModel.Services = await _ddlHelper.GetDDLServicesAsync(vehicleViewModel.ServiceId);

                VehicleDetail vehicleDetail = new() {

                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Vehicle = vehicleViewModel,


                };
                _context.Add(vehicleViewModel);
                _context.Add(vehicleDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleViewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Owner,NumberPlate,Id")] Vehicle vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesExists(vehicles.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'DatabaseContext.Categories'  is null.");
            }
            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles != null)
            {
                _context.Vehicles.Remove(vehicles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclesExists(Guid id)
        {
          return (_context.Vehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
