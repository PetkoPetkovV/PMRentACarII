using Microsoft.EntityFrameworkCore;
using Moq;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Exceptions;
using PMRentACarII.Core.Models.Car;
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
    public class CarServiceTests
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
                .UseInMemoryDatabase("CarDatabase")
                .Options;

            context = new ApplicationDbContext(contextOptions);
           

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        [Test]
        public async Task TestNewestThreeCarsNumberAndOrder()
        {
            var repo = new Repository(context);
            carService = new CarService(repo, guard);

            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 5, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 3, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
            });

            await repo.SaveChangesAsync();

            var carCollection = await carService.NewestCars();

            Assert.That(3, Is.EqualTo(carCollection.Count()));
            Assert.That(carCollection.Any(c => c.Id == 1), Is.False);
        }

        [Test]
        public async Task TestGetAllCategoriesNumberAndOrder()
        {
            var repo = new Repository(context);
            carService = new CarService(repo, guard);

            await repo.AddRangeAsync(new List<Category>()
            {
                new Category(){ Id = 1, Name = "A" },
                new Category(){ Id = 2, Name = "B" },
                new Category(){ Id = 4, Name = "C" },
                new Category(){ Id = 5, Name = "D" },
            });

            await repo.SaveChangesAsync();

            var categoriesCollection = await carService.GetAllCategories();

            Assert.That(4, Is.EqualTo(categoriesCollection.Count()));
            Assert.That(categoriesCollection.Any(c => c.Name == "A"));
        }

        [Test]
        public async Task TestCategoryExists()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);

            await repo.AddRangeAsync(new List<Category>()
            {
                new Category{ Id = 1, Name = "A" },
                new Category{ Id = 2, Name = "b" },
                new Category{ Id = 3, Name = "c" },
            });
            
            await repo.SaveChangesAsync();

            int falseCategoryId = 4;
            int categoryId = carService.GetAllCategories().Id;
            var categoryExists = await carService.CategoryExists(categoryId);
            var categoryExistsFalse = await carService.CategoryExists(falseCategoryId);

            Assert.That(categoryExists);
            Assert.That(!categoryExistsFalse);
        }

        [Test]
        public async Task TestCreateIfWorkProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            var agentService = new AgentService(repo);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 5, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 3, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
            });

            await repo.SaveChangesAsync();

            var carCollection = await carService.NewestCars();

            var newCar = new CarModel() { Id = 7, CarsModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" };
            var agentId = await agentService.GetAgentId("Petko");

           var createdCar =  await carService.Create(newCar, agentId);
            Assert.NotNull(createdCar);
            Assert.That(createdCar.Equals(newCar), Is.True);
            Assert.That(createdCar, Is.AnyOf(carCollection));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
