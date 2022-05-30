using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Cidade : Base
    {
        public Cidade()
        {

        }

        public string NomeCidade { get; set; }

        public string UF { get; set; }
        public string Pais { get; set; }

        public Endereco Endereco { get; set; }

        public Estado Estado { get; set; }
        public int EstadoId { get; set; }

    }
}
