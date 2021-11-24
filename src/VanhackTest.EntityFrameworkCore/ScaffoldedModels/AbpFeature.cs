using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpFeature
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public string Discriminator { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? EditionId { get; set; }
        public int? TenantId { get; set; }

        public virtual AbpEdition Edition { get; set; }
    }
}
