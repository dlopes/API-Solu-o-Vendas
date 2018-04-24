using System;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using VendasAPI.Models.Mapping;

namespace VendasAPI.Dao
{
    public class NHibernateHelper
    {
        private static ISessionFactory session;
        private  const String HOST = "localhost";
        private  const String USER = "root";
        private  const String PASSWORD = "mysql";
        private  const String DB = "ToadsSolution";

        /** create a connection with database */
        private static ISessionFactory createConnection()
        {

            if (session != null)
            return session;

            //database configs
            FluentConfiguration _config = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(
                x => x.Server(HOST).
                Username(USER).
                Password(PASSWORD).
                Database(DB)
            ))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FuncionarioMap>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<GrupoMap>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));

            session = _config.BuildSessionFactory();
            return session;
        }


        /** open a session to make transactions */
        public static ISession openSession()
        {
            return createConnection().OpenSession();
        }



    }
}