using PMRentACarII.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Car
{
    public class CarHomeModel : ICarModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Make { get; init; } = null!;

        public string CarsModel { get; init; } = null!;
    }
}
