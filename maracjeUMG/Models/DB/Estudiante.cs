using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Asignacions = new HashSet<Asignacion>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Carne { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
