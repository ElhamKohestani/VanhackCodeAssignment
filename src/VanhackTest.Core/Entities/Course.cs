using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.Core.Entities
{
    public partial class Course  : IEntity<int>
    {
        public Course()
        {
            CourseRecordings = new HashSet<CourseRecording>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short? CategoryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public virtual CourseCategory Category { get; set; }
        public virtual ICollection<CourseRecording> CourseRecordings { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
