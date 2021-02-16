using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DelegationBook.Data;
using DelegationBook.Models;

namespace DelegationBook.Controllers
{
    public class TripsController : Controller
    {
        private readonly DelegationBookContext _context;

        public TripsController(DelegationBookContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {

            return View(await _context.Trips
                .Include(p=>p.Keeper)
                .Include(d=>d.Driver)
                .Include(p=>p.Project)
                .ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t=>t.Keeper)
                .Include(t=>t.Driver)
                .Include(t=>t.KilometersCard.Car)
                .Include(t=>t.Project)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public async Task<IActionResult> Create()
        {
            var employees = _context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => e)
                .Distinct();
            var drivers = _context.Employees
                 .Where(e => e.IsDriver)
                 .OrderBy(d => d.LastName)
                 .Select(d => d)
                 .Distinct();
            var projects = _context.Projects
                .OrderBy(p => p.Symbol)
                .Select(p => p)
                .Distinct();
            var kilometerCards = _context.KilometersCards
                .OrderBy(c => c.CardId)
                .Select(c => c)
                .Distinct();

            ViewData["Employees"] = new SelectList(await employees.ToListAsync(), nameof(Employee.EmployeeId), nameof(Employee.FullName));
            ViewData["Drivers"] = new SelectList(await drivers.ToListAsync(), nameof(Employee.EmployeeId), nameof(Employee.FullName));
            ViewData["Projects"] = new SelectList(await projects.ToListAsync(), nameof(Project.ProjectId), nameof(Project.Symbol));
            ViewData["KilometerCards"] = new SelectList(await kilometerCards.ToListAsync(), nameof(KilometersCard.CardId), nameof(KilometersCard.CardSymbol));

            Trip trip = new Trip();

            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TripId,DepartureDate,ArrivalDate,Destination,Project,KilometersCard,Keeper,Driver,InitialMeter,FinalMeter")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                trip.Keeper = await _context.Employees.FindAsync(trip.Keeper.EmployeeId);
                trip.Driver = await _context.Employees.FindAsync(trip.Driver.EmployeeId);
                trip.Project = await _context.Projects.FindAsync(trip.Project.ProjectId);
                trip.KilometersCard = await _context.KilometersCards.FindAsync(trip.KilometersCard.CardId);

                _context.Trips.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var employees = _context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => e)
                .Distinct();
            var drivers = _context.Employees
                 .Where(e => e.IsDriver)
                 .OrderBy(d => d.LastName)
                 .Select(d => d)
                 .Distinct();
            var projects = _context.Projects
                .OrderBy(p => p.Symbol)
                .Select(p => p)
                .Distinct();

            ViewData["Employees"] = new SelectList(await employees.ToListAsync(), nameof(Employee.EmployeeId), nameof(Employee.FullName));
            ViewData["Drivers"] = new SelectList(await drivers.ToListAsync(), nameof(Employee.EmployeeId), nameof(Employee.FullName));
            ViewData["Projects"] = new SelectList(await projects.ToListAsync(), nameof(Project.ProjectId), nameof(Project.Symbol));


            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, [Bind("TripId,DepartureDate,ArrivalDate,Keeper,Driver,Project,Destination,InitialMeter,FinalMeter")] Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trip.Keeper = await _context.Employees.FindAsync(trip.Keeper.EmployeeId);
                    trip.Driver = await _context.Employees.FindAsync(trip.Driver.EmployeeId);
                    trip.Project = await _context.Projects.FindAsync(trip.Project.ProjectId);

                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
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
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}
