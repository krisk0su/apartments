namespace ApartmentsAPI.Settings.Interfaces
{
    public interface IBookstoreDatabaseSettings
    {
        string BooksCollectionName { get; set; }

        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
