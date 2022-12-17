using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Admin
{
    public class RentServiceModel
    {
        public int CarId { get; set; }
        public int? DriverId { get; set; }
        public string? CarName { get; init; }
        public string? DriverName { get; init; }


    }
}
