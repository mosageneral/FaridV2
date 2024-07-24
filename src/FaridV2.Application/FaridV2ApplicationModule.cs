using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FaridV2.Authorization;

namespace FaridV2
{
    [DependsOn(
        typeof(FaridV2CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FaridV2ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FaridV2AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FaridV2ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
