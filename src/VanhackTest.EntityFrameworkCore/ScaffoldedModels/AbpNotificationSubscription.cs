using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpNotificationSubscription
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public string EntityId { get; set; }
        public string EntityTypeAssemblyQualifiedName { get; set; }
        public string EntityTypeName { get; set; }
        public string NotificationName { get; set; }
        public int? TenantId { get; set; }
        public long UserId { get; set; }
    }
}
