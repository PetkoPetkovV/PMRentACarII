using Microsoft.AspNetCore.Identity;
using PMRentACar.Infrastructure.Data.Constants;
using PMRentACarII.Infrastructure.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMRentACar.Infrastructure.Data
{
    /// <summary>
    /// creating driver
    /// </summary>
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// driver's full name
        /// </summary>
        [Required]
        [StringLength(DriverConstants.DriverNameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Driver's age
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// years of driving experience
        /// </summary>
        [Required]
        public int YearsOfExperience { get; set; }
        /// <summary>
        /// driver's category (safari, gid, etc...)
        /// </summary>
        public string? DriversCategory { get; set; } = null;
        /// <summary>
        /// driver's services price per day
        /// </summary>
        [Column(TypeName = "money")]
        public decimal DriverPrice { get; set; }
        /// <summary>
        /// checking if the driver is already taken
        /// </summary>

        public string? HirerId { get; set; }
        [ForeignKey(nameof(HirerId))]
        public IdentityUser? Hirer { get; set; }

        public int? AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent? Agent { get; set; }

    }
}
