using System;
using System.Collections.Generic;
using WashCar.Entities.Models;
using WashCar.Repository.Test;

namespace WashCar.Services
{
    public class Test : ITest
    {
        private ITestRepository _testRepository;
        public Test(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        public List<Order> GetAll()
        {
            List<Order> rs = new List<Order>();
            try
            {
                rs = _testRepository.GetAll();
            }
            catch (Exception ex)
            {
                //rs = ex.Message;
            }
            return rs;
        }
    }
}
