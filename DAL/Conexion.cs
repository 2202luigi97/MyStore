using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class Conexion
    {
        private static string NombreAplicacion = "DiseñoWeb";
        private static string Servidor = "DESKTOP-FL8S9TQ\\SQLEXPRESS";
        private static string Usuario = "";
        private static string Password = "";
        private static string BaseDatos = "Clientes";

        public static string ConexionString(bool sqlAutenticaton=true)
        {
            SqlConnectionStringBuilder constructor = new SqlConnectionStringBuilder();
            constructor.ApplicationName= NombreAplicacion;
            constructor.DataSource = Servidor;
            constructor.InitialCatalog = BaseDatos;
            constructor.IntegratedSecurity = sqlAutenticaton;
            if (sqlAutenticaton ) 
            {
                constructor.UserID = Usuario;
                constructor.Password=Password;
            }
            return constructor.ConnectionString;
        }
    }
}
