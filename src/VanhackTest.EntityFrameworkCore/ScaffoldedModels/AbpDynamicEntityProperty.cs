using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpDynamicEntityProperty
    {
        public AbpDynamicEntityProperty()
        {
            AbpDynamicEntityPropertyValues = new HashSet<AbpDynamicEntityPropertyValue>();
        }

        public int Id { get; set; }
        public string EntityFullName { get; set; }
        public int DynamicPropertyId { get; set; }
        public int? TenantId { get; set; }

        public virtual AbpDynamicProperty DynamicProperty { get; set; }
        public virtual ICollection<AbpDynamicEntityPropertyValue> AbpDynamicEntityPropertyValues { get; set; }
    }
}
