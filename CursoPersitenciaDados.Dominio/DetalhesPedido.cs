using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class DetalhesPedido
    {
        public DetalhesPedido()
        {

        }

        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string NumeroPedido { get; set; }
        public Locacao Locacao { get; set; }
    }
}
