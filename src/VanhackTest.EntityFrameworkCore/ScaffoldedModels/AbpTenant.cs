using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpTenant
    {
        public int Id { get; set; }
        public string ConnectionString { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public int? EditionId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string Name { get; set; }
        public string TenancyName { get; set; }

        public virtual AbpUser CreatorUser { get; set; }
        public virtual AbpUser DeleterUser { get; set; }
        public virtual AbpEdition Edition { get; set; }
        public virtual AbpUser LastModifierUser { get; set; }
    }
}
