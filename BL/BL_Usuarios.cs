using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BL_Usuarios
    {
        public static bool ExisteUserName(string UserName)
        {
            return DAL_Usuarios.ExisteUserName(UserName);
        }
        public static bool VerificarCuentaBloqueada(string UserName)
        {
            return DAL_Usuarios.VerificarCuentaBloqueada(UserName);
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        {
            return DAL_Usuarios.ValidarCredenciales(UserName, Password);
        }
        public static short CantidadIntentosFallidos(string UserName)
        {
            return DAL_Usuarios.CantidadIntentosFallidos(UserName);
        }
    }
}
