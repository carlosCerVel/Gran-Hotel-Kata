using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GranHotelKata.Configuration;

namespace GranHotelKata.Web.Host.Startup
{
    [DependsOn(
       typeof(GranHotelKataWebCoreModule))]
    public class GranHotelKataWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public GranHotelKataWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GranHotelKataWebHostModule).GetAssembly());
        }
    }
}
