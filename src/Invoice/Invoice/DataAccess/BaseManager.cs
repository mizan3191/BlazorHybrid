//namespace Invoice.DataAccess
//{
//    public class BaseManager
//    {

//        public async Task Create<T>(T entity)
//        {
//            await _connection.InsertAsync(entity);
//        }
//        public async Task Update<T>(T entity)
//        {
//            await _connection.UpdateAsync(entity);
//        }

//        public async Task Delete<T>(T entity)
//        {
//            await _connection.DeleteAsync(entity);
//        }
//        public async Task<List<T>> GetList<T>() where T : class, new()
//        {
//            return await _connection.Table<T>().ToListAsync();
//        }
//    }
//}
