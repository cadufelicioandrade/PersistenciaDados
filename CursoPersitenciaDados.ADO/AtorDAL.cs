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

        public List<Ator> GetAll()
        {
            List<Ator> ators = new List<Ator>();

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT Id,
	                                NomeAtor,
	                                SobreNome,
	                                DtNascimento
                                FROM Ator");

            DataTable dt = Consultar(sql);

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

        public List<Ator> GetById(int id)
        {
            List<Ator> ators = new List<Ator>();

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT Id,
	                                NomeAtor,
	                                SobreNome,
	                                DtNascimento
                                FROM Ator
                                WHERE Id={0}", id);

            DataTable dt = Consultar(sql);

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

        public int InserirAtor(Ator ator)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Ator (NomeAtor,SobreNome, DtNascimento)
                            VALUES ('{0}','{1}',{2})",
                            ator.NomeAtor, ator.Sobrenome, ator.DtNascimento);

            return ExecuteScalar(sql);
        }

        public bool UpdateAtor(Ator ator)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Ator
                            SET NomeAtor={0},
                                SobreNome={1},
                                DtNascimento={2}
                            WHERE Id={3}",
                            ator.NomeAtor,
                            ator.Sobrenome,
                            ator.DtNascimento,
                            ator.Id);

            return ExecuteNonQuery(sql);
        }
    }
}
