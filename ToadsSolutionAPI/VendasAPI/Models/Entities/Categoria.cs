using System.Collections.Generic;

namespace VendasAPI.Models.Entities
{
    public class Categoria
    {
        public virtual long id { get; set; }
        public virtual string descricao { get; set; }
        public virtual Categoria categoriaPai { get; set; }
        public virtual IList<Categoria> subcategorias { get; set; }

    }
}