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
    internal class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasData(CreateRents());
        }

        private List<Rent> CreateRents()
        {
            var rents = new List<Rent>();

            var rent = new Rent()
            {
                Id = 1,
                Rating = 5,
                StartingDate = "30.01.2022",
                ReturnDate = "31.01.2022",
                DriverId = 1,
                CarId = 1,
                TotalPrice = 60M
            };

            rents.Add(rent);

            return rents;
        }
    }
}
