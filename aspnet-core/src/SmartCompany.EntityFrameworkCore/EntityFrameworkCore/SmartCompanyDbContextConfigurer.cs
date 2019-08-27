using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SmartCompany.EntityFrameworkCore
{
    public static class SmartCompanyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SmartCompanyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SmartCompanyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
