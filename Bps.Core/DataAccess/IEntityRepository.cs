using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bps.Core.Entities;

namespace Bps.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T,bool>> filter=null);
        //List<T> GetList(Expression<Func<T, bool>> filter = null, Expression<Func<T, bool>> order = null,
        //    string dir = "asc");
        T Get(Expression<Func<T, bool>> filter);

       
        T Add(T entity);
        T Update(T entity);
        bool MultiUpdate(List<T> entities);
        bool MultiAdd(List<T> entities);

        bool MultiDelete(List<T> entities);
        T Delete(T entity);
        List<TModel> GetListSqlQuery<TModel>(string strSql, params object[] Parameter);
        TModel GetSqlQuery<TModel>(string strSql, params object[] Parameter);
        T GetObjectSqlQuery<T>(string strSql, params object[] Parameter);
        void ExecuteSqlQuery(string strSql, params object[] Parameter);
        List<dynamic> GetSpecColumnsList(Expression<Func<T, dynamic>> columns, Expression<Func<T, bool>> filter = null);
    }
}