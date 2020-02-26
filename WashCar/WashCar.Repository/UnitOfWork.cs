using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WashCar.Entities.Models;

namespace WashCar.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public CarWashDB_V1Context _context;

        public UnitOfWork (CarWashDB_V1Context context)
        {
            _context = context;
        }

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        //public IBaseRepository<T> Repository<T>() where T : class
        //{
        //    if (repositories.Keys.Contains(typeof(T)) == true)
        //    {
        //        return repositories[typeof(T)] as IBaseRepository<T>;
        //    }
        //    IBaseRepository<T> repository = new BaseRepository<T>(_context);
        //    repositories.Add(typeof(T), repository);
        //    return repository;

        //}
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();

        }
    }
}
