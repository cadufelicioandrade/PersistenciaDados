using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Pedido : Base
    {
        public Pedido()
        {

        }

        public DateTime DtPedido { get; set; }
        public int QtdFilme { get; set; }
        public double ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

    }
}
