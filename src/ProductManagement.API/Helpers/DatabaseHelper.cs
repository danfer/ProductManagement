using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Persistence;

namespace ProductManagement.API.Helpers
{
    public class DatabaseHelper
    {
        public static void EnsureDatabaseCreated(SqliteConnection conn)
        {
            var builder = new DbContextOptionsBuilder<ProductManagementDbContext>();
            builder.UseSqlite(conn);

            using var context = new ProductManagementDbContext(builder.Options);
            context.Database.EnsureCreated();
        }
    }
}
