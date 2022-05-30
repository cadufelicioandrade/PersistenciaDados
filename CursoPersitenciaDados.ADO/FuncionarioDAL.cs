using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class FuncionarioDAL : BaseDAL
    {
        public FuncionarioDAL()
        {

        }

        public List<Funcionario> GetFuncionario(int? id=null)
        {
            List<Funcionario> list = new List<Funcionario>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Id,
		                        NomeFuncionario,
		                        SobreNome,
		                        CPF,
		                        RG,
		                        TelFixo,
		                        Email,
		                        DtNascimento,
		                        Ativo
	                        FROM Funcionario ");

            if (id != null)
                sql.AppendFormat(@"WHERE Id = {0}", id.Value);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var funcionario = new Funcionario();
                funcionario.Id = Convert.ToInt32(row["Id"]);
                funcionario.NomeFuncionario = row["NomeFuncionario"].ToString();
                funcionario.SobreNome = row["SobreNome"].ToString();
                funcionario.CPF = row["CPF"].ToString();
                funcionario.RG = row["RG"].ToString();
                funcionario.TelFixo = row["TelFixo"].ToString();
                funcionario.Email = row["Email"].ToString();
                funcionario.DtNascimento = Convert.ToDateTime(row["DtNascimento"]);
                funcionario.Ativo = Convert.ToBoolean(row["Ativo"]);

                funcionario.Endereco = new Endereco();
                funcionario.Endereco = new EnderecoDAL().GetEndereco(funcionarioId: funcionario.Id);

                list.Add(funcionario);
            }

            return list;
        }

        public int InserirFuncionario(Funcionario funcionario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Funcionario
                                (NomeFuncionario, SobreNome, CPF, RG, TelFixo, Email, DtNascimento)
                                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6}",
                                funcionario.NomeFuncionario,
                                funcionario.SobreNome,
                                funcionario.CPF,
                                funcionario.RG,
                                funcionario.TelFixo,
                                funcionario.Email,
                                funcionario.DtNascimento);

            return ExecuteScalar(sql);
        }

        public bool UpdateFuncionario(Funcionario funcionario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Funcionario
                               SET NomeFuncionario='{0}',
                                    SobreNome='{1}',
                                    CPF='{2}',
                                    RG='{3}',
                                    TelFixo='{4}',
                                    Email='{5}',
                                    DtNascimento={6}
                                WHERE Id={7}",
                                funcionario.NomeFuncionario,
                                funcionario.SobreNome,
                                funcionario.CPF,
                                funcionario.RG,
                                funcionario.TelFixo,
                                funcionario.Email,
                                funcionario.DtNascimento,
                                funcionario.Id);

            return ExecuteNonQuery(sql);
        }

        public bool DesativarFuncionario(Funcionario funcionario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Funcionario
                               SET Ativo={0}
                                WHERE Id={1}",
                                funcionario.Ativo,
                                funcionario.Id);

            return ExecuteNonQuery(sql);
        }
    }
}
