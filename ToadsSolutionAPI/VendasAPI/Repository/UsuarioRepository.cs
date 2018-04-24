using VendasAPI.Models.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using VendasAPI.Dao;
using NHibernate.Criterion;

namespace VendasAPI.Repository
{
    public class UsuarioRepository : Repository<Usuario>
    {

        public bool ValidarLogin(string login)
        {
            using (ISession session = NHibernateHelper.openSession()) 
            {
                return (from e in session.Query<Usuario>() where e.email.Equals(login) select e).Count() > 0;
            }
        }
        public bool ValidarAcesso(string login, string senha)
        {
            using (ISession session = NHibernateHelper.openSession()) 
            {
                return (from e in session.Query<Usuario>() where e.email.Equals(login) && e.senha.Equals(senha) select e).Count() > 0;
            }
        }

        public int UsuariosCout(long id)
        {
            int count = 0;

            using (ISession session = NHibernateHelper.openSession())
            {
                var criteria = session.CreateCriteria(typeof(Usuario))
                       .Add(Restrictions.Eq("id", id))
                       .SetProjection(Projections.CountDistinct("id"));
                count = (int)criteria.UniqueResult();
            }

            return count;
        }
    }
}