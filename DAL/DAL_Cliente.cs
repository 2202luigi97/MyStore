using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;

namespace DAL
{
    public static class DAL_Cliente
    {
        //metodo de insertar con SP
        public static int InsertCliente(Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("InsertCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Celular", Entidad.Celular);
                cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
                cmd.Parameters.AddWithValue("IdUsuarioRegistra", Entidad.IdUsuarioRegistra);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        //metodo de insertar con entity framework
        public static Cliente Insert(Cliente Entidad)
        {
            using (BDContexto bd = new BDContexto()) 
            {
                bd.Cliente.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static int UpdateCliente(Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("UpdateCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Celular", Entidad.Celular);
                cmd.Parameters.AddWithValue("@Correo", Entidad.Correo);
                cmd.Parameters.AddWithValue("IdUsuarioActualiza", Entidad.IdUsuarioActualiza);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int DeleteCliente(Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("DeleteCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", Entidad.IdCliente);
                cmd.Parameters.AddWithValue("IdUsuarioActualiza", Entidad.IdUsuarioActualiza);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static DataTable SelectCliente(int IdCliente)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("SelectCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
                
            }
        }

    }
}
