using System;
using System.Collections.Generic;
using System.Text;
using WashCar.Entities.Models;

namespace WashCar.Repository.Test
{
    public interface ITestRepository
    {
        List<Order> GetAll();
    }
}
