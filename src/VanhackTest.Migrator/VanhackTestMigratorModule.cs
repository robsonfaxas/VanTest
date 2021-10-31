using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VanhackTest.Configuration;
using VanhackTest.EntityFrameworkCore;
using VanhackTest.Migrator.DependencyInjection;

namespace VanhackTest.Migrator
{
    [DependsOn(typeof(VanhackTestEntityFrameworkModule))]
    public class VanhackTestMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public VanhackTestMigratorModule(VanhackTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(VanhackTestMigratorModule).GetAssembly().GetDirectoryPathOrNull(), addUserSecrets : true
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                VanhackTestConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VanhackTestMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
