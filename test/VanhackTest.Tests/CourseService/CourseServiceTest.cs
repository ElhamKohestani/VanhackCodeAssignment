using Abp.UI;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;
using VanhackTest.CourseServices.V1;
using VanhackTest.CourseServices.V1.DTOs;
using VanhackTest.EntityFrameworkCore;
using Xunit;

namespace VanhackTest.Tests.CourseService
{
    public class CourseServiceTest : VanhackTestTestBase
    {
        private readonly ICourseService courseService;
        public CourseServiceTest()
        {
            courseService = LocalIocManager.Resolve<ICourseService>();
        }

        [Fact]
        public async Task CreateCourse_Test()
        {
            // Act
            await courseService.AddCourse(
                new CourseCreateDto()
                {
                    CourseTitle = "CC TITLE",
                    CourseDescription = "Description of the course",
                    CourseCategoryId =1
                });



            await UsingDbContextAsync(async context =>
            {
                var addedCourse =  context.Courses.Where(c => c.Title == "CC TITLE").Single();
                addedCourse.ShouldNotBeNull();
            });
        }
    }
}
