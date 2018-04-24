using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Grupo
    {
        public virtual long id { get; set; }
        public virtual string nome { get; set; }
        public virtual string descricao { get; set; }
    }
}