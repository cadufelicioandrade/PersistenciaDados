using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Endereco : Base
    {
        public Endereco()
        {

        }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int Numero { get; set; }

        public Cliente Cliente { get; set; }
        public int? ClienteId { get; set; }

        public Funcionario Funcionario { get; set; }
        public int? FuncionarioId { get; set; }


        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }

    }
}
