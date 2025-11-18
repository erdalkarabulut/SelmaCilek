using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bps.Core.Entities;
using NHibernate.Linq;

namespace Bps.Core.DataAccess.NHihabernate
{
    public class NhEntityRepositoryBase<TEntity>:IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
    {
        private NHibernateHelper _nHibernateHelper;

        public NhEntityRepositoryBase(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var session=_nHibernateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public bool MultiUpdate(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public bool MultiAdd(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public bool MultiDelete(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public TEntity Delete(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Delete(entity);
                return entity;
            }
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return filter == null
                    ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }

        public List<TModel> GetListSqlQuery<TModel>(string strSql, params object[] Parameter)
        {
            throw new NotImplementedException();
        }

        public TModel GetSqlQuery<TModel>(string strSql, params object[] Parameter)
        {
            throw new NotImplementedException();
        }

        public T GetObjectSqlQuery<T>(string strSql, params object[] Parameter)
        {
            throw new NotImplementedException();
        }

        public void ExecuteSqlQuery(string strSql, params object[] Parameter)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> GetSpecColumnsList(Expression<Func<TEntity, dynamic>> columns, Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
