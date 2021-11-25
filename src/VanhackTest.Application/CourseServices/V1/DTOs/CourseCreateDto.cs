using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanhackTest.Core.Entities;

namespace VanhackTest.CourseServices.V1.DTOs
{
   public class CourseCreateDto
    {
        
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public short? CourseCategoryId { get; set; }
     
        public List<int> AccessLevel { get; set; }

    }
}
