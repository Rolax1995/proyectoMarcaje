using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Jornadum
    {
        public Jornadum()
        {
            Ciclos = new HashSet<Ciclo>();
        }

        public int IdJornada { get; set; }
        public string Nombre { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }

        public virtual ICollection<Ciclo> Ciclos { get; set; }
    }
}
