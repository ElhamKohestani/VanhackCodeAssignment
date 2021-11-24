using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpUserRole
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int RoleId { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }

        public virtual AbpUser User { get; set; }
    }
}
