using ContractTracker.Repository.Interfaces;
using NUnit.Framework;
using System;
using ContractTracker.Repository.EntityModels;
using System.Collections.Generic;
using ContractTracker.Repository.QueryRepositories;
using System.Threading.Tasks;
using ContractTracker.Repository.Test.Helpers;
using Microsoft.EntityFrameworkCore;
using ContractTracker.Repository.Context;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.QueryModels;

namespace ContractTracker.Repository.Test
{
    public class VendorSearchTest
    {
        private IVendorQueryRepository vendorQueryRepository;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TrackerDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContractTracker;integrated security=true;MultipleActiveResultSets=true");
            var uow = new UnitOfWork(options);
            vendorQueryRepository = new VendorQueryRepository(uow);
        }

        [Test]
        public async Task GivenASampleUserCanItBeQueriedByLoginName()
        {
            var requestModel = new VendorSearchRequestModel();
            requestModel.PageNumber = 1;
            requestModel.FilterByVendorNumber = "547989128";
            requestModel.FilterBySequenceNumber = null;
            requestModel.FilterByPurchasingName = null;
            requestModel.FilterByVendorType = null;
            requestModel.PageSize = 25;
            requestModel.SortColumn = "VendorType";
            requestModel.SortDirection = "ASC";

            var results = await vendorQueryRepository.SearchVendors(requestModel);
            if (results.Count > 0)
                Assert.Pass("Woo");
            else
                Assert.Fail("SearvhVendorFail");

        }
    }
}
