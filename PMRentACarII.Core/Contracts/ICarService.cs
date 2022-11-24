using PMRentACarII.Core.Models.Car;

namespace PMRentACarII.Core.Contracts
{
    public interface ICarService
    {
        Task <IEnumerable<CarHomeModel>> NewestCars();
        Task <IEnumerable<CarCategoryViewModel>> GetAllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(CarModel model, int agentId);

        Task<CarsViewModel> AllCars(
            string? category = null,
            string? searchTerm = null,
            CarSorting sorting = CarSorting.Newest,
            int currentPage = 1,
            int carsPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();

    }
}
