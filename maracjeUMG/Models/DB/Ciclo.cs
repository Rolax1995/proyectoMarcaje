using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Ciclo
    {
        public Ciclo()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdCiclo { get; set; }
        public int IdCentroCarrera { get; set; }
        public int IdJornada { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }

        public virtual CentroCarrera IdCentroCarreraNavigation { get; set; }
        public virtual Jornadum IdJornadaNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
