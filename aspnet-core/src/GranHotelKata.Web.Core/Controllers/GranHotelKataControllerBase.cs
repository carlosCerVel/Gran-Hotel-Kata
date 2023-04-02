using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace GranHotelKata.Controllers
{
    public abstract class GranHotelKataControllerBase: AbpController
    {
        protected GranHotelKataControllerBase()
        {
            LocalizationSourceName = GranHotelKataConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
