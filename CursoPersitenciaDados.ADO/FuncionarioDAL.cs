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
                sql.AppendFormat(@"WHERE Id = {0}", id);

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
                
                list.Add(funcionario);
            }

            return list;
        }
    }
}
