using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Dia
    {
        public Dia()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdDia { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
