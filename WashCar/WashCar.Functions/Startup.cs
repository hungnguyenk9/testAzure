using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WashCar.Entities.Models;
using WashCar.Repository;
using WashCar.Repository.Test;
using WashCar.Services;

[assembly: WebJobsStartup(typeof(WashCar.Functions.Startup))]
namespace WashCar.Functions
{
    public class Startup : IWebJobsStartup
    {


        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
           // builder.Services.AddTransient<IBaseRepository<dynamic>, BaseRepository<dynamic>>();
            builder.Services.AddTransient<ITestRepository, TestRepository>();
            builder.Services.AddTransient<ITest, Test>();
            
        }
    }
}
