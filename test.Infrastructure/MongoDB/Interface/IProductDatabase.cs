namespace test.Infrastructure.MongoDB.Interface
{
    public interface IProductDatabase
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
