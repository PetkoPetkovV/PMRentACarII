using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts.Admin;
using PMRentACarII.Core.Models.Admin;
using PMRentACarII.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Services.Admin
{
    public class RentService : IRentService
    {
        private readonly IRepository repo;

        public RentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<RentServiceModel>> AllRentsAdmin()
        {
            List<RentServiceModel> result;

            result = await repo.AllReadonly<Car>()
                .Where(c => c.RenterId != null)
                .Select(c => new RentServiceModel()
                {
                    CarId = c.Id,
                    CarName = c.Make,
                    DriverId = c.Driver.Id,
                    DriverName = c.Driver.Name
                }).ToListAsync();

            return result;
        }
    }
}
