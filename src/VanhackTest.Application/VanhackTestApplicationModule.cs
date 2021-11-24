using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using VanhackTest.Authorization;
using VanhackTest.Core.Entities;
using VanhackTest.CourseServices.V1.DTOs;


namespace VanhackTest
{
    [DependsOn(
        typeof(VanhackTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class VanhackTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<VanhackTestAuthorizationProvider>();




        }

        public override void Initialize()
        {
            var thisAssembly = typeof(VanhackTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

            
        }
    }
}
