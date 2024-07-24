using Abp.Authorization;
using FaridV2.Authorization.Roles;
using FaridV2.Authorization.Users;

namespace FaridV2.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
