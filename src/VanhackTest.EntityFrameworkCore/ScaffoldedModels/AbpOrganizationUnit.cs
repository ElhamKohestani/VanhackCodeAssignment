using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpOrganizationUnit
    {
        public AbpOrganizationUnit()
        {
            InverseParent = new HashSet<AbpOrganizationUnit>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public long? ParentId { get; set; }
        public int? TenantId { get; set; }

        public virtual AbpOrganizationUnit Parent { get; set; }
        public virtual ICollection<AbpOrganizationUnit> InverseParent { get; set; }
    }
}
