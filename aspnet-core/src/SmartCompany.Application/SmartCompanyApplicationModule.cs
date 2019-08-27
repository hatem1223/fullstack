using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using SmartCompany.Authorization;

namespace SmartCompany
{
    [DependsOn(
        typeof(SmartCompanyCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SmartCompanyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SmartCompanyAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SmartCompanyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
