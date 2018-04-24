using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Produto
    {
        public virtual long id { get; set; }
        public virtual string nome { get; set; }
        public virtual string sku { get; set; }
        public virtual decimal valorUnitario { get; set; }
        public virtual decimal valorCompra { get; set; }
        public virtual int quantidadeEstoque { get; set; }
        public virtual Categoria categoria { get; set; }
        public virtual int critico { get; set; }
        public virtual string auditoria { get; set; }
        public virtual Unidade unidade { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
    }
}