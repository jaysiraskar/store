using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerBasketDto
    {
        public static int CustomerBasket { get; internal set; }

        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}