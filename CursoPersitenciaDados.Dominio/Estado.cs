using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Estado
    {
        public Estado()
        {
        }

        public int Id { get; set; }
        public string NomeEstado { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }

        public List<Cidade> Cidades { get; set; }

    }
}
