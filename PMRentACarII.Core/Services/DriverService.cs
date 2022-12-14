using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
using PMRentACarII.Core.Exceptions;
using PMRentACarII.Core.Models.Driver;
using PMRentACarII.Infrastructure.Data;
using PMRentACarII.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;

        public DriverService(IRepository _repo, IGuard _guard)
        {
            repo = _repo;
            guard = _guard;
        }
        /// <summary>
        /// getting All drivers by filtering them
        /// </summary>
        /// <param name="category"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sorting"></param>
        /// <param name="currentPage"></param>
        /// <param name="driversPerPage"></param>
        /// <returns></returns>
        public async Task<DriversViewModel> AllDrivers(string? category = null, string? searchTerm = null, DriverSorting sorting = DriverSorting.Years, int currentPage = 1, int driversPerPage = 1)
        {
            var result = new DriversViewModel();

            var drivers = repo.AllReadonly<Driver>();


            if (string.IsNullOrEmpty(category) == false)
            {
                drivers = drivers
                    .Where(d => d.DriversCategory == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                drivers = drivers
                    .Where(d => EF.Functions.Like(d.Name, searchTerm));
            }

            drivers = sorting switch
            {
                DriverSorting.Price => drivers
                .OrderBy(d => d.DriverPrice),
                DriverSorting.NotHired => drivers
                .OrderBy(d => d.HirerId),
                _ => drivers.OrderByDescending(d => d.Id)
            };

            result.Drivers = await drivers
                .Skip((currentPage - 1) * driversPerPage)
                .Take(driversPerPage)
                .Select(d => new DriverServiceViewModel()
                {
                    Name = d.Name,
                    YearsExperience = d.YearsOfExperience,
                    PricePerDay = d.DriverPrice,
                    IsHired = d.HirerId != null,
                    Id = d.Id,
                    Age = d.Age,
                })
                .ToListAsync();

            result.TotalDrivers = await drivers.CountAsync();

            return result;
        }
        /// <summary>
        /// Creating driver
        /// </summary>
        /// <param name="model"></param>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public async Task<int> CreateDriver(DriverModel model, int agentId)
        {
            var driver = new Driver()
            {
                Id = model.Id,
                Age = model.Age,
                DriversCategory = model.DriverCategory,
                DriverPrice = model.PricePerDay,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                YearsOfExperience = model.YearsExperience,
                AgentId = agentId
            };

            await repo.AddAsync(driver);
            await repo.SaveChangesAsync();

            return driver.Id;
        }
        /// <summary>
        /// Hire a driver by Id
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task Hire(int driverId, string currentUserId)
        {
            var driver = await repo.GetByIdAsync<Driver>(driverId);

            if (driver != null && driver.HirerId != null)
            {
                throw new ArgumentException("This driver is already hired!");
            }

            guard.AgainstNull(driver, "Driver cannot be found.");

            driver.HirerId = currentUserId;

            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// checking if the driver is already hired
        /// </summary>
        /// <param name="dirverId"></param>
        /// <returns></returns>
        public async Task<bool> IsHired(int dirverId)
        {
            return (await repo.GetByIdAsync<Driver>(dirverId)).HirerId != null;
        }
        /// <summary>
        /// checking if the driver is hired by the current user
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<bool> IsHiredByUserWithId(int driverId, string currentUserId)
        {
            bool result = false;

            var driver = await repo.AllReadonly<Driver>()
                .Where(d => d.Id == driverId)
                .FirstOrDefaultAsync();

            if (driver != null && driver.HirerId == currentUserId)
            {
                result = true;
            }

            return result;
        }
        /// <summary>
        /// releasing driver by setting hirerId to null
        /// </summary>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public async Task Release(int driverId)
        {
            var driver = await repo.GetByIdAsync<Driver>(driverId);

            guard.AgainstNull(driver, "Driver cannot be found");

            driver.HirerId = null;
            await repo.SaveChangesAsync();
        }
    }
}
