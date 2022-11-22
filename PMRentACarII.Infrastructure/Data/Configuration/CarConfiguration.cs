using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMRentACar.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Infrastructure.Data.Configuration
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(CreateCars());
        }

        private List<Car> CreateCars()
        {
            var cars = new List<Car>();

            var car = new Car()
            {
                Id = 1,
                Make = "Honda",
                CarModel = "Accord",
                CarNumber = "A3200KC",
                SeatCapacity = 5,
                PricePerDay = 30.00M,
                Available = true,
                ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/6310cb2cbb908f077de4f565/0x0.jpg?format=jpg&width=1200",
                RenterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                DriverId = 1,
                CategoryId = 5,
                Description = "A very comfortable and reliable car"
            };
            cars.Add(car);

            car = new Car()
            {
                Id = 2,
                Make = "BMW",
                CarModel = "X3",
                CarNumber = "A3201KC",
                SeatCapacity = 5,
                PricePerDay = 60.00M,
                Available = true,
                ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/2022-bmw-x3-m40i-108-1650211641.jpg?crop=0.582xw:0.490xh;0.186xw,0.387xh&resize=1200:*",
                DriverId = 2,
                CategoryId = 5,
                Description = "Traditionally, sports sedans have been the vehicles that best projected the spirit of the BMW brand. Not so much anymore."
            };

            cars.Add(car);

            return cars;
        }
    }
}
