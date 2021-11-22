using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;

namespace VanhackTest.EntityFrameworkCore.Repositories
{
    public class CourseRepository : VanhackTestRepositoryBase<Course, int>
    {
        private VanhackTestDbContext _context;

        public CourseRepository(VanhackTestDbContext context,
            IDbContextProvider<VanhackTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _context = context;
        }
        public Task<int> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetAllCoursesAsync() => 
            await _context.Courses.ToListAsync();


        public async Task<Course> GetCourse(int id) => 
            await _context.Courses.Where(c => c.Id == id).SingleAsync();
        

        public async Task InsertCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public Task UpdateCourse()
        {
            throw new NotImplementedException();
        }
    }
}
