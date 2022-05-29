using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class AtorDAL : BaseDAL
    {
        public AtorDAL()
        {

        }

        public List<Ator> GetByFilmeId(int filmeId)
        {
            List<Ator> ators = new List<Ator>();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT 
	                                ID,
	                                NomeAtor,
	                                SobreNome,
	                                DtNascimento
                                FROM Ator
                                WHERE FilmeId = @FilmeId;", filmeId);

            DataTable dt = Consultar(sb);

            foreach (DataRow row in dt.Rows)
            {
                Ator ator = new Ator();

                ator.Id = Convert.ToInt32(row["ID"]);
                ator.NomeAtor = row["NomeAtor"].ToString();
                ator.Sobrenome = row["SobreNome"].ToString();
                ator.DtNascimento = Convert.ToDateTime(row["DtNascimento"]);

                ators.Add(ator);
            }

            return ators;
        }
    }
}
