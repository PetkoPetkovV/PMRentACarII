namespace PMRentACarII.Core.Models.Car
{
    public class CarsViewModel
    {
        public int TotalCars { get; set; }

        public IEnumerable<CarServiceViewModel> Cars { get; set; } = new List<CarServiceViewModel>();

    }
}
