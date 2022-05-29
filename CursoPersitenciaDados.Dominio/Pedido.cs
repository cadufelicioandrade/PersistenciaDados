using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Pedido
    {
        public Pedido()
        {

        }

        public int Id { get; set; }
        public DateTime DtPedido { get; set; }
        public string NumeroPedido { get; set; }
        public int QtdTodal { get; set; }
        public decimal ValorPedido { get; set; }
        
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }

    }
}
