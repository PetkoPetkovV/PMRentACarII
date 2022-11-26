using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
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

        public CarService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<CarsViewModel> AllCars(string? category = null, string? searchTerm = null, CarSorting sorting = CarSorting.Newest, int currentPage = 1, int carsPerPage = 1)
        {
            var result = new CarsViewModel();

            var cars = repo.AllReadonly<Car>();

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
                    IsRented = c.Available,
                    Id = c.Id
                })
                .ToListAsync();

            result.TotalCars = await cars.CountAsync();

            return result;
        }

        public async Task<IEnumerable<CarServiceViewModel>> AllCarsByAgentId(int id)
        {
            return await repo.AllReadonly<Car>()
                .Where(Car => Car.AgentId == id)
                .Select(c => new CarServiceViewModel() 
                {
                    CarsModel = c.CarModel,
                    Make = c.Make,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.Available
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CarServiceViewModel>> AllCarsByUserId(string userId)
        {
            return await repo.AllReadonly<Car>()
                .Where(Car => Car.RenterId == userId)
                .Select(c => new CarServiceViewModel()
                {
                    CarsModel = c.CarModel,
                    Make = c.Make,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.Available
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(CarModel model, int agentId)
        {
            var car = new Car()
            {
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

        /// <summary>
        /// returns last three added cars
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<CarHomeModel>> NewestCars()
        {
            return await repo.AllReadonly<Car>()
                .OrderByDescending(c => c.Id)
                .Select(c => new CarHomeModel()
                {
                    Id = c.Id,
                    Title = c.Make,
                    ImageUrl = c.ImageUrl
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
