using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Authorization;
using VanhackTest.Interface;
using Abp.Application.Services;
using VanhackTest.Authorization;
using VanhackTest.ServiceDTOs;
using Abp.Domain.Repositories;
using VanhackTest.Core.Entities;
using VanhackTest.CourseServices.V1.DTOs;
using AutoMapper;

namespace VanhackTest.CourseServices.V1
{
    
    [AbpAuthorize(PermissionNames.Pages_Courses)]
    public class CourseService : VanhackTestAppServiceBase, ICourseService
    {
        private IRepository<Course, int> _repo;
        private IMapper _mapper;

        public CourseService(IRepository<Course, int> repo, IMapper mapper)
        {
            
            _repo = repo;
            _mapper = mapper;
            
        }
       
        public async Task AddCourse(CourseCreateDto request)
        {

            try
            {
                await _repo.InsertAsync(_mapper.Map(request, new Course()
                {
                    CreatedBy = (await GetCurrentUserAsync()).Id,
                    CreatedOn = DateTime.Now

                }));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task EditCourse(CourseDto request)
        {
            try
            {
                Course course = await _repo.GetAsync(request.CourseId);
                await _repo.UpdateAsync(course);
            }
            catch(Exception ex)
            {

            }
           
        }

        public async Task<CourseDto> GetCourse(int Id)
        {
            return _mapper.Map(await _repo.GetAsync(Id), new CourseDto());
            
        }


        public async Task<List<CourseDto>> GetAllCourses() =>
                       (from course in (await _repo.GetAllListAsync()).AsQueryable()
                        select _mapper.Map(course, new CourseDto())).ToList();


        /// <summary>
        /// Delete a course record from database with cascading referential integrity resulting
        /// in removal of related course recordings.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task RemoveCourse(int Id)
        {
            await _repo.DeleteAsync(Id);            
        }
    }
}
