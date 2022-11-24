using PMRentACar.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Car
{
    public class CarServiceViewModel
    {
        public int Id { get; init; }

        public string Make { get; init; } = null!;
        [Display(Name = "Car model")]
        public string CarsModel { get; init; } = null!;
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; init; }
        [Display(Name = "Is Rented")]
        public bool IsRented { get; init; }


    }
}
