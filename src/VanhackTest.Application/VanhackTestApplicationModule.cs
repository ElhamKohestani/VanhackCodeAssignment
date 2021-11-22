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

            //Configuration.Modules.AbpAutoMapper().Configurators.Add(
            //    // Scan the assembly for classes which inherit from AutoMapper.Profile
            //    cfg => cfg.AddMaps(thisAssembly)
            //);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(conf =>
            {
                conf.CreateMap<CourseRecordingCreateDTO, CourseRecording>()
                .ForMember(c => c.Id, options => options.Ignore())
                .ForMember(c => c.Title, options => options.MapFrom(d => d.RecordingTitle))
                .ForMember(c => c.Description, options => options.MapFrom(d => d.RecordingDescription))
                .ForMember(c => c.Order, options => options.MapFrom(d => d.RecordingOrder))
                .ForMember(c => c.Link, options => options.MapFrom(d => d.RecordingLink))
                .ForMember(c => c.CourseId, options => options.MapFrom(d => d.CourseId))
                .ForMember(c => c.CreatedBy, options => options.Ignore())
                .ForMember(c => c.CreatedOn, options => options.Ignore())
                .ReverseMap();

                conf.CreateMap<CourseRecordingDTO, CourseRecording>()
                .ForMember(c => c.Id, options => options.MapFrom(d => d.RecordingId))
                .ForMember(c => c.Title, options => options.MapFrom(d => d.RecordingTitle))
                .ForMember(c => c.Description, options => options.MapFrom(d => d.RecordingDescription))
                .ForMember(c => c.Order, options => options.MapFrom(d => d.RecordingOrder))
                .ForMember(c => c.Link, options => options.MapFrom(d => d.RecordingLink))
                .ForMember(c => c.CourseId, options => options.MapFrom(d => d.CourseId))
                .ForMember(c => c.CreatedBy, options => options.Ignore())
                .ForMember(c => c.CreatedOn, options => options.Ignore())
                .ReverseMap();

                conf.CreateMap<CourseDto, Course>()
                .ForMember(c => c.Id, options => options.MapFrom(d => d.CourseId))
                .ForMember(c => c.Title, options => options.MapFrom(d => d.CourseTitle))
                .ForMember(c => c.Description, options => options.MapFrom(d => d.CourseDescription))
                .ForMember(c => c.CategoryId , options => options.MapFrom(d=> d.CourseCategoryId))
                .ForMember(c => c.CreatedBy, options => options.Ignore())
                .ForMember(c => c.CreatedOn, options => options.Ignore())
                .ReverseMap();

                conf.CreateMap<CourseCreateDto, Course>()
              .ForMember(c => c.Title, options => options.MapFrom(d => d.CourseTitle))
              .ForMember(c => c.Description, options => options.MapFrom(d => d.CourseDescription))
              .ForMember(c => c.CategoryId, options => options.MapFrom(d => d.CourseCategoryId))
              .ForMember(c => c.CreatedBy, options => options.Ignore())
              .ForMember(c => c.CreatedOn, options => options.Ignore())
              .ReverseMap();








            });
        }
    }
}
