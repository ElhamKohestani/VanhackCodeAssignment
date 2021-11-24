using System;
using System.Collections.Generic;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class AbpUser
    {
        public AbpUser()
        {
            AbpPermissions = new HashSet<AbpPermission>();
            AbpRoleCreatorUsers = new HashSet<AbpRole>();
            AbpRoleDeleterUsers = new HashSet<AbpRole>();
            AbpRoleLastModifierUsers = new HashSet<AbpRole>();
            AbpSettings = new HashSet<AbpSetting>();
            AbpTenantCreatorUsers = new HashSet<AbpTenant>();
            AbpTenantDeleterUsers = new HashSet<AbpTenant>();
            AbpTenantLastModifierUsers = new HashSet<AbpTenant>();
            AbpUserClaims = new HashSet<AbpUserClaim>();
            AbpUserLogins = new HashSet<AbpUserLogin>();
            AbpUserRoles = new HashSet<AbpUserRole>();
            AbpUserTokens = new HashSet<AbpUserToken>();
            InverseCreatorUser = new HashSet<AbpUser>();
            InverseDeleterUser = new HashSet<AbpUser>();
            InverseLastModifierUser = new HashSet<AbpUser>();
        }

        public long Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string AuthenticationSource { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public string EmailAddress { get; set; }
        public string EmailConfirmationCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsLockoutEnabled { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string Name { get; set; }
        public string NormalizedEmailAddress { get; set; }
        public string NormalizedUserName { get; set; }
        public string Password { get; set; }
        public string PasswordResetCode { get; set; }
        public string PhoneNumber { get; set; }
        public string SecurityStamp { get; set; }
        public string Surname { get; set; }
        public int? TenantId { get; set; }
        public string UserName { get; set; }

        public virtual AbpUser CreatorUser { get; set; }
        public virtual AbpUser DeleterUser { get; set; }
        public virtual AbpUser LastModifierUser { get; set; }
        public virtual ICollection<AbpPermission> AbpPermissions { get; set; }
        public virtual ICollection<AbpRole> AbpRoleCreatorUsers { get; set; }
        public virtual ICollection<AbpRole> AbpRoleDeleterUsers { get; set; }
        public virtual ICollection<AbpRole> AbpRoleLastModifierUsers { get; set; }
        public virtual ICollection<AbpSetting> AbpSettings { get; set; }
        public virtual ICollection<AbpTenant> AbpTenantCreatorUsers { get; set; }
        public virtual ICollection<AbpTenant> AbpTenantDeleterUsers { get; set; }
        public virtual ICollection<AbpTenant> AbpTenantLastModifierUsers { get; set; }
        public virtual ICollection<AbpUserClaim> AbpUserClaims { get; set; }
        public virtual ICollection<AbpUserLogin> AbpUserLogins { get; set; }
        public virtual ICollection<AbpUserRole> AbpUserRoles { get; set; }
        public virtual ICollection<AbpUserToken> AbpUserTokens { get; set; }
        public virtual ICollection<AbpUser> InverseCreatorUser { get; set; }
        public virtual ICollection<AbpUser> InverseDeleterUser { get; set; }
        public virtual ICollection<AbpUser> InverseLastModifierUser { get; set; }
    }
}
