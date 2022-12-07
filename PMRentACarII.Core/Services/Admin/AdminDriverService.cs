using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Core.Contracts;
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
    public class AdminDriverService : IAdminDriverService
    {
        private readonly IRepository repo;

        public AdminDriverService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<DriverServiceModel>> AllDrivers()
        {
            List<DriverServiceModel> drivers;

            drivers = await repo.AllReadonly<Driver>()
                .Select(d => new DriverServiceModel()
                {
                    UserName = d.Name,
                    YearsOfExperience = d.YearsOfExperience
                })
                .ToListAsync();

            return drivers;
        }
    }
}
