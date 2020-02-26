using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WashCar.Services;
using System.Collections.Generic;
using WashCar.Entities.Models;

namespace WashCar.Functions
{
    public class Function2
    {
        private ITest _test;
        public Function2(ITest test)
        {
            _test = test;
        }
        [FunctionName("Function2")]
        public List<Order> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            List<Order> rs = new List<Order>();

            try
            {
                rs = _test.GetAll();
            }
            catch (Exception ex)
            {
                //rs = ex.Message;
            }
            return rs;
        }
        [FunctionName("FunGetName")]
        public string FunGetName(
           [HttpTrigger(AuthorizationLevel.Admin, "get", "post", Route = null)] HttpRequest req,
           ILogger log)
        {
           
            return "hung 123";
        }
        [FunctionName("FunGetName2")]
        
        public string GetN([HttpTrigger(AuthorizationLevel.Admin, "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            return "222";
        }
    }
}
