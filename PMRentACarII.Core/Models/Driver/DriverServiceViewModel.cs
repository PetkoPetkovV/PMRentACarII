using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Driver
{
    public class DriverServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; init; } = null!;
        
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; init; }
        [Display(Name = "Is Hired")]
        public bool IsHired { get; init; } = false;
        public int Age { get; set; }
        public string Description { get; set; } = null!;

        [Display(Name = "Years of experience")]
        public int YearsExperience { get; set; }
    }
}
