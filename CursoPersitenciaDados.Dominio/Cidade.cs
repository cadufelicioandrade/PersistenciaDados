using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Cidade
    {
        public Cidade()
        {

        }

        public int Id { get; set; }
        public string NomeCidade { get; set; }

        public Endereco Endereco { get; set; }

        public Estado Estado { get; set; }
        public int EstadoId { get; set; }

    }
}
