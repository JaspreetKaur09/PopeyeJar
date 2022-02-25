using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PopeyeJar.Data;
using PopeyeJar.Models;

namespace PopeyeJar.Controllers
{
    public class JarsController : Controller
    {
        private readonly PopeyeJarContext _context;

        public JarsController(PopeyeJarContext context)
        {
            _context = context;
        }

        // GET: Jars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jar.ToListAsync());
        }

        // GET: Jars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jar = await _context.Jar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jar == null)
            {
                return NotFound();
            }

            return View(jar);
        }

        // GET: Jars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Colour,Material,Shape,Capacity,Rating")] Jar jar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jar);
        }

        // GET: Jars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jar = await _context.Jar.FindAsync(id);
            if (jar == null)
            {
                return NotFound();
            }
            return View(jar);
        }

        // POST: Jars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Colour,Material,Shape,Capacity,Rating")] Jar jar)
        {
            if (id != jar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JarExists(jar.Id))
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
            return View(jar);
        }

        // GET: Jars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jar = await _context.Jar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jar == null)
            {
                return NotFound();
            }

            return View(jar);
        }

        // POST: Jars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jar = await _context.Jar.FindAsync(id);
            _context.Jar.Remove(jar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JarExists(int id)
        {
            return _context.Jar.Any(e => e.Id == id);
        }
    }
}
