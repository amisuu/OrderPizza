using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelevantPizza.Data;
using RelevantPizza.Models;
using RelevantPizza.VievModel;

namespace RelevantPizza.Controllers
{
    public class EmployeController : Controller
    {
        private readonly PizzaContext _context;

        public EmployeController(PizzaContext context)
        {
            _context = context;
        }

        // GET: Employe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // GET: Employe/Create
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: Employe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Role,PhoneNumber,Salary")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employe);
        }

        // GET: Employe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employees.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        // POST: Employe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Role,PhoneNumber,Salary")] Employe employe)
        {
            if (id != employe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.ID))
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
            return View(employe);
        }

        // GET: Employe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employees
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employe = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}
