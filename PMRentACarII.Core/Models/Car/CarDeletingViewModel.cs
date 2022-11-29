using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Car
{
    public class CarDeletingViewModel
    {
        public string Make { get; set; } = null!;

        public string CarsModel { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
