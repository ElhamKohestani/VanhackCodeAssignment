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
using VanhackTest.Authorization.Roles;
using Abp.Authorization.Users;
using VanhackTest.Authorization.Users;
using Abp.UI;
using Microsoft.AspNetCore.Identity;
using VanhackTest.EntityFrameworkCore.Repositories.CourseRepositories;
using VanhackTest.Core.RepositoryAbstractions;

namespace VanhackTest.CourseServices.V1
{

    [AbpAuthorize]
    public class CourseService : VanhackTestAppServiceBase, ICourseService
    {
        private IMapper _mapper;
        private ICourseRepository _repo;
        //private IRepository<Course, int> _repo;
        // CAL stands for Course Access Level
        //private IRepository<CourseAccessLevel, int> _CALRepo;

     


        public CourseService(//IRepository<Course, int> repo,
            IMapper mapper, ICourseRepository courseRepository) 
        {

            //_repo = repo;
            _mapper = mapper;
            _repo = courseRepository;
            //_CALRepo = calRepo;
            


        }



        public async Task AddCourse(CourseCreateDto request)
        {

            try
            {

                

                Course cc = new Course()
                {
                    CreatedBy = (await GetCurrentUserAsync()).Id,
                    CreatedOn = DateTime.Now
                };

                _mapper.Map(request, cc);


              
              

                await _repo.InsertAsync(cc);

            }
            catch (Exception ex)
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
            catch (Exception ex)
            {

            }

        }
        // Implemented the course access level in this endpoint
        public async Task<CourseDto> GetCourse(int Id)
        {

            long UserId = (await GetCurrentUserAsync()).Id;

            if (await _repo.IsCourseAccessGranted(UserID: UserId, CourseID:Id))
            {
                return _mapper.Map(await _repo.GetAsync(Id), new CourseDto());
            }
            else
            {
                throw new UserFriendlyException("Course access denied");
            }



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
