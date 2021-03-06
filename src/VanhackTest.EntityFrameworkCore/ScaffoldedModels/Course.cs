using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class Course
    {
        public Course()
        {
            CourseAccessLevels = new HashSet<CourseAccessLevel>();
            CourseRecordings = new HashSet<CourseRecording>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short? CategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public virtual CourseCategory Category { get; set; }
        public virtual ICollection<CourseAccessLevel> CourseAccessLevels { get; set; }
        public virtual ICollection<CourseRecording> CourseRecordings { get; set; }
    }
}
