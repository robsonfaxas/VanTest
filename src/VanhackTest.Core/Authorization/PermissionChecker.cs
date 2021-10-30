using Abp.Authorization;
using VanhackTest.Authorization.Roles;
using VanhackTest.Authorization.Users;

namespace VanhackTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
