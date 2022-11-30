using PMRentACarII.Core.Models.Driver;

namespace PMRentACarII.Models
{
    public class AllDriversViewModel
    {
        public const int DriversPerPage = 3;

        public string Category { get; set; } = null!;

        public string? SearchTerm { get; set; }

        public DriverSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalDriversCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<DriverServiceViewModel> Drivers { get; set; } = Enumerable.Empty<DriverServiceViewModel>();
    }
}
