using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class EnderecoEntrega
    {
        public virtual string logradouro { get; set; }
        public virtual string numero { get; set; }
        public virtual string complemento { get; set; }
        public virtual string cidade { get; set; }
        public virtual string uf { get; set; }
        public virtual string cep { get; set; }
    }
}