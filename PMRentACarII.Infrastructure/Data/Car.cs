using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using PMRentACar.Infrastructure.Data.Constants;

namespace PMRentACar.Infrastructure.Data
{
    /// <summary>
    /// car registration
    /// </summary>
    public class Car
    {
        /// <summary>
        /// unique identifier
        /// </summary>
        [Key]
        public int Id { get; set; } 
        /// <summary>
        /// car plate number
        /// </summary>
        [Required]
        [StringLength(Constants.Constants.CarNumberMaxLength)]
        public string CarNumber { get; set; } = null!;
        /// <summary>
        /// car make name
        /// </summary>
        [Required]
        [StringLength(Constants.Constants.CarMakeMaxLength)]
        public string Make { get; set; } = null!;
        /// <summary>
        /// car model name
        /// </summary>
        [Required]
        [StringLength(Constants.Constants.CarModelMaxLength)]
        public string CarModel { get; set; } = null!;
        [Required]
        [StringLength(Constants.Constants.CarDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public decimal PricePerDay { get; set; }
        /// <summary>
        /// maximum seat capacity of the car
        /// </summary>
        [Required]
        public int SeatCapacity { get; set; }

        /// <summary>
        /// picture of the car
        /// </summary>

        [Required]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// checking if the car is already rented or not
        /// </summary>
        [Required]
        public bool Available { get; set; }
        /// <summary>
        /// driver's Id(optional)
        /// </summary>
        /// 
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public int? DriverId { get; set; }
        /// <summary>
        /// renter's Id(if the car is available, then setting the Id)
        /// </summary>
        /// 
        [ForeignKey(nameof(DriverId))]
        public Driver? Driver { get; set; }
        public string? RenterId { get; set; }
        [ForeignKey(nameof(RenterId))]
        public IdentityUser? Renter { get; set; }

        public int? AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent? Agent { get; set; }

    }
}
