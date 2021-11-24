using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpEdition
    {
        public AbpEdition()
        {
            AbpFeatures = new HashSet<AbpFeature>();
            AbpTenants = new HashSet<AbpTenant>();
        }

        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AbpFeature> AbpFeatures { get; set; }
        public virtual ICollection<AbpTenant> AbpTenants { get; set; }
    }
}
