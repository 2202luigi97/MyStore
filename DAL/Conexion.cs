using System.Data.SqlClient;

namespace DAL
{
    public static class Conexion
    {
        private static string NombreAplicacion = "DiseñoWeb";
        private static string Servidor = @"DESKTOP-FL8S9TQ\SQLEXPRESS";
        private static string Usuario = "luigi";
        private static string Password = "&cuadra&";
        private static string BaseDatos = "Clientes";

        public static string ConexionString(bool sqlAutenticaton = true)
        {
            SqlConnectionStringBuilder constructor = new SqlConnectionStringBuilder()
            {
            ApplicationName = NombreAplicacion,
            DataSource = Servidor,
            InitialCatalog = BaseDatos,
            IntegratedSecurity = sqlAutenticaton
        };
            if (sqlAutenticaton ) 
            {
                constructor.UserID = Usuario;
                constructor.Password=Password;
            }
            return constructor.ConnectionString;
        }
    }
}
