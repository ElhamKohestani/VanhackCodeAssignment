using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpRole
    {
        public AbpRole()
        {
            AbpPermissions = new HashSet<AbpPermission>();
            AbpRoleClaims = new HashSet<AbpRoleClaim>();
        }

        public int Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DisplayName { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsStatic { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public int? TenantId { get; set; }
        public string Description { get; set; }

        public virtual AbpUser CreatorUser { get; set; }
        public virtual AbpUser DeleterUser { get; set; }
        public virtual AbpUser LastModifierUser { get; set; }
        public virtual ICollection<AbpPermission> AbpPermissions { get; set; }
        public virtual ICollection<AbpRoleClaim> AbpRoleClaims { get; set; }
    }
}
