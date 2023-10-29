using marcajeUMG.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace marcajeUMG.Controllers
{
    public class UsuariosController : Controller
    {
        //private readonly marcajeUMGContext _context;

        /*public UsuariosController(marcajeUMGContext context)
        {
            _context = context;
        }*/
        public Models.DB.marcajeUMGContext _context;

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                var marcajeUMGContext = db.Usuarios.Include(u => u.IdPropietario1).Include(u => u.IdPropietarioNavigation).Include(u => u.IdTipoUsuarioNavigation);
                return View(await marcajeUMGContext.ToListAsync());
            }

        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                if (id == null || db.Usuarios == null)
                {
                    return NotFound();
                }

                var usuario = await db.Usuarios
                    .Include(u => u.IdPropietario1)
                    .Include(u => u.IdPropietarioNavigation)
                    .Include(u => u.IdTipoUsuarioNavigation)
                    .FirstOrDefaultAsync(m => m.IdUsuario == id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return View(usuario);
            }

        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            using (var db = new Models.DB.marcajeUMGContext())
            {
                List<Models.DB.Estudiante> estudiantes = db.Estudiantes.ToList();
                List<Models.DB.Catedratico> catedraticos = db.Catedraticos.ToList();
                ViewData["IdPropEst"] = new SelectList(estudiantes, "IdEstudiante", "Carne");
                ViewData["IdPropCat"] = new SelectList(catedraticos, "IdCatedratico", "Nombre");
            }


            // 
            //ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "Descripcion");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdPropietario,IdTipoUsuario,Nombre,Correo,Contraseña")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPropietario"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Carne", usuario.IdPropietario);
            ViewData["IdPropietario"] = new SelectList(_context.Catedraticos, "IdCatedratico", "Nombre", usuario.IdPropietario);
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "Descripcion", usuario.IdTipoUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdPropietario"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Carne", usuario.IdPropietario);
            ViewData["IdPropietario"] = new SelectList(_context.Catedraticos, "IdCatedratico", "Nombre", usuario.IdPropietario);
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "Descripcion", usuario.IdTipoUsuario);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdPropietario,IdTipoUsuario,Nombre,Correo,Contraseña")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdPropietario"] = new SelectList(_context.Estudiantes, "IdEstudiante", "Carne", usuario.IdPropietario);
            ViewData["IdPropietario"] = new SelectList(_context.Catedraticos, "IdCatedratico", "Nombre", usuario.IdPropietario);
            ViewData["IdTipoUsuario"] = new SelectList(_context.TipoUsuarios, "IdTipoUsuario", "Descripcion", usuario.IdTipoUsuario);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdPropietario1)
                .Include(u => u.IdPropietarioNavigation)
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'marcajeUMGContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
