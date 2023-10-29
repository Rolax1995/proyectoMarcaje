using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Catedratico
    {
        public Catedratico()
        {
            Cursos = new HashSet<Curso>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdCatedratico { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
