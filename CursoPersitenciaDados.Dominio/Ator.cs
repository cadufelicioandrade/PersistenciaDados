using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Ator
    {
        public Ator()
        {

        }

        public int Id { get; set; }
        public string NomeAtor { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DtNascimento { get; set; }
        public List<Filme> Filmes { get; set; }
        public int FilmeId { get; set; }

    }
}
