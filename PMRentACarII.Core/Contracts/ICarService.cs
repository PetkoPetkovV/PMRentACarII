using PMRentACarII.Core.Models.Car;

namespace PMRentACarII.Core.Contracts
{
    public interface ICarService
    {
        Task <IEnumerable<CarHomeModel>> NewestCars();
        Task <IEnumerable<CarCategoryViewModel>> GetAllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(CarModel model, int agentId);

    }
}
