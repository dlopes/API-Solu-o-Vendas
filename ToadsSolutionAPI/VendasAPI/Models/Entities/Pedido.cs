using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Pedido
    {
        public virtual long id { get; set; }
        public virtual DateTime dataCriacao { get; set; }
        public virtual string observacao { get; set; }
        public virtual DateTime dataEntrega { get; set; }
        public virtual decimal valorFrete { get; set; }
        public virtual decimal valorDesconto { get; set; }
        public virtual decimal valorTotal { get; set; }
        public virtual StatusPedido status { get; set; }
        public virtual FormaPagamento formaPagamento { get; set; }
        public virtual Usuario vendedor { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual EnderecoEntrega enderecoEntrega { get; set; }
        public virtual IList<ItemPedido> itens { get; set; }
    }
}