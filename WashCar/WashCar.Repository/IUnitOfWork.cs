using Microsoft.EntityFrameworkCore;
using System;
using WashCar.Entities.Models;

namespace WashCar.Repository
{
    public interface IUnitOfWork : IDisposable
    { 
        //CarWashDB_V1Context Context { get; }
        void Commit();
    }
}
