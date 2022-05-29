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
        public List<Filme> GetFilmesDisponiveis()
        {
            List<Filme> filmes = new List<Filme>();
            StringBuilder sb = new StringBuilder();
            sb.Append(@" SELECT F.Id,
	                            F.Titulo,
	                            F.Duracao,
	                            F.Descricao,
	                            F.DtInclusao,
	                            F.AnaLancamento,
	                            F.GeneroId,
	                            F.ProdutoraId,
                                F.ValorLocacao,
	                            G.NomeGenero,
	                            P.NomeProdutora
                            FROM Filme F 
                            JOIN Genero G ON F.GeneroId = G.Id
                            JOIN Produtora P ON F.ProdutoraId = P.Id
                            WHERE F.Ativo = 1 AND F.Disponivel = 1");

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
                
                filme.Ator = new List<Ator>(new FilmeAtorDAL().GetAtorByFilmeId(filme.Id));

                filmes.Add(filme);
            }

            return filmes;
        }

        public int InserirFilme(Filme filme)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"INSERT INTO Filme
                            (Titulo, Duracao, Descricao, DtInclusao, AnoLancamento, Disponivel, GeneroId, ProdutoraId, ValorLocacao)
                            VALUES
                            ('{0}', {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8})",
                            filme.Titulo, 
                            filme.Duracao, 
                            filme.Descricao,
                            filme.DtInclusao,
                            filme.AnoLancamento,
                            filme.Disponivel,
                            filme.GeneroId,
                            filme.ProdutoraId,
                            filme.ValorLocacao);

            return ExecuteScalar(sb);
        }

        public bool UpdateFilme(Filme filme)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"UPDATE Filme
                            SET Titulo='{0}', 
	                            Duracao={1}, 
	                            Descricao='{2}', 
	                            DtInclusao={3}, 
	                            AnoLancamento={4}, 
	                            Disponivel={5}, 
	                            GeneroId={6}, 
	                            ProdutoraId={7}, 
	                            ValorLocacao={8}
                            WHERE Id = {9}",
                            filme.Titulo,
                            filme.Duracao,
                            filme.Descricao,
                            filme.DtInclusao,
                            filme.AnoLancamento,
                            filme.Disponivel,
                            filme.GeneroId,
                            filme.ProdutoraId,
                            filme.ValorLocacao,
                            filme.Id);

            return ExecuteNonQuery(sb);
        }

        public bool DeletiFilme(Filme filme)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"UPDATE Filme
                            SET Ativo = 0
                            WHERE Id = {0}",
                            filme.Id);

            return ExecuteNonQuery(sb);
        }

    } 
    
}
