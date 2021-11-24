using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class CourseAccessLevel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int RoleId { get; set; }

        public virtual Course Course { get; set; }
    }
}
