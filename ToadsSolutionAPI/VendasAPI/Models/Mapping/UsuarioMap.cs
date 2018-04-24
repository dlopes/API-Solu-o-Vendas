using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendasAPI.Models.Entities;

namespace VendasAPI.Models.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Not.Nullable();
                //.Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.nome).Not.Nullable().Length(60);
            Map(x => x.email).Not.Nullable().Length(60);
            Map(x => x.senha).Not.Nullable().Length(60);
            HasManyToMany<Grupo>(x => x.grupos)
                .Table("usuario_grupo")
                .ParentKeyColumn("usuario_id")
                .ChildKeyColumn("grupo_id")
                .Not.LazyLoad()
                .Cascade.AllDeleteOrphan();//ou .Cascade.SaveOrUpdate();
            References(x => x.funcionario).Column("funcionario_id");//Many-to-one
            //References(x => x.Cliente).Cascade.Merge().LazyLoad().Column("codigocliente");
        }
    }
    
}