namespace marcajeUMG.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public int idTipo_Usuario { get; set; }

        public Usuario ValidarUsuario(string mail, string pass)
        {
            List<Usuario> lst = new List<Usuario>();
            using (var db = new Models.DB.marcajeUMGContext())
            {
                lst = (from d in db.Usuarios select new Usuario { 
                    Correo = d.Correo, 
                    Contraseña = d.Contraseña, 
                    idTipo_Usuario= d.IdTipoUsuario,
                    Nombre = d.Nombre 
                }).ToList();
                return lst.Where(item => item.Correo == mail && item.Contraseña == pass).FirstOrDefault();
            }

        }

    }

}
