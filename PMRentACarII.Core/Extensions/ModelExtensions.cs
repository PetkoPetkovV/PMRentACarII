using PMRentACarII.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace PMRentACarII.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ICarModel car)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(car.CarsModel.Replace(" ", "-"));
            sb.Append("-");
            sb.Append(GetModel(car.CarsModel));

            return sb.ToString();
        }

        private static string GetModel(string carModel)
        {
            string result = string.Join("-", carModel.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(3));

            return Regex.Replace(carModel, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
