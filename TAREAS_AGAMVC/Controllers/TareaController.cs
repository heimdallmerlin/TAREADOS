using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TAREAS_AGAMVC.Models;

namespace TAREAS_AGAMVC.Controllers
{
    public class TareaController : Controller
    {
        private readonly BddtareasagaContext _context;

        public TareaController(BddtareasagaContext context)
        {
            _context = context;
        }

        // GET: Tarea
        public async Task<IActionResult> IndexF()
        
        {
            var bddtareasagaContext = _context.Tareas.Include(t => t.IdCatNavigation).Include(t => t.IdColNavigation).Where(t => t.EstatusTar == "Finalizada");
            return View(await bddtareasagaContext.ToListAsync());
        }

        public async Task<IActionResult> IndexP()

        {
            var bddtareasagaContext = _context.Tareas.Include(t => t.IdCatNavigation).Include(t => t.IdColNavigation).Where(t => t.EstatusTar == "Pendiente");
            //var bddtareasagaContext = _context.Tareas.Include(t => t.IdCatNavigation).Include(t => t.IdColNavigation);
            return View(await bddtareasagaContext.ToListAsync());
        }

        public async Task<IActionResult> IndexN()

        {
            var bddtareasagaContext = _context.Tareas.Include(t => t.IdCatNavigation).Include(t => t.IdColNavigation).Where(t => t.EstatusTar == "Nueva");
            return View(await bddtareasagaContext.ToListAsync());
        }



        // GET: Tarea/Create
        public IActionResult Create()
        {
            ViewData["IdCat"] = new SelectList(_context.Categoria, "IdCat", "IdCat");
            ViewData["IdCol"] = new SelectList(_context.Colaboradors, "IdCol", "IdCol");
            return View();
        }


        // GET: Tarea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tareas == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .Include(t => t.IdCatNavigation)
                .Include(t => t.IdColNavigation)
                .FirstOrDefaultAsync(m => m.IdTar == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }



        // POST: Tarea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTar,NombreTar,DescripcionTar,EstatusTar,IdCol,IdCat")] Tarea tarea)
        {
            _context.Add(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["IdCat"] = new SelectList(_context.Categoria, "IdCat", "IdCat", tarea.IdCat);
            ViewData["IdCol"] = new SelectList(_context.Colaboradors, "IdCol", "IdCol", tarea.IdCol);
            return View(tarea);
        }
        
        // GET: Tarea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tareas == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            ViewData["IdCat"] = new SelectList(_context.Categoria, "IdCat", "IdCat", tarea.IdCat);
            ViewData["IdCol"] = new SelectList(_context.Colaboradors, "IdCol", "IdCol", tarea.IdCol);
            return View(tarea);
        }

        // POST: Tarea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTar,NombreTar,DescripcionTar,EstatusTar,IdCol,IdCat")] Tarea tarea)
        {
            if (id != tarea.IdTar)
            {
                return NotFound();
            }

            try
            {
                _context.Update(tarea);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(tarea.IdTar))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            ViewData["IdCat"] = new SelectList(_context.Categoria, "IdCat", "IdCat", tarea.IdCat);
            ViewData["IdCol"] = new SelectList(_context.Colaboradors, "IdCol", "IdCol", tarea.IdCol);
            return View(tarea);
        }

        // GET: Tarea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tareas == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .Include(t => t.IdCatNavigation)
                .Include(t => t.IdColNavigation)
                .FirstOrDefaultAsync(m => m.IdTar == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        // POST: Tarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tareas == null)
            {
                return Problem("Entity set 'BddtareasagaContext.Tareas'  is null.");
            }
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea != null)
            {
                _context.Tareas.Remove(tarea);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareaExists(int id)
        {
          return (_context.Tareas?.Any(e => e.IdTar == id)).GetValueOrDefault();
        }
        
    }
}
