using EL;
using DAL;

namespace BL
{
    public class BL_Roles
    {
        public static Roles InsertRoles(Roles Entidad)
        {
            return DAL_Roles.InsertRoles(Entidad);
        }
    }
}
