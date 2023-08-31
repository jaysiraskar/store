namespace Core.Entities
{
    public class ProductRating : BaseEntity
    {
        public double Rating { get; set; }
        public string Review { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
