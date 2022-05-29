using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Filme
    {
        public Filme()
        {

        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInclusao { get; set; }
        public int AnoLancamento { get; set; }
        public bool Disponivel { get; set; }
        
        public Genero Genero { get; set; }
        public int GeneroId { get; set; }

        public Produtora Produtora { get; set; }
        public int ProdutoraId { get; set; }

        public List<Ator> Atores { get; set; }
        public int AtorId { get; set; }

        public List<Locacao> Locacao { get; set; }
    }
}
