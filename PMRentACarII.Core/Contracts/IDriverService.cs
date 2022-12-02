using PMRentACarII.Core.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Contracts
{
    public interface IDriverService
    {
        Task<bool> IsHired(int dirverId);

        Task<bool> IsHiredByUserWithId(int driverId, string currentUserId);

        Task Hire(int driverId, string currentUserId);

        Task<DriversViewModel> AllDrivers(
            string? category = null,
            string? searchTerm = null,
            DriverSorting sorting = DriverSorting.Years,
            int currentPage = 1,
            int carsPerPage = 1);

        Task<int> CreateDriver(DriverModel model, int agentId);
    }
}
