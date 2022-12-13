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
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1 },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1 },
            });

            await repo.SaveChangesAsync();

            await carService.Create(new CarModel()
            {
                Id = 3,
                CarsModel = "Created car",
                CarNumber = "",
                Description = "",
                ImageUrl = "",
                Make = "",
            }, 1);
            var dbCar = await repo.GetByIdAsync<Car>(3);

            Assert.That(dbCar.CarModel, Is.EqualTo("Created car"));

        }

        [Test]
        public async Task TestingAllCategoriesNamesWorksProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Category>()
            {
                new Category(){ Id = 1, Name = "A" },
                new Category(){ Id = 2, Name = "B" },
                new Category(){ Id = 4, Name = "C" },
                new Category(){ Id = 5, Name = "D" },
            });

            await repo.SaveChangesAsync();

            var allCategoriesNames = await carService.AllCategoriesNames();

            Assert.That(allCategoriesNames.Count(), Is.EqualTo(4));
            Assert.That(allCategoriesNames.Contains("A"));
        }

        [Test]
        public async Task ExistsTestingWorksProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
            });

            await repo.SaveChangesAsync();

            bool exists = await carService.Exists(1);
            bool exists2 = await carService.Exists(3);

            Assert.IsTrue(exists);
            Assert.IsFalse(exists2);
        }

        [Test]
        public async Task TestEdit()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "" },
            });

            await repo.SaveChangesAsync();

            await carService.Edit(1, new CarModel()
            {
                CarsModel = "Edited car",
                CarNumber = "",
                Description = "",
                ImageUrl = "",
                Make = ""
            });
            var dbCar = await repo.GetByIdAsync<Car>(1);

            Assert.That(dbCar.CarModel, Is.EqualTo("Edited car"));
        }

        [Test]
        public async Task AllCarsByAgentIdGetsProperCars()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1 },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1 },
            });

            await repo.SaveChangesAsync();

            await carService.AllCarsByAgentId(1);
            var dbCar = await repo.GetByIdAsync<Car>(1);
            var dbCar2 = await repo.GetByIdAsync<Car>(2);
            var dbAgent = await repo.GetByIdAsync<Agent>(1);

            Assert.That(dbCar.AgentId, Is.EqualTo(1));
            Assert.That(dbCar2.AgentId, Is.EqualTo(1));
            Assert.That(dbCar.Equals(dbAgent), Is.False);
        }

        [Test]
        public async Task AllCarsByUserIdTestingIfWorksProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, RenterId = "Petko" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, RenterId = "Petko" },
            });

            await repo.SaveChangesAsync();

            await carService.AllCarsByUserId("Petko");
            var dbCar = await repo.GetByIdAsync<Car>(1);
            var dbCar2 = await repo.GetByIdAsync<Car>(2);

            Assert.That(dbCar.RenterId, Is.EqualTo("Petko"));
            Assert.That(dbCar2.RenterId, Is.EqualTo("Petko"));

        }
        /// <summary>
        /// this test must be runned twice(because of the services used)
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestHasAgentWithId()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            var agentService = new AgentService(repo);
            var agent = agentService.Create("Petko", "0885776323", "123@gmail.com");
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() 
                { 
                    Id = 1, 
                    CarModel = "", 
                    CarNumber = "", 
                    Description = "", 
                    ImageUrl = "", 
                    Make = "", 
                    AgentId = agent.Id,
                },
            });

            await repo.SaveChangesAsync();
            var dbCar = await repo.GetByIdAsync<Car>(1);

            Assert.That(await carService.HasAgentWithId(1, "Petko"), Is.True);

        }

        [Test]
        public async Task TestGetCarCategoryId_IfWorksProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, CategoryId = 2 },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, CategoryId = 1 },
            });

            await repo.SaveChangesAsync();
            var dbCar = await repo.GetByIdAsync<Car>(1);

            var carCategory = await carService.GetCarCategoryId(1);

            Assert.That(dbCar.CategoryId, Is.EqualTo(carCategory));
        }

        [Test]
        public async Task TestDeleteIfMarksProperCar()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, CategoryId = 2 },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, CategoryId = 1 },
            });

            await repo.SaveChangesAsync();

            var dbCar = await repo.GetByIdAsync<Car>(1);
            var dbCar2 = await repo.GetByIdAsync<Car>(2);

            await carService.Delete(dbCar.Id);

            Assert.That(dbCar.IsActive, Is.EqualTo(false));
            Assert.That(dbCar2.IsActive, Is.EqualTo(true));
        }

        [Test]
        public async Task TestIsRented_IfWorksProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, RenterId = "Petko" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, RenterId = null },
            });

            await repo.SaveChangesAsync();

            var dbCar = await repo.GetByIdAsync<Car>(1);
            var dbCar2 = await repo.GetByIdAsync<Car>(2);

            Assert.That(true, Is.EqualTo(await carService.IsRented(dbCar.Id)));
            Assert.That(false, Is.EqualTo(await carService.IsRented(dbCar2.Id)));
        }
        [Test]
        public async Task IsRentedByUserWithIdTestingIfWorksProperlyAndGetsTheRightUserWithCar()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, RenterId = "Petko" },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, RenterId = "Petko" },
            });

            await repo.SaveChangesAsync();
            var dbCar = await repo.GetByIdAsync<Car>(1);
            var dbCar2 = await repo.GetByIdAsync<Car>(2);

            await carService.IsRentedByUserWithId(dbCar.Id, dbCar.RenterId);

            Assert.That(dbCar.RenterId, Is.EqualTo("Petko"));
            Assert.That(dbCar2.RenterId, Is.EqualTo("Petko"));


        }

        [Test]

        public async Task TestRent_IfTheUserRentsTheProperCar()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, RenterId = null },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, RenterId = "Petko" },
            });

            await repo.SaveChangesAsync();
            var dbCar = await repo.GetByIdAsync<Car>(1);
            var dbCar2 = await repo.GetByIdAsync<Car>(2);

            await carService.Rent(1, "Petko");
            

            Assert.That(dbCar.RenterId, Is.EqualTo("Petko"));
            Assert.ThrowsAsync<ArgumentException>(async () => await carService.Rent(2, "Petko"));
        }

        [Test]
        public async Task TestReturnIfWorksProperly()
        {
            var repo = new Repository(context);
            var carService = new CarService(repo, guard);
            await repo.AddRangeAsync(new List<Car>()
            {
                new Car() { Id = 1, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 1, RenterId = null },
                new Car() { Id = 2, CarModel = "", CarNumber = "", Description = "", ImageUrl = "", Make = "", AgentId = 2, RenterId = "Petko" },
            });

            await repo.SaveChangesAsync();
            var dbCar = await repo.GetByIdAsync<Car>(1);

            await carService.Rent(1, "Petko");
            await carService.Return(1);
            Assert.That(dbCar.RenterId, Is.EqualTo(null));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
