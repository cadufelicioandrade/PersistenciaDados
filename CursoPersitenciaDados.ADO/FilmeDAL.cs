using CursoPersitenciaDados.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.ADO
{
    public class FilmeDAL : BaseDAL
    {
        public List<Filme> GetFilmes()
        {
            List<Filme> filmes = new List<Filme>();
            StringBuilder sb = new StringBuilder();
            sb.Append(@" SELECT 
                                F.Id,
	                            F.Titulo,
	                            F.Duracao,
	                            F.Descricao,
	                            F.DtInclusao,
	                            F.AnaLancamento,
	                            F.Disponivel,
	                            F.GeneroId,
	                            F.ProdutoraId,
	                            G.NomeGenero,
	                            P.NomeProdutora
                            FROM Filme F 
                            JOIN Genero G ON F.GeneroId = G.Id
                            JOIN Produtora P ON F.ProdutoraId = P.Id;");

            DataTable dt = Consultar(sb);

            foreach (DataRow row in dt.Rows)
            {
                Filme filme = new Filme();
                filme.Id = Convert.ToInt32(row["Id"]);
                filme.Titulo = row["Titulo"].ToString();
                filme.Duracao = Convert.ToInt32(row["Duracao"]);
                filme.Descricao = row["Descricao"].ToString();
                filme.DtInclusao = Convert.ToDateTime(row["DtInclusao"]);
                filme.AnoLancamento = Convert.ToInt32(row["AnoLancamento"]);
                filme.Disponivel = Convert.ToBoolean(row["Disponivel"]);
                filme.GeneroId = Convert.ToInt32(row["GeneroId"]);
                filme.ProdutoraId = Convert.ToInt32(row["ProdutoraId"]);

                filme.Genero.Id = Convert.ToInt32(row["GeneroId"]);
                filme.Genero.NomeGenero = row["NomeGenero"].ToString();
                
                filme.Produtora.Id = Convert.ToInt32(row["ProdutoraId"]);
                filme.Produtora.NomeProdutora = row["NomeProdutora"].ToString();

                List<Ator> ators = new AtorDAL().GetByFilmeId(filme.Id);

                foreach (var ator in ators)
                {
                    filme.Atores = new List<Ator>();
                    filme.Atores.Add(ator);
                }

                filmes.Add(filme);
            }

            return filmes;
        }

        public int InserirFilme(Filme filme)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"");

            return ExecuteScalar(sb);
        }
        
    } 
    
}
