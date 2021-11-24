using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable
namespace VanhackTest.Core.Entities
{
    public partial class CourseAccessLevel : IEntity<int>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int RoleId { get; set; }

        public virtual Course Course { get; set; }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
