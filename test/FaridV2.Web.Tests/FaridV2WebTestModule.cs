using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FaridV2.EntityFrameworkCore;
using FaridV2.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FaridV2.Web.Tests
{
    [DependsOn(
        typeof(FaridV2WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FaridV2WebTestModule : AbpModule
    {
        public FaridV2WebTestModule(FaridV2EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FaridV2WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FaridV2WebMvcModule).Assembly);
        }
    }
}