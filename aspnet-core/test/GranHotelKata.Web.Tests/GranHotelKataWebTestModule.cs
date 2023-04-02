using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GranHotelKata.EntityFrameworkCore;
using GranHotelKata.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace GranHotelKata.Web.Tests
{
    [DependsOn(
        typeof(GranHotelKataWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class GranHotelKataWebTestModule : AbpModule
    {
        public GranHotelKataWebTestModule(GranHotelKataEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GranHotelKataWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(GranHotelKataWebMvcModule).Assembly);
        }
    }
}