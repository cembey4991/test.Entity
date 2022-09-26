namespace test.Business.Dtos
{
    public class ProductDto : EntityDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryId { get; set; }
    }
}
