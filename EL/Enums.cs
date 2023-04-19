using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Enums
    {
        public enum eMessage
        {
            Exito = 1,
            Alerta = 2,
            Error = 3,
            Info = 4
        }
        public enum eFormulario
        {
            AdministracionUsuarios = 3,
            Ventas = 1,
            Productos = 2
        }
        public enum eRoles
        {
            Administrador = 1,
            OficialVentas =4,
            Caja = 7,
            JefeAlmacen = 8,
            OficialBodega = 9,
        }
        public enum ePermisos
        {
            Escritura = 1,
            Anular = 2
        }
    }
}
