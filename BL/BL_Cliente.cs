using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data;

namespace BL
{
    public static class BL_Cliente
    {
        public static int InsertCliente(Cliente Entidad)
        {
            return DAL_Cliente.InsertCliente(Entidad);
        }
        public static int UpdateCliente(Cliente Entidad)
        {
            return DAL_Cliente.UpdateCliente(Entidad);
        }
        public static int DeleteCliente(Cliente Entidad)
        {
            return DAL_Cliente.DeleteCliente(Entidad);
        }
        public static DataTable SelectCliente(int IdCliente)
        {
            return DAL_Cliente.SelectCliente(IdCliente);
        }
    }
}
