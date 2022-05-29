using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Filme : Base
    {
        public Filme()
        {

        }

        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInclusao { get; set; }
        public int AnoLancamento { get; set; }
        public bool Disponivel { get; set; }
        public decimal ValorLocacao { get; set; }
        public bool Ativo { get; set; }

        public Genero Genero { get; set; }
        public int GeneroId { get; set; }

        public Produtora Produtora { get; set; }
        public int ProdutoraId { get; set; }

        public List<PedidoFilme> PedidoFilme { get; set; }
        public List<FilmeAtor> FilmeAtor { get; set; }
        public List<Ator> Ator { get; set; }

    }
}
