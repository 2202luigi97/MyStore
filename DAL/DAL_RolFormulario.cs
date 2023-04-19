using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_RolFormulario
    {
        public static List<RolFormularios> List(int IdRol, bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.RolFormularios.Where(a => a.IdRol == IdRol && a.Activo == Activo).ToList();
            }
        }
    }
}
