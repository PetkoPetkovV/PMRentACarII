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
    public class CarModel : ICarModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(Constants.CarNumberMaxLength, MinimumLength = Constants.CarNumberMinLength)]
        [Display(Name = "Car plate number")]
        public string CarNumber { get; set; } = null!;
        [Required]
        [StringLength(Constants.CarMakeMaxLength, MinimumLength = Constants.CarMakeMinLength)]
        public string Make { get; set; } = null!;
        [Required]
        [StringLength(Constants.CarModelMaxLength, MinimumLength = Constants.CarModelMinLength)]
        [Display(Name = "Car model")]
        public string CarsModel { get; set; } = null!;
        [Required]
        [StringLength(Constants.CarDescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [Display(Name = "Price per day")]
        [Range(typeof(decimal), "10.00", "1000.00", ErrorMessage = "Price per day must be a number between 10.00 and 1000.00")]
        public decimal PricePerDay { get; set; }
        [Required]
        [Range(2, 52)]
        [Display(Name = "Number of seats")]
        public int SeatCapacity { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; } = new List<CarCategoryViewModel>();

    }
}
