using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace WashCar.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        // 1. SqlQuery approach
        List<T> ExcuteSqlQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters = null);
        // 2. SqlCommand approach
        void ExecuteNonQuery(string commandText, CommandType command, SqlParameter[] parameters = null);
        List<T> ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null);

    }
}
