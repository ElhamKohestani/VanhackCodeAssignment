using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;

namespace VanhackTest.Core.RepositoryAbstractions
{
  public interface ICourseRepository :IRepository<Course, int>
    {
        Task<bool> IsCourseAccessGranted(long UserID, int CourseID);
    }
}
