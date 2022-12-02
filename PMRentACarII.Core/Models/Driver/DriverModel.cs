using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Driver
{
    public class DriverModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int YearsExperience { get; set; }

        public decimal PricePerDay { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string DriverCategory { get; set; } = null!;

    }
}
