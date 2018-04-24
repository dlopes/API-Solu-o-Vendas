using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Departamento
    {
        public virtual long id { get; set; }
        public virtual string gerente { get; set; }
        public virtual string nome { get; set; }
        //public virtual IList<Funcionario> usuarios { get; set; }
    }
}