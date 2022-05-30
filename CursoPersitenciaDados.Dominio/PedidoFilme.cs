using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class PedidoFilme : Base
    {
        public PedidoFilme()
        {

        }

        public double ValorUnidade { get; set; }

        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }

        public Filme Filme { get; set; }
        public int FilmeId { get; set; }

    }
}
