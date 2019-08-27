using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartCompany.Configuration;

namespace SmartCompany.Web.Host.Startup
{
    [DependsOn(
       typeof(SmartCompanyWebCoreModule))]
    public class SmartCompanyWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SmartCompanyWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SmartCompanyWebHostModule).GetAssembly());
        }
    }
}
