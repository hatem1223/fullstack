using Abp.Authorization;
using SmartCompany.Authorization.Roles;
using SmartCompany.Authorization.Users;

namespace SmartCompany.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
