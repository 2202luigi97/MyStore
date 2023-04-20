using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Categorias
    {
        public static List<Categorias> List(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Categorias.Where(a => a.Activo == Activo).ToList();
            }
        }
    }
}
