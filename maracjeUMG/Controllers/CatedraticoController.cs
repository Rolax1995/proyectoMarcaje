using System.Linq;
using Microsoft.AspNetCore.Mvc;
using marcajeUMG.Models;
using Microsoft.EntityFrameworkCore;

namespace marcajeUMG.Controllers
{
    public class CatedraticoController : Controller
    {
        public IActionResult Index()
        {
            List<Catedratico> lst = new List<Catedratico>();

            using (var db = new Models.DB.marcajeUMGContext())
            {
                lst = (from d in db.Catedraticos
                       select new Catedratico
                       {
                           idCatedratico = d.IdCatedratico,
                           Nombre = d.Nombre,
                           Telefono = d.Telefono
                       }).ToList();
            }

            return View(lst);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Catedratico maestro)
        {
            if(maestro.Nombre != null && maestro.Telefono != null)
            {
                marcajeUMG.Models.DB.Catedratico catedratico = new marcajeUMG.Models.DB.Catedratico();

                catedratico.Nombre = maestro.Nombre;
                catedratico.Telefono = maestro.Telefono;

                var db = new Models.DB.marcajeUMGContext();

                db.Catedraticos.Add(catedratico);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Catedratico");
        }

        public IActionResult Editar(int idMaestro)
        {
            List<Catedratico> lst = new List<Catedratico>();
            using (var db = new Models.DB.marcajeUMGContext())
            {
                lst = (from d in db.Catedraticos
                       select new Catedratico
                       {
                           idCatedratico = d.IdCatedratico,
                           Nombre = d.Nombre,
                           Telefono = d.Telefono
                       }).ToList();
                var result = lst.Where(item => item.idCatedratico == idMaestro).FirstOrDefault();
                return View(result);
            }
            
        }

        [HttpPost]
        public IActionResult Update(Catedratico maestro)
        {
            if(maestro.Nombre != null && maestro.Telefono != null)
            {
                using (var db = new Models.DB.marcajeUMGContext())
                {
                    var entidad = db.Catedraticos.Find(maestro.idCatedratico);
                    entidad.Nombre = maestro.Nombre;
                    entidad.Telefono = maestro.Telefono;

                    db.Entry(entidad).State = EntityState.Modified;
                    db.SaveChanges();
                } 
            }
            return RedirectToAction("Index", "Catedratico");
        }


        public IActionResult Eliminar(int idMaestro)
        {
            List<Catedratico> lst = new List<Catedratico>();
            using (var db = new Models.DB.marcajeUMGContext())
            {
                var entidad = db.Catedraticos.Find(idMaestro);

                db.Catedraticos.Remove(entidad);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Catedratico");
        }
    }
}
