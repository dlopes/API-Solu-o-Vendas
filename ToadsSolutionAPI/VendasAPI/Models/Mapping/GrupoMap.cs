using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendasAPI.Models.Entities;

namespace VendasAPI.Models.Mapping
{
    public class GrupoMap : ClassMap<Grupo>
    {
        public GrupoMap()
        {
            Id(x => x.id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Not.Nullable();
                //.Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.nome).Not.Nullable().Length(40);
            Map(x => x.descricao).Not.Nullable().Length(80);
            
        }
    }
}