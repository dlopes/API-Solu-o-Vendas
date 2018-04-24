using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Cliente
    {
        public virtual long id { get; set; }
        public virtual string nome { get; set; }
        public virtual string email { get; set; }
        public virtual string documentoReceitaFederal { get; set; }
        public virtual TipoPessoa tipo { get; set; }
        public virtual IList<EnderecoCliente> enderecoClientes { get; set; }

    }
}