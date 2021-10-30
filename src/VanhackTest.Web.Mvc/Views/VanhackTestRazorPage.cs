using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace VanhackTest.Web.Views
{
    public abstract class VanhackTestRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected VanhackTestRazorPage()
        {
            LocalizationSourceName = VanhackTestConsts.LocalizationSourceName;
        }
    }
}
