using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.Core.Entities
{
    public partial class CourseRecording : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Order { get; set; }
        public string Link { get; set; }
        public int? CourseId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public virtual Course Course { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
