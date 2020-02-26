using System;
using System.Collections.Generic;
using System.Text;
using WashCar.Entities.Models;

namespace WashCar.Services
{
    public interface ITest
    {
        List<Order> GetAll();
    }
}
