using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMRentACar.Infrastructure.Data
{
    /// <summary>
    /// creating agent
    /// </summary>
    public class Agent
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// agent's phone number
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// agent's email address
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}



