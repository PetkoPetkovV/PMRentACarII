using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Exceptions;
using PMRentACarII.Core.Services;
using PMRentACarII.Infrastructure.Data;
using PMRentACarII.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.UnitTests
{
    public class AgentServiceTests
    {
        private IRepository repo;
        private IGuard guard;
        private ICarService carService;
        private ApplicationDbContext context;
        private IAgentService agentService;
        [SetUp]
        public void SetUp()
        {
            guard = new Guard();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("AgentDatabase")
                .Options;

            context = new ApplicationDbContext(contextOptions);


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task TestExistsById_IfWorksProperly()
        {
            var repo = new Repository(context);
            var agentService = new AgentService(repo);
            await repo.AddRangeAsync(new List<Agent>()
            {
                new Agent() { Id = 4, Email = "", PhoneNumber = "", UserId = "A" },
                new Agent() { Id = 5, Email = "", PhoneNumber = "", UserId = "B" },
            });

            await repo.SaveChangesAsync();

            var dbAgent = await repo.GetByIdAsync<Agent>(4);
            await agentService.ExistsById("A");

            Assert.That(dbAgent.UserId, Is.EqualTo("A"));
            Assert.That(await agentService.ExistsById("A"), Is.True);
            Assert.That(await agentService.ExistsById("C"), Is.False);
            
        }

        [Test]
        public async Task UserWithPhoneNumberExistsTesting_IfWorksProperly()
        {
            var repo = new Repository(context);
            var agentService = new AgentService(repo);
            await repo.AddRangeAsync(new List<Agent>()
            {
                new Agent() { Id = 4, Email = "", PhoneNumber = "+359181818", UserId = "A" },
                new Agent() { Id = 5, Email = "", PhoneNumber = "", UserId = "B" },
            });

            await repo.SaveChangesAsync();

            Assert.That(await agentService.UserWithPhoneNumberExists("+359181818"), Is.True);
            Assert.That(await agentService.UserWithPhoneNumberExists("+359181819"), Is.False);
        }

        [Test]
        public async Task UserWithThatEmailExistsTest_IfWorksProperly()
        {
            var repo = new Repository(context);
            var agentService = new AgentService(repo);
            await repo.AddRangeAsync(new List<Agent>()
            {
                new Agent() { Id = 4, Email = "", PhoneNumber = "+359181818", UserId = "A" },
                new Agent() { Id = 5, Email = "asd@gmail.com", PhoneNumber = "", UserId = "B" },
            });

            await repo.SaveChangesAsync();

            var dbAgent = await repo.GetByIdAsync<Agent>(5);

            Assert.That(dbAgent.Email, Is.EqualTo("asd@gmail.com"));
            Assert.That(await agentService.UserWithThatEmailExists("asd@gmail.com"), Is.True);
            Assert.That(await agentService.UserWithThatEmailExists("asd@gmaill.com"), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
