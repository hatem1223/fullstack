using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace SmartCompany.Authorization
{
    public class SmartCompanyAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Employees, L("Employees"));
            context.CreatePermission(PermissionNames.Pages_Department, L("Departments"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SmartCompanyConsts.LocalizationSourceName);
        }
    }
}
