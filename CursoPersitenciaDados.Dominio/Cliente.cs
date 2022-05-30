using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Cliente : Base
    {
        public Cliente()
        {

        }

        public string NomeCliente { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Celular { get; set; }
        public string TelFixo { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo { get; set; }
        public Endereco Endereco { get; set; }

    }
}
