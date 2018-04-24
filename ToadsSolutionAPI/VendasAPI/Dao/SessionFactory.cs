using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using VendasAPI.Models.Mapping;

namespace VendasAPI.Dao
{
    public class SessionFactory
    {

        private static string ConnectionString = "Server=localhost; Port=5432; User Id=postgres; Password=********; Database=cadastro";

        private static ISessionFactory session;

        public static ISessionFactory CriarSession()

        {

            if (session != null)

                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);

            var configMap = Fluently.Configure().Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<UsuarioMap>());

            session = configMap.BuildSessionFactory();

            return session;

        }

        public static ISession AbrirSession()

        {

            return CriarSession().OpenSession();

        }

    }
}