using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using marcajeUMG.Models.DB;

namespace marcajeUMG.Controllers
{
    public class EstudiantesController : Controller
    {

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            using (var db = new Models.DB.marcajeUMGContext())
            return View(await db.Estudiantes.ToListAsync());
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (id == null || db.Estudiantes == null)
                {
                    return NotFound();
                }

                var estudiante = await db.Estudiantes
                    .FirstOrDefaultAsync(m => m.IdEstudiante == id);
                if (estudiante == null)
                {
                    return NotFound();
                }

                return View(estudiante);
            }
            
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,Nombre,Telefono,Carne")] Estudiante estudiante)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (ModelState.IsValid)
                {
                    db.Add(estudiante);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(estudiante);
            }
                
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (id == null || db.Estudiantes == null)
                {
                    return NotFound();
                }

                var estudiante = await db.Estudiantes.FindAsync(id);
                if (estudiante == null)
                {
                    return NotFound();
                }
                return View(estudiante);
            }
                
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,Nombre,Telefono,Carne")] Estudiante estudiante)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (id != estudiante.IdEstudiante)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Update(estudiante);
                        await db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EstudianteExists(estudiante.IdEstudiante))
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
                return View(estudiante);
            }
                
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (id == null || db.Estudiantes == null)
                {
                    return NotFound();
                }

                var estudiante = await db.Estudiantes
                    .FirstOrDefaultAsync(m => m.IdEstudiante == id);
                if (estudiante == null)
                {
                    return NotFound();
                }

                return View(estudiante);
            }
                
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (db.Estudiantes == null)
                {
                    return Problem("Entity set 'marcajeUMGContext.Estudiantes'  is null.");
                }
                var estudiante = await db.Estudiantes.FindAsync(id);
                if (estudiante != null)
                {
                    db.Estudiantes.Remove(estudiante);
                }

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
                
        }

        private bool EstudianteExists(int id)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            return db.Estudiantes.Any(e => e.IdEstudiante == id);
        }
    }
}
