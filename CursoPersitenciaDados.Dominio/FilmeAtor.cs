using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class FilmeAtor : Base
    {
        public FilmeAtor()
        {

        }

        public int AtorId { get; set; }
        public Ator Ator { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
    }
}
