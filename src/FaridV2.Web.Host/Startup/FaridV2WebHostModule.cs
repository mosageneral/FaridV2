using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FaridV2.Configuration;

namespace FaridV2.Web.Host.Startup
{
    [DependsOn(
       typeof(FaridV2WebCoreModule))]
    public class FaridV2WebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FaridV2WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FaridV2WebHostModule).GetAssembly());
        }
    }
}
