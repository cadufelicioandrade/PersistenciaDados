using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class CidadeDAL : BaseDAL
    {
        public CidadeDAL()
        {

        }

        public List<Cidade> GetCidade(int? cidadeId = null)
        {
            List<Cidade> cidades = new List<Cidade>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Id, NomeCidade, EstadoId FROM Cidade");

            if(cidadeId != null)
                sql.AppendFormat(@" WHERE Id={0}", cidadeId.Value);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                Cidade cidade = new Cidade();
                cidade.Id = Convert.ToInt32(row["ID"]);
                cidade.NomeCidade = row["NomeCidade"].ToString();
                cidades.Add(cidade);
            }

            return cidades;
        }

        public int InserirCidade(Cidade cidade)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Cidade (NomeCidade, EstadoId)
                                VALUES ('{0}',{1})",
                                cidade.NomeCidade,
                                cidade.EstadoId);

            return ExecuteScalar(sql);
        }

        public bool UpdateCidade(Cidade cidade)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Cidade 
                            SET NomeEstado='{0}',UF='{1}',Pais='{2}'
                            WHERE Id={3}",
                            cidade.NomeCidade,
                            cidade.UF,
                            cidade.Pais,
                            cidade.Id);

            return ExecuteNonQuery(sql);
        }
    }
}
