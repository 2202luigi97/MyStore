using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using Utilidades;

namespace DAL
{
    public class DAL_Usuarios
    {
        private static byte[] Key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");//24 Caracteres
        private static byte[] IV = Encoding.UTF8.GetBytes("Pr0y3ct03J3mpl00");//16 Caracteres

        public static Usuarios Insert(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Usuarios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool ExisteUserName(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).Count() > 0;
            }
        }

        public static bool VerificarCuentaBloqueada(string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a=>a.UserName.ToLower()==UserName.ToLower()&&a.Bloqueado).Count() > 0;
            }
        }
        public static bool PasswordUpdate(Usuarios Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var Consulta = bd.Usuarios.Find(Entidad.IdUsuario);
                Consulta.Password = Entidad.Password;
                Consulta.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                Consulta.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower() && a.Password == Password).Count() > 0;
            }
        }
        public static short CantidadIntentosFallidos (string UserName)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Usuarios.Where(a=>a.UserName.ToLower()==UserName.ToLower()).SingleOrDefault().IntentosFallidos;
            }
        }
    }
}
