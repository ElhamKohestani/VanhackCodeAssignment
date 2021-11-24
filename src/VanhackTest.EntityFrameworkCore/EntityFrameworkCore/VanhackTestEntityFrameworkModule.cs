using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using VanhackTest.Core.Entities;
using VanhackTest.EntityFrameworkCore.Seed;
using VanhackTest.EntityFrameworkCore.Repositories;

using VanhackTest.Core.RepositoryAbstractions;
using VanhackTest.EntityFrameworkCore.Repositories.CourseRepositories;
using Castle.MicroKernel.Registration;
using Abp.Configuration.Startup;

namespace VanhackTest.EntityFrameworkCore
{
    [DependsOn(
        typeof(VanhackTestCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class VanhackTestEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {


            Configuration.ReplaceService<IRepository<Course, int>>(() =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IRepository<Course, int>, ICourseRepository, CourseRepository>()
                        .ImplementedBy<CourseRepository>()
                        .LifestyleTransient()
                );
            });


            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<VanhackTestDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        VanhackTestDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        VanhackTestDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(VanhackTestEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
