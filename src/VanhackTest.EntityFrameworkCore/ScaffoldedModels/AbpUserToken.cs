using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpUserToken
    {
        public long Id { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }
        public string Value { get; set; }
        public DateTime? ExpireDate { get; set; }

        public virtual AbpUser User { get; set; }
    }
}
