using NHibernate;
using System;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using VendasAPI.Dao;

namespace VendasAPI.Repository
{
    public class Repository<T> : ISolutionRepository<T> where T : class
    {
        public void Inserir(T entidade)
        {
            using (ISession session = NHibernateHelper.openSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir Cliente : " + ex.Message);

                    }
                }
            }

        }

        public void Alterar(T entidade)
        {
            using (ISession session = NHibernateHelper.openSession())

            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Alterar Cliente : " + ex.Message);
                    }

                }

            }

        }

        public void Excluir(T entidade)
        {
            using (ISession session = NHibernateHelper.openSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao Excluir Cliente : " + ex.Message);
                    }

                }

            }

        }

        public T RetornarPorId(long Id)
        {
            using (ISession session = NHibernateHelper.openSession())
            {
                return session.Get<T>(Id);
            }
        }

        public IList<T> Consultar()
        {
            using (ISession session = NHibernateHelper.openSession())
            {
                return (from c in session.Query<T>() select c).ToList();
            }
        }

        public int RetornarCout(long id)
        {
            int count = 0;

            using (ISession session = NHibernateHelper.openSession())
            {
                var teste = session.Get<T>(id);

                if (teste != null)
                    return 1;

            }

            return count;
        }
    }
}