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
        public static int InsertCliente(Cliente Entidad)
        {
            using (SqlConnection bd = new SqlConnection(Conexion.ConexionString()))
            {
                bd.Open();
                SqlCommand cmd = new SqlCommand("InsertCliente", bd);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            

            
                    


            


        }

    }
}
