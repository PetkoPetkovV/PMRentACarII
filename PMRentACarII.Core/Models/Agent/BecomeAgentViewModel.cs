using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRentACarII.Core.Models.Agent
{
    public class BecomeAgentViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
