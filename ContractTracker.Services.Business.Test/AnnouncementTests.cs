using NUnit.Framework;
using Microsoft.Extensions.Configuration; //Install this from NuGet: Microsoft.Extensions.Configuration and json
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContractTracker.Services.Business.Factories;
using ContractTracker.Services.Business.Models;

namespace ContractTracker.Services.Business.Test
{
    internal class AnnouncementTests
    {
        private string _connectionString = string.Empty;

        [SetUp]
        public void Setup()
        {
            IConfiguration _config2 = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); //Make sure to set 'copy always' on appsettings.json so it is in the Bin folder!

            _connectionString = _config2.GetConnectionString("ContractTrackerConnection"); //todo, set up for in memory db
        }

        [Test]
        public async Task CanGetAllUsers()
        {
            var uowFactory = new UowFactory(_connectionString);
            var allAnnoucenments = new List<AnnouncementResponseModel>();

            using (var uow = uowFactory.BuildUnitOfWork())
            {
                var businessServiceFactory = new BusinessServiceFactory(uow);
                var serviceToBeTested = businessServiceFactory.BuildAnnouncementService();

                allAnnoucenments = await serviceToBeTested.GetAllAnnoucements();
            }

            if (allAnnoucenments.Count > 0)
                Assert.Pass();
            else
                Assert.Fail("Didn't get the announcements");
        }
    }
}