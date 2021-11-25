using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;
using VanhackTest.Core.RepositoryAbstractions;
using VanhackTest.EntityFrameworkCore.Repositories.CourseRepositories;
using Xunit;

namespace VanhackTest.Tests.CourseService
{
    public class CourseRepositoryTest : VanhackTestTestBase
    {
        private const string COURSE_TITLE = "COURSE WITH AL";

        [Fact]
        public async void ShouldDenyAccess()
        {

            ICourseRepository courseRepository = LocalIocManager.Resolve<ICourseRepository>();



            List<Course> AddCoursesWithoutAccessLevel = new List<Course>();
            AddCoursesWithoutAccessLevel.Add(new Course() { 
                Title = "TITLE 1",
                Description = "DESC"
            });
            AddCoursesWithoutAccessLevel.Add(new Course()
            {
                Title = "TITLE 1",
                Description = "DESC"
            });

            await UsingDbContext(async context =>
           {
               await context.Courses.AddRangeAsync(AddCoursesWithoutAccessLevel);
           });

            List<Course> coursesWithoutAccessLevel = await UsingDbContextAsync(async context =>
            {
                return context.Courses.Where(c => c.CourseAccessLevels.Count() == 0).ToList();
            });

            var aSingleCourse = coursesWithoutAccessLevel.Any() ? coursesWithoutAccessLevel.First() : null;

            bool acces = await courseRepository.IsCourseAccessGranted(UserID: 1, CourseID: aSingleCourse.Id );

            acces.ShouldBe(false);

        }


        [Fact]
        public async void ShouldGrantAccess()
        {

            ICourseRepository courseRepository = LocalIocManager.Resolve<ICourseRepository>();

            long UserId = (await GetCurrentUserAsync()).Id;


            UsingDbContext(context =>
            {

                Course courseWithAccessLevel = new Course()
                {
                    Title = COURSE_TITLE,
                    Description = "DESC"
                };
             context.Courses.Add(courseWithAccessLevel);
               
            });

           
            UsingDbContext(context =>
            {
                 Course c =  context.Courses.Where(c => c.Title ==COURSE_TITLE).Single();

                context.CourseAccessLevels.Add(new CourseAccessLevel()
                {
                    CourseId = c.Id,
                    RoleId = 2
                });
            });


           Course c = UsingDbContext(context => context.Courses.Where(c => c.Title == COURSE_TITLE).Single());
           
            CourseAccessLevel cal = UsingDbContext(context => context.CourseAccessLevels.Where(c => c.CourseId == c.Id).Single());



            

            bool acces = await courseRepository.IsCourseAccessGranted(UserID: UserId, CourseID: c.Id);

            acces.ShouldBe(true);

        }
    }
}
