using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class BaseDAL
    {
        private IDbConnection conn;

        private IDbConnection GetConnection()
        {
            var strConn = ConfigurationManager.ConnectionStrings["ConnexaoDados"].ConnectionString;
             conn = new SqlConnection(strConn);

            if(conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }
        
        public int ExecuteScalar(StringBuilder sb)
        {
            using (var conexao = GetConnection())
            {
                var cmd = conexao.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sb.ToString();
                cmd.CommandTimeout = 0;

                if (conexao.State != ConnectionState.Open)
                    conexao.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public bool ExecuteNonQuery(StringBuilder sb)
        {
            using (var conexao = GetConnection())
            {
                var cmd = conexao.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText= sb.ToString();
                cmd.CommandTimeout = 0;

                if (conexao.State != ConnectionState.Open)
                    conexao.Open();

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

                return false;
            }
        }

        public DataTable Consultar(StringBuilder sb)
        {
            using (var conexao = GetConnection())
            {
                if (conexao.State != ConnectionState.Open)
                    conexao.Open();

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    SqlCommand cmd = new SqlCommand(sb.ToString());
                    cmd.Connection = (SqlConnection)conexao;
                    da.SelectCommand = cmd;
                    cmd.CommandTimeout = 0;

                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
        }
    }
}
