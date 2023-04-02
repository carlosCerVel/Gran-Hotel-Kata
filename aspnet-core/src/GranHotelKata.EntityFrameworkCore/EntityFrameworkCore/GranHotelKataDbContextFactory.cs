using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using GranHotelKata.Configuration;
using GranHotelKata.Web;

namespace GranHotelKata.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class GranHotelKataDbContextFactory : IDesignTimeDbContextFactory<GranHotelKataDbContext>
    {
        public GranHotelKataDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GranHotelKataDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            GranHotelKataDbContextConfigurer.Configure(builder, configuration.GetConnectionString(GranHotelKataConsts.ConnectionStringName));

            return new GranHotelKataDbContext(builder.Options);
        }
    }
}
