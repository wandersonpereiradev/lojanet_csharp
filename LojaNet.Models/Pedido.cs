﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }
        public List<Item> Items { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        
        public class Item
        {
            public int Ordem { get; set; }
            public Produto Produto { get; set; }
            public int Quantidade { get; set; }
            public Decimal Preço { get; set; }
        }
    }
}
