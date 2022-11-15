using PMRentACarII.Core.Models.Car;

namespace PMRentACarII.Core.Contracts
{
    public interface ICarService
    {
        Task <IEnumerable<CarHomeModel>> NewestCars();
    }
}
