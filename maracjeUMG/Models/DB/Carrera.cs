using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Carrera
    {
        public Carrera()
        {
            CentroCarreras = new HashSet<CentroCarrera>();
        }

        public int IdCarrera { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CentroCarrera> CentroCarreras { get; set; }
    }
}
