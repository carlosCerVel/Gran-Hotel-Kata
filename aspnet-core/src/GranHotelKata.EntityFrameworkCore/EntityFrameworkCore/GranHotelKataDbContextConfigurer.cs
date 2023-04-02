using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GranHotelKata.EntityFrameworkCore
{
    public static class GranHotelKataDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GranHotelKataDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<GranHotelKataDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
