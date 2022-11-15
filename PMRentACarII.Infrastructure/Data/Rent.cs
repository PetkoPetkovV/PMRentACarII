using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMRentACar.Infrastructure.Data
{
    public class Rent
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// renting start date (car with or without driver)
        /// </summary>
        [Required]
        public string StartingDate { get; set; } = null!;

        /// <summary>
        /// renting end date
        /// </summary>
        [Required]
        public string ReturnDate { get; set; } = null!;

        /// <summary>
        /// service rating 1-10
        /// </summary>
        [Required]
        public int Rating { get; set; }

        /// <summary>
        /// total cost of services
        /// </summary>
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        public int? DriverId { get; set; }

        public Driver? Driver { get; set; }


    }
}
