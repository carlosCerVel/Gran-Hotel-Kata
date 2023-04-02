using Abp.Authorization;
using GranHotelKata.Authorization.Roles;
using GranHotelKata.Authorization.Users;

namespace GranHotelKata.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
