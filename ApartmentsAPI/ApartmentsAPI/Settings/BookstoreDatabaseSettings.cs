namespace ApartmentsAPI.Settings
{
    using ApartmentsAPI.Settings.Interfaces;

    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    
}
