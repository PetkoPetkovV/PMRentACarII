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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>();

            var category = new Category()
            {
                Id = 1,
                Name = "Hatchback"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Van"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Sedan"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Coupe"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "SUV"
            };
            categories.Add(category);

            return categories;
        }
    }
}
