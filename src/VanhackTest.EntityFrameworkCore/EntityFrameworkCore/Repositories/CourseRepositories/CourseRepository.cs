using Abp.Authorization.Users;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;
using VanhackTest.Core.RepositoryAbstractions;
using Abp.EntityFrameworkCore.Repositories;

namespace VanhackTest.EntityFrameworkCore.Repositories.CourseRepositories
{
    public class CourseRepository :VanhackTestRepositoryBase<Course, int>, ICourseRepository
    {
       

        public CourseRepository(
            IDbContextProvider<VanhackTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
           
        }


        public async Task<bool> IsCourseAccessGranted(long UserID, int CourseID)
        {

            var _context = (VanhackTestDbContext)(await GetDbContextAsync());

            List<int> userRolesIds = await _context.UserRoles.Where(u => u.UserId == UserID).Select(r => r.RoleId).ToListAsync();
            List<int> courseAccessLevelsIDs = await _context.CourseAccessLevels.Where(cal => cal.CourseId == CourseID).Select(c => c.RoleId).ToListAsync();


            // if the user has at least one access level of the course

            if (userRolesIds.Intersect(courseAccessLevelsIDs).Any())
                return true;
            else
                return false;

        }


    }

    //public class CourseRepository : VanhackTestRepositoryBase<Course, int>, ICourseRepository
    //{
    //    private VanhackTestDbContext _context;

    //    public CourseRepository(VanhackTestDbContext context,
    //        IDbContextProvider<VanhackTestDbContext> dbContextProvider) : base(dbContextProvider)
    //    {
    //        _context = context;
    //    }


    //    public async Task<bool> IsCourseAccessGranted(int UserID, int CourseID)
    //    {



    //        List<int> userRolesIds = await _context.UserRoles.Where(u => u.UserId == UserID).Select(r => r.RoleId).ToListAsync();
    //        List<int> courseAccessLevelsIDs = await _context.CourseAccessLevels.Where(cal => cal.CourseId == CourseID).Select(c => c.RoleId).ToListAsync();


    //        // if the user has at least one access level of the course

    //        if (userRolesIds.Intersect(courseAccessLevelsIDs).Any())
    //            return true;
    //        else
    //            return false;

    //    }


    //}
}
