using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BL
{
    public static class BL_Cliente
    {
        public static int InsertCliente(Cliente Entidad)
        {
            return DAL_Cliente.InsertCliente(Entidad);
        }
    }
}
