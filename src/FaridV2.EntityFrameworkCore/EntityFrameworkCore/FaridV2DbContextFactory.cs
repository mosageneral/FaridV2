using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FaridV2.Configuration;
using FaridV2.Web;

namespace FaridV2.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FaridV2DbContextFactory : IDesignTimeDbContextFactory<FaridV2DbContext>
    {
        public FaridV2DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FaridV2DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FaridV2DbContextConfigurer.Configure(builder, configuration.GetConnectionString(FaridV2Consts.ConnectionStringName));

            return new FaridV2DbContext(builder.Options);
        }
    }
}
