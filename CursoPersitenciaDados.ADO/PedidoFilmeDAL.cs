using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class PedidoFilmeDAL : BaseDAL
    {
        public PedidoFilmeDAL()
        {

        }

        public List<PedidoFilme> GetAll()
        {
            var pedidoFilmes = new List<PedidoFilme>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT Id, 
                                ValorUnidade, 
                                PedidoId, 
                                FilmeId
                            FROM PedidoFilme");

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var pedidoFilme = new PedidoFilme();
                pedidoFilme.Id = Convert.ToInt32(row["Id"]);
                pedidoFilme.ValorUnidade = Convert.ToDouble(row["ValorUnidade"]);
                pedidoFilme.PedidoId = Convert.ToInt32(row["PedidoId"]);
                pedidoFilme.FilmeId = Convert.ToInt32(row["FilmeId"]);

                pedidoFilmes.Add(pedidoFilme);
            }

            return pedidoFilmes;
        }

        public List<PedidoFilme> GetByPedidoId(int pedidoId)
        {
            var pedidoFilmes = new List<PedidoFilme>();
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"SELECT Id, 
                                    ValorUnidade, 
                                    FilmeId,
                                FROM PedidoFilme
                                WHERE PedidoId={0}", pedidoId);

            DataTable dt = Consultar(sql);

            foreach (DataRow row in dt.Rows)
            {
                var pedidoFilme = new PedidoFilme();
                pedidoFilme.Id = Convert.ToInt32(row["Id"]);
                pedidoFilme.ValorUnidade = Convert.ToDouble(row["ValorUnidade"]);
                pedidoFilme.PedidoId = Convert.ToInt32(row["PedidoId"]);
                pedidoFilme.FilmeId = Convert.ToInt32(row["FilmeId"]);

                pedidoFilmes.Add(pedidoFilme);
            }

            return pedidoFilmes;
        }

        public int InserirPedidoFilme(List<PedidoFilme> pedidoFilmes)
        {
            //Passar o FilmeId e criar o Pedido antes para passar o PedidoId 
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO PedidoFilme (ValorUnidade, PedidoId, FilmeId) VALUES");

            int posicao = 0;

            for (int i = 0; i < pedidoFilmes.Count; i++)
            {
                int count = posicao + 2;

                sql.Append("(");

                while(posicao <= count)
                {
                    sql.Append(@"{" + posicao.ToString() + "}");
                    posicao++;
                    if (posicao < count) sql.Append(",");
                }
                
                sql.Append(")");

                if(i < pedidoFilmes.Count)
                    sql.Append(",");
            }


            return ExecuteScalar(sql);
        }
    }
}
