using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace VanhackTest.EntityFrameworkCore
{
    public static class VanhackTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<VanhackTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<VanhackTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
