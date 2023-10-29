using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Asignacion
    {
        public int IdAsignacion { get; set; }
        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
    }
}
