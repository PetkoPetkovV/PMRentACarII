using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Exceptions;
using PMRentACarII.Core.Models.Car;
using PMRentACarII.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;
        public CarService(
            IRepository _repo, 
            IGuard _guard)
        {
            repo = _repo;
            guard = _guard;
        }
        /// <summary>
        /// All cars
        /// </summary>
        /// <param name="category"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sorting"></param>
        /// <param name="currentPage"></param>
        /// <param name="carsPerPage"></param>
        /// <returns></returns>
        public async Task<CarsViewModel> AllCars(string? category = null, string? searchTerm = null, CarSorting sorting = CarSorting.Newest, int currentPage = 1, int carsPerPage = 1)
        {
            var result = new CarsViewModel();

            var cars = repo.AllReadonly<Car>()
                .Where(c => c.IsActive);


            if (string.IsNullOrEmpty(category) == false)
            {
                cars = cars
                    .Where(c => c.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                cars = cars
                    .Where(c => EF.Functions.Like(c.Make, searchTerm) ||
                    EF.Functions.Like(c.CarModel, searchTerm) ||
                    EF.Functions.Like(c.Description.ToLower(), searchTerm));
            }

            cars = sorting switch
            {
                CarSorting.Price => cars
                .OrderBy(c => c.PricePerDay),
                CarSorting.NotRented => cars
                .OrderBy(c => c.RenterId),
                _ => cars.OrderByDescending(c => c.Id)
            };

            result.Cars = await cars
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage)
                .Select(c => new CarServiceViewModel()
                {
                    Make = c.Make,
                    CarsModel = c.CarModel,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId != null,
                    Id = c.Id
                })
                .ToListAsync();

            result.TotalCars = await cars.CountAsync();

            return result;
        }
        /// <summary>
        /// all cars by agent with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CarServiceViewModel>> AllCarsByAgentId(int id)
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(Car => Car.AgentId == id)
                .Select(c => new CarServiceViewModel() 
                {
                    CarsModel = c.CarModel,
                    Make = c.Make,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId != null
                })
                .ToListAsync();
        }
        /// <summary>
        /// All cars by user with Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CarServiceViewModel>> AllCarsByUserId(string userId)
        {
            return await repo.AllReadonly<Car>()
                .Where(Car => Car.RenterId == userId)
                .Where(c => c.IsActive)
                .Select(c => new CarServiceViewModel()
                {
                    CarsModel = c.CarModel,
                    Make = c.Make,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.RenterId != null
                })
                .ToListAsync();
        }
        /// <summary>
        /// showing all categories names
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }
        /// <summary>
        /// Car Details by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CarDetailsViewModel> CarDetailsById(int id)
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == id)
                .Select(c => new CarDetailsViewModel()
                {
                    CarsModel = c.CarModel,
                    Make = c.Make,
                    Category = c.Category.Name,
                    Description = c.Description,
                    PricePerDay = c.PricePerDay,
                    Id = id,
                    ImageUrl = c.ImageUrl,
                    IsRented = c.RenterId != null
                })
                .FirstAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }
        /// <summary>
        /// creating car
        /// </summary>
        /// <param name="model"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<int> Create(CarModel model, int agentId)
        {
            var car = new Car()
            {
                Id = model.Id,
                CarNumber = model.CarNumber,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerDay = model.PricePerDay,
                SeatCapacity = model.SeatCapacity,
                Make = model.Make,
                CarModel = model.CarsModel,
                AgentId = agentId
            };

            await repo.AddAsync(car);
            await repo.SaveChangesAsync();

            return car.Id;
        }
        /// <summary>
        /// delete car by setting IsActive to false(marking it)
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public async Task Delete(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);
            car.IsActive = false;

            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// edit car
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Edit(int carId, CarModel model)
        {
            
            var car = await repo.GetByIdAsync<Car>(carId); // finds the DbSet and uses FindAsync

            car.CarNumber = model.CarNumber;
            car.CategoryId = model.CategoryId;
            car.Description = model.Description;
            car.ImageUrl = model.ImageUrl;
            car.PricePerDay = model.PricePerDay;
            car.SeatCapacity = model.SeatCapacity;
            car.Make = model.Make;
            car.CarModel = model.CarsModel;
            car.CarNumber = model.CarNumber;

            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// checking if the car with Id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Car>()
                 .AnyAsync(c => c.Id == id && c.IsActive);
        }
        /// <summary>
        /// getting list of All categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CarCategoryViewModel>> GetAllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new CarCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<int> GetCarCategoryId(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).CategoryId; // returns directly the category
        }
        /// <summary>
        /// checking if the car is added by agent with Id
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<bool> HasAgentWithId(int carId, string currentUserId)
        {
            bool result = false;

            var car = await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == carId)
                .Include(c => c.Agent)
                .FirstOrDefaultAsync();

            if (car?.AgentId != null && car?.Agent?.UserId == currentUserId)
            {
                result = true;
            }

            return result;

        }
        /// <summary>
        /// checking if the car is rented
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public async Task<bool> IsRented(int carId)
        {
            return (await repo.GetByIdAsync<Car>(carId)).RenterId != null;
        }
        /// <summary>
        /// checking if the car is rented by user with Id
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<bool> IsRentedByUserWithId(int carId, string currentUserId)
        {
            bool result = false;

            var car = await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .Where(c => c.Id == carId)
                .FirstOrDefaultAsync();

            if (car != null && car.RenterId == currentUserId)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// returns last three added cars
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<CarHomeModel>> NewestCars()
        {
            return await repo.AllReadonly<Car>()
                .Where(c => c.IsActive)
                .OrderByDescending(c => c.Id)
                .Select(c => new CarHomeModel()
                {
                    Id = c.Id,
                    Title = c.Make,
                    ImageUrl = c.ImageUrl,
                    CarsModel = c.CarModel,
                })
                .Take(3)
                .ToListAsync();
        }
        /// <summary>
        /// rent a car by setting RenterId to currentUserId
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task Rent(int carId, string currentUserId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            if (car != null && car.RenterId != null)
            {
                throw new ArgumentException("This car is already rented!");
            }

            guard.AgainstNull(car, "Car cannot be found.");

            car.RenterId = currentUserId;

            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Return car by setting RenterId to null
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public async Task Return(int carId)
        {
            var car = await repo.GetByIdAsync<Car>(carId);

            guard.AgainstNull(car, "Car cannot be found");

            car.RenterId = null;
            await repo.SaveChangesAsync();
        }
    }
}
