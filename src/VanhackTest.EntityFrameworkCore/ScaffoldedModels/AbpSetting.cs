using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpSetting
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string Name { get; set; }
        public int? TenantId { get; set; }
        public long? UserId { get; set; }
        public string Value { get; set; }

        public virtual AbpUser User { get; set; }
    }
}
