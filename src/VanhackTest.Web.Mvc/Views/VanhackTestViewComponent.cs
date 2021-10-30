using Abp.AspNetCore.Mvc.ViewComponents;

namespace VanhackTest.Web.Views
{
    public abstract class VanhackTestViewComponent : AbpViewComponent
    {
        protected VanhackTestViewComponent()
        {
            LocalizationSourceName = VanhackTestConsts.LocalizationSourceName;
        }
    }
}
