using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GranHotelKata.Authorization;

namespace GranHotelKata
{
    [DependsOn(
        typeof(GranHotelKataCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class GranHotelKataApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<GranHotelKataAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(GranHotelKataApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
