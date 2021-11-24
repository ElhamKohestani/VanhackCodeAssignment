using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class CourseRecording
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
    }
}
