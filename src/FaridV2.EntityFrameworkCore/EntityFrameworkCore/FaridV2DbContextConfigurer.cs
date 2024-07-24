using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FaridV2.EntityFrameworkCore
{
    public static class FaridV2DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FaridV2DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FaridV2DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
