namespace ShyneeBackend.Infrastructure
{
    public class DbSettings
    {
        public DbSettings(
            string connectionString, 
            string database)
        {
            ConnectionString = connectionString;
            Database = database;
        }

        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
