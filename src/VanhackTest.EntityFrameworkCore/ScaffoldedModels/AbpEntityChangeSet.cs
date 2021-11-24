using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpEntityChangeSet
    {
        public AbpEntityChangeSet()
        {
            AbpEntityChanges = new HashSet<AbpEntityChange>();
        }

        public long Id { get; set; }
        public string BrowserInfo { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public DateTime CreationTime { get; set; }
        public string ExtensionData { get; set; }
        public int? ImpersonatorTenantId { get; set; }
        public long? ImpersonatorUserId { get; set; }
        public string Reason { get; set; }
        public int? TenantId { get; set; }
        public long? UserId { get; set; }

        public virtual ICollection<AbpEntityChange> AbpEntityChanges { get; set; }
    }
}
