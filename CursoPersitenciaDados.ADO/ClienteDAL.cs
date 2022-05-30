using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class ClienteDAL : BaseDAL
    {
        public ClienteDAL()
        {

        }


        public List<Cliente> GetCliente(int? id = null)
        {
            List<Cliente> list = new List<Cliente>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Id,
		                        NomeCliente,
		                        SobreNome,
		                        CPF,
		                        RG,
		                        TelFixo,
		                        Email,
		                        DtNascimento,
		                        Ativo
	                        FROM Cliente ");

            if (id != null)
                sql.AppendFormat(@"WHERE Id = {0}", id.Value);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var cliente = new Cliente();
                cliente.Id = Convert.ToInt32(row["Id"]);
                cliente.NomeCliente = row["NomeCliente"].ToString();
                cliente.SobreNome = row["SobreNome"].ToString();
                cliente.CPF = row["CPF"].ToString();
                cliente.RG = row["RG"].ToString();
                cliente.TelFixo = row["TelFixo"].ToString();
                cliente.Email = row["Email"].ToString();
                cliente.DtNascimento = Convert.ToDateTime(row["DtNascimento"]);
                cliente.Ativo = Convert.ToBoolean(row["Ativo"]);

                cliente.Endereco = new Endereco();
                cliente.Endereco = new EnderecoDAL().GetEndereco(clienteId: cliente.Id);

                list.Add(cliente);
            }

            return list;
        }

        public int InserirCliente(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Cliente
                                (NomeCliente, SobreNome, CPF, RG, TelFixo, Email, DtNascimento)
                                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6}",
                                cliente.NomeCliente,
                                cliente.SobreNome,
                                cliente.CPF,
                                cliente.RG,
                                cliente.TelFixo,
                                cliente.Email,
                                cliente.DtNascimento);

            return ExecuteScalar(sql);
        }

        public bool UpdateCliente(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Cliente
                               SET NomeCliente='{0}',
                                    SobreNome='{1}',
                                    CPF='{2}',
                                    RG='{3}',
                                    TelFixo='{4}',
                                    Email='{5}',
                                    DtNascimento={6}
                                WHERE Id={7}",
                                cliente.NomeCliente,
                                cliente.SobreNome,
                                cliente.CPF,
                                cliente.RG,
                                cliente.TelFixo,
                                cliente.Email,
                                cliente.DtNascimento,
                                cliente.Id);

            return ExecuteNonQuery(sql);
        }

        public bool DesativarCliente(Cliente cliente)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Cliente
                               SET Ativo={0}
                                WHERE Id={1}",
                                cliente.Ativo,
                                cliente.Id);

            return ExecuteNonQuery(sql);
        }
    }
}
