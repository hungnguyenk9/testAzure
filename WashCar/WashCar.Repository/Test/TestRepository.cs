using System;
using System.Collections.Generic;
using System.Text;
using WashCar.Entities.Models;


namespace WashCar.Repository.Test
{
    public class TestRepository : BaseRepository<Order>, ITestRepository
    {

        public TestRepository()
        {
         
        }

        public List<Order> GetAll()
        {
            return ExcuteSqlQuery("SELECT TOP (1000) * FROM[dbo].[Order]",System.Data.CommandType.Text,null);
            //return _baseRepository.Get();

        }
    }
}
