using PMRentACar.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace PMRentACar.Infrastructure.Data
{
    /// <summary>
    /// creating category
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// category name
        /// </summary>
        [Required]
        [StringLength(CategoryConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// List of cars per category
        /// </summary>
        public List<Car> Cars { get; set; } = new List<Car>();

    }
}
