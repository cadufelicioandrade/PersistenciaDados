using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class FilmeAtorDAL : BaseDAL
    {
        public FilmeAtorDAL()
        {

        }

        public List<Ator> GetAtorByFilmeId(int filmeId)
        {
            var atores = new List<Ator>();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT A.Id,
                                     A.NomeAtor,
                                     A.SobreNome,
                                     A.DtNascimento
                            FROM Ator A
                            JOIN FilmeAtor FA ON A.Id = FA.AtorId
                            WHERE FA.FilmeId = {0}", filmeId);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var ator = new Ator();
                ator.Id = Convert.ToInt32(row["Id"]);
                ator.NomeAtor = row["NomeAtor"].ToString();
                ator.Sobrenome = row["SobreNome"].ToString();
                ator.DtNascimento = Convert.ToDateTime(row["DtNascimento"]);
                atores.Add(ator);
            }

            return atores;
        }

    }
}
