using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_RolPermiso
    {
        public static List<RolPermisos> List(int IdRol, bool Activo = true)
        {
            return DAL_RolPermiso.List(IdRol, Activo);
        }
    }
}
