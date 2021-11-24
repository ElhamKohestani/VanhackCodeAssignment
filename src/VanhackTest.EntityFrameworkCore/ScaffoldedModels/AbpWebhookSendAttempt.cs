using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpWebhookSendAttempt
    {
        public Guid Id { get; set; }
        public Guid WebhookEventId { get; set; }
        public Guid WebhookSubscriptionId { get; set; }
        public string Response { get; set; }
        public int? ResponseStatusCode { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? TenantId { get; set; }

        public virtual AbpWebhookEvent WebhookEvent { get; set; }
    }
}
