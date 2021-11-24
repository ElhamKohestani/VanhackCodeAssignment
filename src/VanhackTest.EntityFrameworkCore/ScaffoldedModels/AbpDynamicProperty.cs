using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpDynamicProperty
    {
        public AbpDynamicProperty()
        {
            AbpDynamicEntityProperties = new HashSet<AbpDynamicEntityProperty>();
            AbpDynamicPropertyValues = new HashSet<AbpDynamicPropertyValue>();
        }

        public int Id { get; set; }
        public string PropertyName { get; set; }
        public string InputType { get; set; }
        public string Permission { get; set; }
        public int? TenantId { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<AbpDynamicEntityProperty> AbpDynamicEntityProperties { get; set; }
        public virtual ICollection<AbpDynamicPropertyValue> AbpDynamicPropertyValues { get; set; }
    }
}
