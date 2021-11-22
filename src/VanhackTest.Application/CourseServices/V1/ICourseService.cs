using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.CourseServices.V1.DTOs;
using VanhackTest.ServiceDTOs;


namespace VanhackTest.CourseServices.V1
{
    public interface ICourseService : IApplicationService
    {
        Task<List<CourseDto>> GetAllCourses();
        Task<CourseDto> GetCourse(int Id);
        Task EditCourse(CourseDto course);
        Task AddCourse(CourseCreateDto course);
        Task RemoveCourse(int Id);
    }
}
