using System.Collections.Generic;

namespace VendasAPI.Models.Entities
{
    public class Unidade
    {
        public virtual long id { get; set; }
        public virtual string descricao { get; set; }
        public virtual string simbolo { get; set; }
        public virtual IList<Produto> produtos { get; set; }
    }
}