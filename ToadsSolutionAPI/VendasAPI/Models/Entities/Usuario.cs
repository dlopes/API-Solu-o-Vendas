using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendasAPI.Models.Entities
{
    public class Usuario
    {
        public virtual long id { get; set; }
        public virtual string nome { get; set; }
        public virtual string email { get; set; }
        public virtual string senha { get; set; }
        public virtual IList<Grupo> grupos { get; set; }
        [JsonIgnore]
        public virtual Funcionario funcionario { get; set; }
    }
}