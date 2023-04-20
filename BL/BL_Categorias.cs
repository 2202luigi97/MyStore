using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BL_Categorias
    {
        public static List<Categorias> List(bool Activo = true)
        {
            return DAL_Categorias.List(Activo);
        }
    }
}
