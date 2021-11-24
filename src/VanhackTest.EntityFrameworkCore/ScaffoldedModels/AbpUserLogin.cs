using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpUserLogin
    {
        public long Id { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }

        public virtual AbpUser User { get; set; }
    }
}
