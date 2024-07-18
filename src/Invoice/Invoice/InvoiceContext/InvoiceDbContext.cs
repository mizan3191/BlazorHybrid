namespace Invoice.InvoiceContext
{
    public class InvoiceDbContext
    {
        private const string Db_Name = "InvoiceDb.db3";
        private readonly SQLiteAsyncConnection _connection;

        public InvoiceDbContext()
        {
            _connection = CreateConnection();
            InitializeDatabase();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return _connection;
        }

        private SQLiteAsyncConnection CreateConnection()
        {

            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbPath = Path.Combine(appDataDirectory, Db_Name);
            return new SQLiteAsyncConnection(dbPath);
        }

        private async Task InitializeDatabase()
        {
            await _connection.CreateTableAsync<Company>();
            await _connection.CreateTableAsync<Product>();
            await _connection.CreateTableAsync<Customer>();
        }

        public async Task Create<T>(T entity)
        {
            await _connection.InsertAsync(entity);
        }

        public async Task Update<T>(T entity)
        {
            await _connection.UpdateAsync(entity);
        }

        public async Task Delete<T>(T entity)
        {
            await _connection.DeleteAsync(entity);
        }

        public async Task<List<T>> GetList<T>() where T : class, new()
        {
            return await _connection.Table<T>().ToListAsync();
        }

        public async Task<bool> IsItemUsed<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            try
            {
                var item = await _connection.Table<T>().FirstOrDefaultAsync(predicate);
                return item != null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

    }
}
