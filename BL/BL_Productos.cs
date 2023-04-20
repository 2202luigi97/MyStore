using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BL_Productos
    {
        public static List<vProducto> vProductos(bool Activo = true)
        {
            return DAL_Productos.vProductos(Activo);
        }
        public static vProducto vproducto(int IdRegistro)
        {
            return DAL_Productos.vproducto(IdRegistro);
        }
    }
}
