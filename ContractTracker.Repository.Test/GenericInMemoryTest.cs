using ContractTracker.Repository.Interfaces;
using NUnit.Framework;
using ContractTracker.Repository.Context;
using System;
using ContractTracker.Repository.Implementation;
using ContractTracker.Repository.EntityModels;
using System.Collections.Generic;
using ContractTracker.Repository.QueryRepositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.Test
{
    public class GenericInMemoryTest
    {
        private IUnitOfWork uow;
        private IUserQueryRepository userQueryRepository;

        [SetUp]
        public void Setup()
        {
            //TOdo, make a common internal Service that builds this
            var builder = new DbContextOptionsBuilder<TrackerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

            this.uow = new MockUnitOfWork(builder);
            var context = uow.GetContext();
            context.Users.AddRange(BuildSomeUsers());
            context.SaveChanges();
            userQueryRepository = new UserQueryRepository(uow);
        }

        [Test]
        public async Task GivenASampleUserCanItBeQueriedByLoginName()
        {
            var user = await userQueryRepository.GetUserByLoginName("test");
            if (user != null)
                Assert.Pass("In memory db works");
            else
                Assert.Fail("In memory could not find the user");

        }

        private List<Users> BuildSomeUsers()
        {
            var user = new Users() { CreatedByUserId = 1, CreatedDate = DateTime.Now, UnitId = 1, UserLogInName = "test", PositionTitle = "req", UserEmail = "test@test.com", UserName = "some test" };
            var testUsers = new List<Users>();
            testUsers.Add(user);
            return testUsers;
        }
    }
}