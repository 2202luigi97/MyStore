using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using BL;
using Utilidades;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] Key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");//24 Caracteres
            byte[] IV = Encoding.UTF8.GetBytes("Pr0y3ct03J3mpl00");//16 Caracteres

            Usuarios user = new Usuarios();
            user.IdUsuario = 5;
            user.IdUsuarioActualiza = 5;
            user.Password = Encripty.Encrypt("123", Key, IV);
            BL_Usuarios.PasswordUpdate(user);

            //Roles roles = new Roles();


            //roles.Rol = "Caja";
            //roles.IdUsuarioRegistra = 1;
            //Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);

            //roles.Rol = "Jefe de Almacen";
            //roles.IdUsuarioRegistra = 1;
            //Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);

            //roles.Rol = "Oficial de Bodega";
            //roles.IdUsuarioRegistra = 1;
            //Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);

            //roles.Rol = "Jefe de Contabilidad";
            //roles.IdUsuarioRegistra = 1;
            //Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);

            //foreach (var item in BL_Roles.Buscar2("ca"))
            //{
            //    Console.WriteLine(item.IdRol + "\t" + item.Rol + "\n");
            //}

            //roles = BL_Roles.SelectRegistro3(4);
            //Console.WriteLine(roles.IdRol + "\t" + roles.Rol + "\n");

            //Console.ReadLine();

        }
    }
}
