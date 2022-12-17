using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Exceptions;
using PMRentACarII.Core.Models.Driver;
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
    public class DriverServiceTests
    {
        private IRepository repo;
        private IGuard guard;
        private ICarService carService;
        private ApplicationDbContext context;
        private IAgentService agentService;
        private IDriverService driverService;
        [SetUp]
        public void SetUp()
        {
            guard = new Guard();
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DriverDatabase")
                .Options;

            context = new ApplicationDbContext(contextOptions);


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task TestIsHired_IfWorksProperly()
        {
            var repo = new Repository(context);
            var driverService = new DriverService(repo, guard);
            await repo.AddRangeAsync(new List<Driver>()
            {
                new Driver() { Id = 1, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 1, HirerId = "Petko" },
                new Driver() { Id = 2, Name = "", Age = 33, YearsOfExperience = 10, ImageUrl = "", DriverPrice = 40, AgentId = 2, HirerId = null },
            });

            await repo.SaveChangesAsync();

            var dbDriver = await repo.GetByIdAsync<Driver>(1);
            var dbDriver2 = await repo.GetByIdAsync<Driver>(2);

            Assert.That((await driverService.IsHired(dbDriver.Id)), Is.EqualTo(true));
            Assert.That((await driverService.IsHired(dbDriver2.Id)), Is.EqualTo(false));
        }

        [Test]
        public async Task TestIsHiredByUserWithId_IfWorkingProperly()
        {
            var repo = new Repository(context);
            var driverService = new DriverService(repo, guard);
            await repo.AddRangeAsync(new List<Driver>()
            {
               new Driver() { Id = 1, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 1, HirerId = "Petko" },
               new Driver() { Id = 2, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 1, HirerId = "Dimitar" },

            });

            await repo.SaveChangesAsync();
            var dbDriver = await repo.GetByIdAsync<Driver>(1);
            var dbDriver2 = await repo.GetByIdAsync<Driver>(2);

            await driverService.IsHiredByUserWithId(dbDriver.Id, dbDriver.HirerId);

            Assert.That(dbDriver.HirerId, Is.EqualTo("Petko"));
            Assert.That(dbDriver2.HirerId, Is.EqualTo("Dimitar"));
        }

        [Test]
        public async Task TestHireIfWorksProperlyAndHirersTheRightPerson()
        {
            var repo = new Repository(context);
            var driverService = new DriverService(repo, guard);
            await repo.AddRangeAsync(new List<Driver>()
            {
              new Driver() { Id = 3, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 1, HirerId = null },
              new Driver() { Id = 4, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 2, HirerId = "MarryChristmas" },

            });

            await repo.SaveChangesAsync();
            var dbDriver = await repo.GetByIdAsync<Driver>(3);
            var dbDriver2 = await repo.GetByIdAsync<Driver>(4);

            await driverService.Hire(3, "MarryChristmas");


            Assert.That(dbDriver.HirerId, Is.EqualTo("MarryChristmas"));
            Assert.ThrowsAsync<ArgumentException>(async () => await driverService.Hire(4, "Jim"));
        }

        [Test]
        public async Task TestRelease()
        {
            var repo = new Repository(context);
            var driverService = new DriverService(repo, guard);
            await repo.AddRangeAsync(new List<Driver>()
            {
                new Driver() { Id = 3, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 1, HirerId = null }
            });

            await repo.SaveChangesAsync();
            var dbDriver = await repo.GetByIdAsync<Driver>(3);

            await driverService.Hire(3, "Jim");
            await driverService.Release(3);
            Assert.That(dbDriver.HirerId, Is.EqualTo(null));
        }

        [Test]
        public async Task CreateDriverTestIfCreatesDriverWithAllRequiredProperties()
        {
            var repo = new Repository(context);
            var driverService = new DriverService(repo, guard);
            await repo.AddRangeAsync(new List<Driver>()
            {
                new Driver() { Id = 3, Name = "", Age = 22, YearsOfExperience = 6, ImageUrl = "", DriverPrice = 30, AgentId = 1, HirerId = null }
            });

            await repo.SaveChangesAsync();

            await driverService.CreateDriver(new DriverModel()
            {
                Id = 5,
                Name = "Jin",
                Age = 30,
                PricePerDay = 30,
                ImageUrl = "",
                YearsExperience = 10,
            }, 1);
            var dbDriver = await repo.GetByIdAsync<Driver>(5);

            Assert.That(dbDriver.Name, Is.EqualTo("Jin"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
