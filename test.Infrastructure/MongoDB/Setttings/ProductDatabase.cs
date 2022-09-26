using test.Infrastructure.MongoDB.Interface;

namespace test.Infrastructure.MongoDB.Setttings
{
    public class ProductDatabase : IProductDatabase
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

    }
}
