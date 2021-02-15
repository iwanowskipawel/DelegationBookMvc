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
    public class KilometersCardsController : Controller
    {
        private readonly DelegationBookContext _context;

        public KilometersCardsController(DelegationBookContext context)
        {
            _context = context;
        }

        // GET: KilometersCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.KilometersCards
                .Include(k=>k.Trips)
                .Include(k=>k.Car)
                .ToListAsync());
        }

        // GET: KilometersCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kilometersCard = await _context.KilometersCards
                .Include(k=>k.Trips)
                .Include(k=>k.Car)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (kilometersCard == null)
            {
                return NotFound();
            }

            return View(kilometersCard);
        }

        // GET: KilometersCards/Create
        public IActionResult Create()
        {
            var cars = _context.Cars
                .OrderBy(c=>c.CarId)
                .Select(c => new SelectListItem($"{c.Model} - {c.RegistrationNumber}", c.CarId.ToString()));

            ViewData["Cars"] = new SelectList(cars,"Value","Text");

            return View();
        }

        // POST: KilometersCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,CardSymbol,Car,WorkCardNumber")] KilometersCard kilometersCard)
        {
            if (ModelState.IsValid)
            {
                kilometersCard.Car = await _context.Cars.FindAsync(kilometersCard.Car.CarId);

                _context.Add(kilometersCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kilometersCard);
        }

        // GET: KilometersCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kilometersCard = await _context.KilometersCards
                .Include(k=>k.Car)
                .FirstOrDefaultAsync(k=>k.CardId == id);
            
            if (kilometersCard == null)
            {
                return NotFound();
            }

            var cars = _context.Cars
                .Include(c => c.KilometersCards)
                .OrderBy(c => c.CarId)
                .Select(c => new SelectListItem
                {
                    Text = $"{c.Model} - {c.RegistrationNumber}",
                    Value = c.CarId.ToString()
                });

            ViewData["Cars"] = new SelectList(cars, "Value", "Text");

            return View(kilometersCard);
        }

        // POST: KilometersCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardId,CardSymbol,Car,WorkCardNumber")] KilometersCard kilometersCard)
        {
            if (id != kilometersCard.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kilometersCard.Car = await _context.Cars.FindAsync(kilometersCard.Car.CarId);

                    _context.Update(kilometersCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KilometersCardExists(kilometersCard.CardId))
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
            return View(kilometersCard);
        }

        // GET: KilometersCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kilometersCard = await _context.KilometersCards
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (kilometersCard == null)
            {
                return NotFound();
            }

            return View(kilometersCard);
        }

        // POST: KilometersCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kilometersCard = await _context.KilometersCards.FindAsync(id);
            _context.KilometersCards.Remove(kilometersCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KilometersCardExists(int id)
        {
            return _context.KilometersCards.Any(e => e.CardId == id);
        }
    }
}
