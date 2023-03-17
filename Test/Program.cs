using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using BL;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Roles roles = new Roles();

            roles.Rol = "Gratis";
            roles.IdUsuarioRegistra = 1;

            Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);
            Console.ReadLine();

        }
    }
}
