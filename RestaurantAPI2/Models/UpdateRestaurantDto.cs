using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI2.Models
{
    public class UpdateRestaurantDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool hasDelivery { get; set; }
    }
}
