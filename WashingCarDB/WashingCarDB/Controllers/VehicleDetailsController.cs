using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WashingCarDB.DAL.Entities;
using WashingCarDB.Helper;

namespace WashingCarDB.Controllers
{
    public class VehicleDetailsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IUserHelper _userHelper;

        public VehicleDetailsController(DatabaseContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: VehicleDetails
        public async Task<IActionResult> Index()
        {
              return _context.VehiclesDetails != null ? 
                          View(await _context.VehiclesDetails
                          .Include(c => c.Vehicle)
                          .ThenInclude(v => v.Service)
                          .ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.States'  is null.");
        }

        // GET: VehicleDetails/Details
        public async Task<IActionResult> Details()
        {
            if (_context.VehiclesDetails == null)
            {
                return NotFound();
            }
            User user = await _userHelper.GetUserAsync(User.Identity.Name);
            var nameUser= "";
            if (user != null) {
                nameUser = user.FullName;
            }

            var vehicleDetails = await _context.VehiclesDetails
                .Include(d => d.Vehicle)
                .ThenInclude(v => v.Service)
                .FirstOrDefaultAsync(d => d.Vehicle.Owner == nameUser);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: VehicleDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails.FindAsync(id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }
            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CreationDate,DeliveryDate,Id")] VehicleDetail vehicleDetails)
        {
            if (id != vehicleDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDetailsExists(vehicleDetails.Id))
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
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VehiclesDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehiclesDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.VehiclesDetails == null)
            {
                return Problem("Entity set 'DatabaseContext.States'  is null.");
            }
            var vehicleDetails = await _context.VehiclesDetails.FindAsync(id);
            if (vehicleDetails != null)
            {
                _context.VehiclesDetails.Remove(vehicleDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDetailsExists(Guid id)
        {
          return (_context.VehiclesDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
