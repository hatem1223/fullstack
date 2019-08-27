using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SmartCompany.Configuration;
using SmartCompany.Web;

namespace SmartCompany.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SmartCompanyDbContextFactory : IDesignTimeDbContextFactory<SmartCompanyDbContext>
    {
        public SmartCompanyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SmartCompanyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SmartCompanyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SmartCompanyConsts.ConnectionStringName));

            return new SmartCompanyDbContext(builder.Options);
        }
    }
}
