using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using WashCar.Entities.Models;

namespace WashCar.Repository
{
    public class BaseRepository<T>  where T : class
    {
        //private IUnitOfWork _unitOfWork;
        public CarWashDB_V1Context Context = new CarWashDB_V1Context();
        //public BaseRepository(IUnitOfWork unitOfWork, CarWashDB_V1Context _context)
        //{
        //    _unitOfWork = unitOfWork;
        //    Context = _context;
        //}

        //public BaseRepository(CarWashDB_V1Context context)
        //{
        //    Context = context;
        //}

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            T existing = Context.Set<T>().Find(entity);
            if (existing != null) Context.Set<T>().Remove(existing);
        }

        public IEnumerable<T> Get()
        {
            return Context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Set<T>().Attach(entity);
        }

        public List<T> ExcuteSqlQuery(string sqlQuery, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (commandType == CommandType.Text)
            {
                return SqlQuery(sqlQuery, parameters);
            }
            else if (commandType == CommandType.StoredProcedure)
            {
                return StoredProcedure(sqlQuery, parameters);
            }
            return null;
        }

        public void ExecuteNonQuery(string commandText, CommandType CommandType, SqlParameter[] parameters = null)
        {
            if (!Context.Database.CanConnect())
            {
                Context.Database.OpenConnection();
            }
            var command = Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            command.ExecuteNonQuery();
        }

        public List<T> ExecuteReader(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            if (!Context.Database.CanConnect())
            {
                Context.Database.OpenConnection();
            }
            var command = Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            using (var reader = command.ExecuteReader())
            {
                //var mapper = new DataReaderMapper<T>();
                return MapToList(reader);
            }
        }

        private List<T> SqlQuery(string sqlQuery, SqlParameter[] parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var parameterNames = new string[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterNames[i] = parameters[i].ParameterName;
                }
                var result = Context.Set<T>().FromSqlRaw<T>(string.Format("{0}", sqlQuery, string.Join(",", parameterNames), parameters));
                return result.ToList();
            }
            else
            {
                var result = Context.Set<T>().FromSqlRaw<T>(sqlQuery);
                return result.ToList();
            }
        }

        private List<T> StoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var parameterNames = new string[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterNames[i] = parameters[i].ParameterName;
                }
                var result = Context.Set<T>().FromSqlRaw<T>(string.Format("EXEC {0} {1}", storedProcedureName, string.Join(",", parameterNames), parameters));
                return result.ToList();
            }
            else
            {
                var result = Context.Set<T>().FromSqlRaw<T>(string.Format("EXEC {0}", storedProcedureName));
                return result.ToList();
            }
        }

        public List<T> MapToList(DbDataReader dr)
        {
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);
                var entities = new List<T>();
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                T newObject = default(T);
                while (dr.Read())
                {
                    newObject = Activator.CreateInstance<T>();
                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = propDict[dr.GetName(index).ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                info.SetValue(newObject, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                    entities.Add(newObject);
                }
                return entities;
            }
            return null;
        }
    }
}
