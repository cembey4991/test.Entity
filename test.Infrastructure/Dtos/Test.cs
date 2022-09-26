using test.Entity.Entities;

namespace test.Infrastructure.Dtos
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryId { get; set; }
    }
}
