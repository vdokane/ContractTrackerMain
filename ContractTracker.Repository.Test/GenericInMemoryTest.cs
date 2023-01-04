using ContractTracker.Repository.Interfaces;
using NUnit.Framework;
using System;
using ContractTracker.Repository.EntityModels;
using System.Collections.Generic;
using ContractTracker.Repository.QueryRepositories;
using System.Threading.Tasks;
using ContractTracker.Repository.Test.Helpers;

namespace ContractTracker.Repository.Test
{
    public class GenericInMemoryTest
    {
        private IUserQueryRepository userQueryRepository;
        private OptionsBuilder optionsBuilder;

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new OptionsBuilder();
            var uow = optionsBuilder.BuildMockUnitOfWork();
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
            var user = new Users() { CreatedByUserId = 1, CreatedDate = DateTime.Now, UserLogInName = "test", PositionTitle = "req", UserEmail = "test@test.com", UserName = "some test" };
            var testUsers = new List<Users>();
            testUsers.Add(user);
            return testUsers;
        }
    }
}