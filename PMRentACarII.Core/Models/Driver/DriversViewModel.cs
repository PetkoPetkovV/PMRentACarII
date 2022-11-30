using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Driver
{
    public class DriversViewModel
    {
        public int TotalDrivers { get; set; }

        public IEnumerable<DriverServiceViewModel> Drivers { get; set; } = new List<DriverServiceViewModel>();
    }
}
