using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Asistencium
    {
        public int IdAsistencia { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
