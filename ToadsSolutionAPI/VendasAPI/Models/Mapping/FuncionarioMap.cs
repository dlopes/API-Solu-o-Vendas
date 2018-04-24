using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendasAPI.Models.Entities;

namespace VendasAPI.Models.Mapping
{
    public class FuncionarioMap : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            Id(x => x.id)
                .GeneratedBy.Identity()
                .UnsavedValue(0)
                .Not.Nullable();
                //.Access.CamelCaseField(Prefix.Underscore);

            Map(x => x.nome).Not.Nullable().Length(200);
            Map(x => x.cpf).Not.Nullable().Length(14);
            Map(x => x.email).Not.Nullable().Length(60);
            Map(x => x.rg).Not.Nullable().Length(20);
            Map(x => x.orgaorg).Length(60);
            Map(x => x.foto);
            Map(x => x.cargo).Not.Nullable().Length(60);
            Map(x => x.celular).Length(12).Column("celular");
            Map(x => x.telefone).Length(12).Column("tel_fixo");
            Map(x => x.comissao);
            Map(x => x.salario).Not.Nullable();
            Map(x => x.posse);
            Map(x => x.auditoria).Length(80);
            HasMany<Usuario>(x => x.usuarios).KeyColumn("funcionario_id");
            HasManyToMany<Departamento>(x => x.departamentos)
                .Table("funcionario_departamento")
                .ParentKeyColumn("funcionario_id")
                .ChildKeyColumn("departamento_id")
                .Not.LazyLoad()
                .Cascade.AllDeleteOrphan();//ou .Cascade.SaveOrUpdate();
            //HasMany(x => x.Telefone).Cascade.Merge().LazyLoad().KeyColumn("codigocliente");
        }
    }
}