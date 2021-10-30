using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VanhackTest.EntityFrameworkCore;
using VanhackTest.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace VanhackTest.Web.Tests
{
    [DependsOn(
        typeof(VanhackTestWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class VanhackTestWebTestModule : AbpModule
    {
        public VanhackTestWebTestModule(VanhackTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VanhackTestWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(VanhackTestWebMvcModule).Assembly);
        }
    }
}