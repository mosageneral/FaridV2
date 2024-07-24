using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace FaridV2.Controllers
{
    public abstract class FaridV2ControllerBase: AbpController
    {
        protected FaridV2ControllerBase()
        {
            LocalizationSourceName = FaridV2Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
