using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SmartCompany.Controllers
{
    public abstract class SmartCompanyControllerBase: AbpController
    {
        protected SmartCompanyControllerBase()
        {
            LocalizationSourceName = SmartCompanyConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
