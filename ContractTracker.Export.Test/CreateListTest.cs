using NUnit.Framework;
using ContractTracker.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContractTracker.Export.Test
{
    //https://stackoverflow.com/questions/71532313/asp-net-core-6-0-web-api-unit-test-using-nunit
    //public class SUTFactory : WebApplicationFactory<Startup>
    //{
        //protected override IHostBuilder CreateHostBuilder()
      //  {
          //  return Program.CreateHostBuilder(null);
        //}
    //}
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //todo - how do you set up host build and envoke start up>? 
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}