using System;
using EL;

namespace DAL
{
    public static class DAL_Roles
    {
        public static Roles InsertRoles(Roles Entidad)
        {
            using (BDContexto bd = new BDContexto()) 
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Roles.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
    }
}
