using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entites;
using Infrastructure;

namespace Web.Controllers
{
    public class MoServicesController : Controller
    {
        private readonly DataContext _context;

        public MoServicesController(DataContext context)
        {
            _context = context;
        }

        // GET: MoServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.MServices.ToListAsync());
        }

        // GET: MoServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moServices = await _context.MServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moServices == null)
            {
                return NotFound();
            }

            return View(moServices);
        }

        // GET: MoServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceName,serviceIcon,Id")] MoServices moServices)
        {
            if (ModelState.IsValid)
            {
                moServices.Id = Guid.NewGuid();
                _context.Add(moServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moServices);
        }

        // GET: MoServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moServices = await _context.MServices.FindAsync(id);
            if (moServices == null)
            {
                return NotFound();
            }
            return View(moServices);
        }

        // POST: MoServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ServiceName,serviceIcon,Id")] MoServices moServices)
        {
            if (id != moServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoServicesExists(moServices.Id))
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
            return View(moServices);
        }

        // GET: MoServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moServices = await _context.MServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moServices == null)
            {
                return NotFound();
            }

            return View(moServices);
        }

        // POST: MoServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var moServices = await _context.MServices.FindAsync(id);
            _context.MServices.Remove(moServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoServicesExists(Guid id)
        {
            return _context.MServices.Any(e => e.Id == id);
        }
    }
}
