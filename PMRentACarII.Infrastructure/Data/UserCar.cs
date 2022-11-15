using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMRentACar.Infrastructure.Data
{
    public class UserCar
    {
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;
    }
}
