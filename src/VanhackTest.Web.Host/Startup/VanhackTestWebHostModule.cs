using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VanhackTest.Configuration;

namespace VanhackTest.Web.Host.Startup
{
    [DependsOn(
       typeof(VanhackTestWebCoreModule))]
    public class VanhackTestWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public VanhackTestWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VanhackTestWebHostModule).GetAssembly());
        }
    }
}
