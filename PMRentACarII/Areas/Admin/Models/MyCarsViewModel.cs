using PMRentACarII.Core.Models.Car;

namespace PMRentACarII.Areas.Admin.Models
{
    public class MyCarsViewModel
    {
        public IEnumerable<CarServiceViewModel> AddedCars { get; set; } = new List<CarServiceViewModel>();
        public IEnumerable<CarServiceViewModel> RentedCars { get; set; } = new List<CarServiceViewModel>();

    }
}
