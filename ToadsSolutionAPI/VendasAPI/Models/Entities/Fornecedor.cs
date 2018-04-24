using System;
using System.Collections.Generic;

namespace VendasAPI.Models.Entities
{
    public class Fornecedor
    {
        public virtual long id { get; set; }
        public virtual string nome { get; set; }
        public virtual string email { get; set; }
        public virtual string fone { get; set; }
        public virtual string celular { get; set; }
        public virtual string documentoReceitaFederal { get; set; }
        public virtual string obs { get; set; }
        public virtual string rg { get; set; }
        public virtual string orgaorg { get; set; }
        public virtual DateTime desde { get; set; }
        public virtual string insest { get; set; }
        public virtual string fax { get; set; }
        public virtual string contato { get; set; }
        public virtual string auditoria { get; set; }
        public virtual IList<Produto> produtos { get; set; }
        public virtual TipoPessoa tipo { get; set; }
        public virtual IList<EnderecoFornecedor> enderecos { get; set; }
       //public virtual List<CNF> cnfs = new ArrayList<>(){ get; set; }
    }
}