using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class EnderecoDAL : BaseDAL
    {
        public EnderecoDAL()
        {

        }

        public Endereco GetEndereco(int? clienteId = null, int? funcionarioId = null)
        {
            Endereco endereco = new Endereco();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT E.Id,
									E.Logradouro,
									E.Bairro,
									E.CEP,
									E.Numero,
									C.NomeCidade,
									ES.NomeEstado,
									ES.UF
								FROM Endereco E 
								JOIN Cidade C ON E.CidadeId = C.Id 
								JOIN Estado ES ON C.EstadoId = ES.Id 
								WHERE ");


            if (funcionarioId != null)
                sql.AppendFormat(@"E.Funcionario = {0}", funcionarioId.Value);

            if (clienteId != null)
                sql.AppendFormat(@"E.CidadeId = {0}", clienteId.Value);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                endereco.Id = Convert.ToInt32(row["Id"]);
                endereco.Logradouro = row["Logradouro"].ToString();
                endereco.Bairro = row["Bairro"].ToString();
                endereco.CEP = row["CEP"].ToString();
                endereco.Numero = Convert.ToInt32(row["Numero"]);

                endereco.Cidade = new Cidade();
                endereco.Cidade.NomeCidade = row["NomeCidade"].ToString();

                endereco.Cidade.Estado = new Estado();
                endereco.Cidade.Estado.NomeEstado = row["NomeEstado"].ToString();
                endereco.Cidade.Estado.UF = row["UF"].ToString();
            }

            return endereco;
        }

        public int InserirEndereco(Endereco endereco)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"INSERT INTO Endereco 
								(Logradouro, Bairro, CEP, Numero, CidadeId, ");

            if (endereco.FuncionarioId != null)
                sql.Append("FuncionarioId)");

            if (endereco.ClienteId != null)
                sql.Append("ClienteId)");

            sql.Append("VALUES('{0}','{1}','{2}',{3},{4},");

            if (endereco.FuncionarioId != null)
                sql.AppendFormat("{5})", endereco.FuncionarioId.Value);

            if (endereco.ClienteId != null)
                sql.AppendFormat("{5})", endereco.ClienteId.Value);

            return ExecuteScalar(sql);
        }

        public bool UpdateEndereco(Endereco endereco)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"UPDATE Endereco
                            SET Logradouro='{0}',
                            Bairro='{1}',
                            CEP='{2}',
                            Numero='{3}',
                            CidadeId={4}
                        WHERE ");

            if (endereco.FuncionarioId != null)
                sql.AppendFormat(@"FuncionarioId={5}", endereco.FuncionarioId.Value);

            if (endereco.ClienteId != null)
                sql.AppendFormat(@"ClienteId={5}", endereco.ClienteId.Value);

            return ExecuteNonQuery(sql);
        }
    }
}
