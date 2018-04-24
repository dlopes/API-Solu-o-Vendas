using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendasAPI.Models.Entities;

namespace VendasAPI.Models.Mapping
{
    public class DepartamentoMap : ClassMap<Departamento>
    {
        public DepartamentoMap()
        {
            Id(x => x.id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Not.Nullable();
            //.Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.gerente).Not.Nullable().Length(100);
            Map(x => x.nome).Not.Nullable().Length(100);
        }
    }
}