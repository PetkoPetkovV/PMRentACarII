using PMRentACarII.Core.Models.Car;

namespace PMRentACarII.Models
{
    public class AllCarsViewModel
    {
        public const int CarsPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public CarSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalCarsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<CarServiceViewModel> Cars { get; set; } = Enumerable.Empty<CarServiceViewModel>();

    }
}
