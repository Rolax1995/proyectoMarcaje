using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Curso
    {
        public Curso()
        {
            Asignacions = new HashSet<Asignacion>();
            Asistencia = new HashSet<Asistencium>();
        }

        public int IdCurso { get; set; }
        public int IdCiclo { get; set; }
        public int IdCatedratico { get; set; }
        public int IdDia { get; set; }
        public string Nombre { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public int MaxEstudiante { get; set; }

        public virtual Catedratico IdCatedraticoNavigation { get; set; }
        public virtual Ciclo IdCicloNavigation { get; set; }
        public virtual Dia IdDiaNavigation { get; set; }
        public virtual ICollection<Asignacion> Asignacions { get; set; }
        public virtual ICollection<Asistencium> Asistencia { get; set; }
    }
}
