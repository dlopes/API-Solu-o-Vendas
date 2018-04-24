using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class ItemPedido
    {
        public virtual long id { get; set; }
        public virtual int quantidade { get; set; }
        public virtual Decimal valorUnitario { get; set; }
        public virtual Produto produto { get; set; }
        public virtual Pedido pedido { get; set; }
    }
}