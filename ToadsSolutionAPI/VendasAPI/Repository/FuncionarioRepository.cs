using NHibernate;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using VendasAPI.Dao;
using VendasAPI.Models.Entities;
using NHibernate.Criterion;

namespace VendasAPI.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>
    {
        public int funcionarioCout(long id)
        {
            int count = 0;

            using (ISession session = NHibernateHelper.openSession())
            {
                var criteria = session.CreateCriteria(typeof(Funcionario))
                       .Add(Restrictions.Eq("id", id))
                       .SetProjection(Projections.CountDistinct("id"));
                count = (int)criteria.UniqueResult();
            }

            return count;
        }
    }
}