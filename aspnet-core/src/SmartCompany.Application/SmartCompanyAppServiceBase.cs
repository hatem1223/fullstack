using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using SmartCompany.Authorization.Users;
using SmartCompany.MultiTenancy;

namespace SmartCompany
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SmartCompanyAppServiceBase : Abp.Application.Services.ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected SmartCompanyAppServiceBase()
        {
            LocalizationSourceName = SmartCompanyConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
