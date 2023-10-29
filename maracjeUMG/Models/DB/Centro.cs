using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Centro
    {
        public Centro()
        {
            CentroCarreras = new HashSet<CentroCarrera>();
        }

        public int IdCentro { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<CentroCarrera> CentroCarreras { get; set; }
    }
}
