using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Ator : Base
    {
        public Ator()
        {

        }

        public string NomeAtor { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DtNascimento { get; set; }
        public List<FilmeAtor> FilmeAtor { get; set; }

    }
}
