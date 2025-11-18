using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Bps.Core.Entities;

namespace Bps.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

    
           



        //public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> order = null, string dir = "asc")
        //{
        //    using (var context = new TContext())
        //    {
        //        if (filter != null)
        //        {
        //            if (order == null) return context.Set<TEntity>().Where(filter).ToList();
        //            if (dir == "asc") return context.Set<TEntity>().Where(filter).OrderBy(order).ToList();
        //            if (dir == "desc") return context.Set<TEntity>().Where(filter).OrderByDescending(order).ToList();
        //        }

        //        if (order == null) return context.Set<TEntity>().ToList();
        //        if (dir == "asc") return context.Set<TEntity>().OrderBy(order).ToList();
        //        if (dir == "desc") return context.Set<TEntity>().OrderByDescending(order).ToList();

        //        return context.Set<TEntity>().ToList();
        //    }
        //}

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public bool MultiAdd(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool MultiUpdate(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
        }

        public bool MultiDelete(List<TEntity> entities)
        {
            using (var context = new TContext())
            {
                foreach (var entity in entities)
                {
                    var deletedEntity = context.Entry(entity);
                    deletedEntity.State = EntityState.Deleted;
                }
                context.SaveChanges();
                return true;
            }
        }

        public TEntity Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
                return entity;
            }
        }

        public List<TModel> GetListSqlQuery<TModel>(string strSql, params object[] Parameter)
        {
            using (var context = new TContext())
            {
                return context.Database.SqlQuery<TModel>(strSql, Parameter).ToList();
            }
        }

        public TModel GetSqlQuery<TModel>(string strSql, params object[] Parameter)
        {
            using (var context = new TContext())
            {
                return context.Database.SqlQuery<TModel>(strSql, Parameter).FirstOrDefault();
            }
        }

        public T GetObjectSqlQuery<T>(string strSql, params object[] Parameter)
        {
            using (var context = new TContext())
            {
                return context.Database.SqlQuery<T>(strSql, Parameter).FirstOrDefault();
            }
        }

        public void ExecuteSqlQuery(string strSql, params object[] Parameter)
        {
            using (var context = new TContext())
            {
                context.Database.ExecuteSqlCommand(strSql, Parameter);
            }
        }

        public List<dynamic> GetSpecColumnsList(Expression<Func<TEntity, dynamic>> columns,
            Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().Select(columns).ToList()
                    : context.Set<TEntity>().Where(filter).Select(columns).ToList();
            }
        }

    }
}
