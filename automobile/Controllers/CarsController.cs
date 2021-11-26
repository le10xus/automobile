using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automobile.Data;
using Automobile.Models;
using Automobile.Providers;

namespace Automobile.Controllers
{
    public class CarsController : Controller
    {
        private readonly AutomobileContext _context;
        private readonly ICarProvider _carProvider;

        public CarsController(AutomobileContext context, ICarProvider carProvider)
        {
            _context = context;
            _carProvider = carProvider;
        }

        /// <summary>
        /// Get cars
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var cars = from car in _context.Cars
                       select car;

            return View(await _carProvider.GetCarsPage(cars, pageNumber ?? 1));
        }

        /// <summary>
        /// GET: Cars/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Cars/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        /// <summary>
        /// GET: Cars/Create
        /// </summary>
        /// <returns></returns>
        [HttpGet("Cars/Create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Cars/Create
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost("Cars/Create"), ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Color,Type,Weight")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        /// <summary>
        ///  GET: Cars/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Cars/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        /// <summary>
        /// POST: Cars/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost("Cars/Edit/{id}"), ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Color,Type,Weight")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        /// <summary>
        /// GET: Cars/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Cars/Delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        /// <summary>
        /// POST: Cars/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Cars/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// GET: Cars/SendEmail/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpGet("Cars/SendEmail/{id}"), ActionName("SendEmail")]
        public async Task<IActionResult> SendEmail(int id, string destination, string source)
        {
            var car = await _context.Cars.FindAsync(id);
            _carProvider.SendEmail(car, destination, source);
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
