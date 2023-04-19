using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_RolFormulario
    {
        public static List<RolFormularios> List(int IdRol, bool Activo = true)
        {
            return DAL_RolFormulario.List(IdRol, Activo);
        }
    }
}
