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

        Task<IEnumerable<CarServiceViewModel>> AllCarsByAgentId(int id);
        Task<IEnumerable<CarServiceViewModel>> AllCarsByUserId(string userId);

        Task<CarDetailsViewModel> CarDetailsById(int id);

        Task<bool> Exists(int id);

        Task Edit(int carId, CarModel model);

        Task<bool> HasAgentWithId(int carId, string currentUserId);

        Task<int> GetCarCategoryId(int carId);

        Task Delete(int id);

        Task<bool> IsRented(int carId);

        Task<bool> IsRentedByUserWithId(int carId, string currentUserId);

        Task Rent(int carId, string currentUserId);

        Task Return(int carId);

    }
}
