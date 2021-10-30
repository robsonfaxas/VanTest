using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace VanhackTest.Controllers
{
    public abstract class VanhackTestControllerBase: AbpController
    {
        protected VanhackTestControllerBase()
        {
            LocalizationSourceName = VanhackTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
