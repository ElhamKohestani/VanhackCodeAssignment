
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanhackTest.CourseServices.V1.DTOs
{

    public class CourseDto
    {

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public short? CourseCategoryId { get; set; }
        public string CategoryText { get; set; }
       

    }
}
