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
