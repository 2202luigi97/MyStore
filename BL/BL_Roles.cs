using EL;
using DAL;
using System.Collections.Generic;

namespace BL
{
    public class BL_Roles
    {
        public static Roles InsertRoles(Roles Entidad)
        {
            return DAL_Roles.InsertRoles(Entidad);
        }

        public static Roles InsertarRoles(Roles Entidad)
        {
            return DAL_Roles.InsertarRoles(Entidad);
        }

        public static bool UpdateRol(Roles Entidad)
        {
            return DAL_Roles.UpdateRol(Entidad);
        }

        public static bool ActualizarRol(Roles Entidad)
        {
            return DAL_Roles.ActualizarRol(Entidad);
        }

        public static bool DeleteRol(Roles Entidad)
        {
            return DAL_Roles.DeleteRol(Entidad);
        }

        public static bool EliminarRol(Roles Entidad)
        {
            return DAL_Roles.EliminarRol(Entidad);
        }

        public static List<Roles> List(bool Activo = true)
        {
            return DAL_Roles.List(Activo);
        }

        public static List<Roles> Lista(bool Activo = true)
        {
            return DAL_Roles.Lista(Activo);
        }

        public static Roles SelectRegistro(int IdRegistro)
        {
            return DAL_Roles.SelectRegistro(IdRegistro);
        }

        public static Roles SelectRegistro2(int IdRegistro)
        {
            return DAL_Roles.SelectRegistro2(IdRegistro);
        }

        public static Roles SelectRegistro3(int IdRegistro)
        {
            return DAL_Roles.SelectRegistro3(IdRegistro);
        }

        public static List<Roles> Buscar(string Palabra)
        {
            return DAL_Roles.Buscar(Palabra);
        }

        public static List<Roles> Buscar2(string Palabra)
        {
            return DAL_Roles.Buscar2(Palabra);
        }
    }
}
