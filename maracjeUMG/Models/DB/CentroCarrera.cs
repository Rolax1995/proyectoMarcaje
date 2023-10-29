using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class CentroCarrera
    {
        public CentroCarrera()
        {
            Ciclos = new HashSet<Ciclo>();
        }

        public int IdCentroCarrera { get; set; }
        public int IdCentro { get; set; }
        public int IdCarrera { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual Centro IdCentroNavigation { get; set; }
        public virtual ICollection<Ciclo> Ciclos { get; set; }
    }
}
