using System;
using System.Collections.Generic;

namespace marcajeUMG.Models.DB
{
    public partial class Usuario
    {
        public Usuario()
        {
            Asistencia = new HashSet<Asistencium>();
        }

        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public virtual Estudiante IdPropietario1 { get; set; }
        public virtual Catedratico IdPropietarioNavigation { get; set; }
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Asistencium> Asistencia { get; set; }
    }
}
