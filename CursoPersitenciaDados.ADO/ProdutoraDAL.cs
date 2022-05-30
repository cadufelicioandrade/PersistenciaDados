using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class ProdutoraDAL : BaseDAL
    {
        public ProdutoraDAL()
        {

        }

        public List<Produtora> GetAll()
        {
            List<Produtora> produtoras = new List<Produtora>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT Id, NomeProdutora FROM Produtora");

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                Produtora produtora = new Produtora();
                produtora.Id = Convert.ToInt32(row["Id"]);
                produtora.NomeProdutora = row["NomeProdutora"].ToString();
                produtoras.Add(produtora);
            }

            return produtoras;
        }

        public Produtora GetById(int id)
        {
            Produtora produtora = new Produtora();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT Id, NomeProdutora FROM Produtora WHERE Id={0}", id);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                produtora.Id = Convert.ToInt32(row["Id"]);
                produtora.NomeProdutora = row["NomeProdutora"].ToString();
            }

            return produtora;
        }

        public int InserirProdutora(Produtora produtora)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO Produtora (NomeProdutora) VALUES('{0}')", produtora.NomeProdutora);
            return ExecuteScalar(sql);
        }

        public bool UpdateProdutora(Produtora produtora)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"UPDATE Produtora SET NomeProdutora='{0}' WHERE Id={1}",
                            produtora.NomeProdutora, produtora.Id);

            return ExecuteNonQuery(sql);
        }

    }
}
