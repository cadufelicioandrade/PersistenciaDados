﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoPersitenciaDados.Dominio
{
    public class Locacao
    {
        public Locacao()
        {

        }

        public int Id { get; set; }
        public decimal Preco { get; set; }
        
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }

        public DetalhesPedido DetalhesPedido { get; set; }
        public int DetalhesPedidoId { get; set; }

    }
}
