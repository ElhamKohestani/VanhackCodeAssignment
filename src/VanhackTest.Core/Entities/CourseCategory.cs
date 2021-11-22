using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.Core.Entities
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            Courses = new HashSet<Course>();
        }

        public short Id { get; set; }
        public string CategoryIdentifier { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
