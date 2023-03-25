using System;
using System.Collections.Generic;
using System.Linq;
using EL;

namespace DAL
{
    public static class DAL_Roles
    {
        //Forma mas optima de hacer un insert con entity
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
        //otra manera con entity
        public static Roles InsertarRoles(Roles Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
               Roles Registro_a_Guardar= new Roles();

                Registro_a_Guardar.Rol=Entidad.Rol;
                Registro_a_Guardar.IdUsuarioRegistra = Entidad.IdUsuarioRegistra;
                Registro_a_Guardar.Activo = true;
                Registro_a_Guardar.FechaRegistro=DateTime.Now;

                bd.Roles.Add(Registro_a_Guardar);
                bd.SaveChanges();
                return Registro_a_Guardar;
            }
        }
        //Udpate con Entity
        public static bool UpdateRol(Roles Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Roles.Find(Entidad.IdRol);
                RegistroBD.Rol = Entidad.Rol;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
            
        }
        //Update con Entity y Linq
        public static bool ActualizarRol(Roles Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = (from tabla in bd.Roles where tabla.IdRol == Entidad.IdRol select tabla).SingleOrDefault();

                if (RegistroBD != null)
                {
                    RegistroBD.Rol = Entidad.Rol;
                    RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                    RegistroBD.FechaActualizacion = DateTime.Now;
                    return bd.SaveChanges() > 0;
                }

                return false;
            }

        }
        //Delete Lógico
        public static bool DeleteRol(Roles Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = bd.Roles.Find(Entidad.IdRol);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                RegistroBD.FechaActualizacion = DateTime.Now;
                return bd.SaveChanges() > 0;
            }

        }
        //Delete Lógico con Entity y Linq
        public static bool EliminarRol(Roles Entidad)
        {
            using (BDContexto bd = new BDContexto())
            {
                var RegistroBD = (from tabla in bd.Roles where tabla.IdRol == Entidad.IdRol select tabla).SingleOrDefault();

                if (RegistroBD != null)
                {
                    RegistroBD.Activo = false;
                    RegistroBD.IdUsuarioActualiza = Entidad.IdUsuarioActualiza;
                    RegistroBD.FechaActualizacion = DateTime.Now;
                    return bd.SaveChanges() > 0;
                }

                return false;
            }

        }
        //select Activos con Entity
        public static List<Roles> List(bool Activo = true) 
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Roles.Where(a=>a.Activo==Activo).ToList();
            }
        }
        //Select Activos con Entity y Linq
        public static List<Roles> Lista(bool Activo = true)
        {
            using (BDContexto bd = new BDContexto())
            {
                return (from tabla in bd.Roles where tabla.Activo == Activo select tabla).ToList();
            }
        }
        //Select Un Registro
        public static Roles SelectRegistro(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Roles.Where(a => a.IdRol== IdRegistro).SingleOrDefault();
            }
        }
        public static Roles SelectRegistro2(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Roles.Find(IdRegistro);
            }
        }
        //Con Entity y Linq
        public static Roles SelectRegistro3(int IdRegistro)
        {
            using (BDContexto bd = new BDContexto())
            {
                return (from tabla in bd.Roles where tabla.IdRol == IdRegistro select tabla).SingleOrDefault();
            }
        }
        //Select Dinamico
        public static List<Roles> Buscar(string Palabra)
        {
            using (BDContexto bd = new BDContexto())
            {
                return bd.Roles.Where(a => a.Rol.Contains(Palabra)).ToList();
            }
        }
        //Select con Entity Y Linq
        public static List<Roles> Buscar2(string Palabra)
        {
            using (BDContexto bd = new BDContexto())
            {
                return (from tabla in bd.Roles where tabla.Rol.Contains(Palabra) select tabla).ToList();
            }
        }
    }
}
