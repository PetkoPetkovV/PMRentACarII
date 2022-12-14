using PMRentACar.Infrastructure.Data.Constants;
using PMRentACarII.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Car
{
    public class CarServiceViewModel : ICarModel
    {
        public int Id { get; set; }
        public string Make { get; init; } = null!;
        [Display(Name = "Car model")]
        public string CarsModel { get; init; } = null!;
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;
        [Display(Name = "Price per day")]
        public decimal PricePerDay { get; init; }
        [Display(Name = "Is Rented")]
        public bool IsRented { get; init; } = false;

        [Display(Name = "Car plate number")]
        public string CarNumber { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Number of seats")]
        public int SeatCapacity { get; set; }
    }
}
