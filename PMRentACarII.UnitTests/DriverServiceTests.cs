using Microsoft.EntityFrameworkCore;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Exceptions;
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

        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
