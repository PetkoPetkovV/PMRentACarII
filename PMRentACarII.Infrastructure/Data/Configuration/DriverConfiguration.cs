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
    internal class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasData(CreateDrivers());
        }

        private List<Driver> CreateDrivers()
        {
            var drivers = new List<Driver>();
            var drver = new Driver()
            {
                Id = 1,
                Age = 30,
                Available = true,
                DriverCategory = "Expert",
                DriverPrice = 30.00M,
                Name = "Hose",
                YearsOfExperience = 11
            };
            drivers.Add(drver);

            drver = new Driver()
            {
                Id = 2,
                Age = 32,
                Available = true,
                DriverCategory = "Professional Driver",
                DriverPrice = 60.00M,
                Name = "Peter",
                YearsOfExperience = 11
            };
            drivers.Add(drver);

            drver = new Driver()
            {
                Id = 3,
                Age = 29,
                Available = true,
                DriverCategory = "Lad",
                DriverPrice = 20.00M,
                Name = "Mark",
                YearsOfExperience = 7
            };
            drivers.Add(drver);

            return drivers;
        }
    }
}
