using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Driver
{
    public class DriverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string DriverCategory { get; set; } = null!;

        public int YearsExperience { get; set; }

        public decimal Rating { get; set; }
    }
}
