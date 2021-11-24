using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VanhackTest.ScaffoldedModels
{
    public partial class BaseCodeTestContext : DbContext
    {
        public BaseCodeTestContext()
        {
        }

        public BaseCodeTestContext(DbContextOptions<BaseCodeTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbpAuditLog> AbpAuditLogs { get; set; }
        public virtual DbSet<AbpBackgroundJob> AbpBackgroundJobs { get; set; }
        public virtual DbSet<AbpDynamicEntityProperty> AbpDynamicEntityProperties { get; set; }
        public virtual DbSet<AbpDynamicEntityPropertyValue> AbpDynamicEntityPropertyValues { get; set; }
        public virtual DbSet<AbpDynamicProperty> AbpDynamicProperties { get; set; }
        public virtual DbSet<AbpDynamicPropertyValue> AbpDynamicPropertyValues { get; set; }
        public virtual DbSet<AbpEdition> AbpEditions { get; set; }
        public virtual DbSet<AbpEntityChange> AbpEntityChanges { get; set; }
        public virtual DbSet<AbpEntityChangeSet> AbpEntityChangeSets { get; set; }
        public virtual DbSet<AbpEntityPropertyChange> AbpEntityPropertyChanges { get; set; }
        public virtual DbSet<AbpFeature> AbpFeatures { get; set; }
        public virtual DbSet<AbpLanguage> AbpLanguages { get; set; }
        public virtual DbSet<AbpLanguageText> AbpLanguageTexts { get; set; }
        public virtual DbSet<AbpNotification> AbpNotifications { get; set; }
        public virtual DbSet<AbpNotificationSubscription> AbpNotificationSubscriptions { get; set; }
        public virtual DbSet<AbpOrganizationUnit> AbpOrganizationUnits { get; set; }
        public virtual DbSet<AbpOrganizationUnitRole> AbpOrganizationUnitRoles { get; set; }
        public virtual DbSet<AbpPermission> AbpPermissions { get; set; }
        public virtual DbSet<AbpRole> AbpRoles { get; set; }
        public virtual DbSet<AbpRoleClaim> AbpRoleClaims { get; set; }
        public virtual DbSet<AbpSetting> AbpSettings { get; set; }
        public virtual DbSet<AbpTenant> AbpTenants { get; set; }
        public virtual DbSet<AbpTenantNotification> AbpTenantNotifications { get; set; }
        public virtual DbSet<AbpUser> AbpUsers { get; set; }
        public virtual DbSet<AbpUserAccount> AbpUserAccounts { get; set; }
        public virtual DbSet<AbpUserClaim> AbpUserClaims { get; set; }
        public virtual DbSet<AbpUserLogin> AbpUserLogins { get; set; }
        public virtual DbSet<AbpUserLoginAttempt> AbpUserLoginAttempts { get; set; }
        public virtual DbSet<AbpUserNotification> AbpUserNotifications { get; set; }
        public virtual DbSet<AbpUserOrganizationUnit> AbpUserOrganizationUnits { get; set; }
        public virtual DbSet<AbpUserRole> AbpUserRoles { get; set; }
        public virtual DbSet<AbpUserToken> AbpUserTokens { get; set; }
        public virtual DbSet<AbpWebhookEvent> AbpWebhookEvents { get; set; }
        public virtual DbSet<AbpWebhookSendAttempt> AbpWebhookSendAttempts { get; set; }
        public virtual DbSet<AbpWebhookSubscription> AbpWebhookSubscriptions { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseAccessLevel> CourseAccessLevels { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<CourseRecording> CourseRecordings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\S17; Database=BaseCodeTest; User ID=sa; Password=kasperskyantigeral");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AbpAuditLog>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.ExecutionDuration }, "IX_AbpAuditLogs_TenantId_ExecutionDuration");

                entity.HasIndex(e => new { e.TenantId, e.ExecutionTime }, "IX_AbpAuditLogs_TenantId_ExecutionTime");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpAuditLogs_TenantId_UserId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.CustomData).HasMaxLength(2000);

                entity.Property(e => e.Exception).HasMaxLength(2000);

                entity.Property(e => e.ExceptionMessage).HasMaxLength(1024);

                entity.Property(e => e.MethodName).HasMaxLength(256);

                entity.Property(e => e.Parameters).HasMaxLength(1024);

                entity.Property(e => e.ServiceName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpBackgroundJob>(entity =>
            {
                entity.HasIndex(e => new { e.IsAbandoned, e.NextTryTime }, "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime");

                entity.Property(e => e.JobArgs).IsRequired();

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<AbpDynamicEntityProperty>(entity =>
            {
                entity.HasIndex(e => e.DynamicPropertyId, "IX_AbpDynamicEntityProperties_DynamicPropertyId");

                entity.HasIndex(e => new { e.EntityFullName, e.DynamicPropertyId, e.TenantId }, "IX_AbpDynamicEntityProperties_EntityFullName_DynamicPropertyId_TenantId")
                    .IsUnique()
                    .HasFilter("([EntityFullName] IS NOT NULL AND [TenantId] IS NOT NULL)");

                entity.Property(e => e.EntityFullName).HasMaxLength(256);

                entity.HasOne(d => d.DynamicProperty)
                    .WithMany(p => p.AbpDynamicEntityProperties)
                    .HasForeignKey(d => d.DynamicPropertyId);
            });

            modelBuilder.Entity<AbpDynamicEntityPropertyValue>(entity =>
            {
                entity.HasIndex(e => e.DynamicEntityPropertyId, "IX_AbpDynamicEntityPropertyValues_DynamicEntityPropertyId");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.DynamicEntityProperty)
                    .WithMany(p => p.AbpDynamicEntityPropertyValues)
                    .HasForeignKey(d => d.DynamicEntityPropertyId);
            });

            modelBuilder.Entity<AbpDynamicProperty>(entity =>
            {
                entity.HasIndex(e => new { e.PropertyName, e.TenantId }, "IX_AbpDynamicProperties_PropertyName_TenantId")
                    .IsUnique()
                    .HasFilter("([PropertyName] IS NOT NULL AND [TenantId] IS NOT NULL)");

                entity.Property(e => e.PropertyName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpDynamicPropertyValue>(entity =>
            {
                entity.HasIndex(e => e.DynamicPropertyId, "IX_AbpDynamicPropertyValues_DynamicPropertyId");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.DynamicProperty)
                    .WithMany(p => p.AbpDynamicPropertyValues)
                    .HasForeignKey(d => d.DynamicPropertyId);
            });

            modelBuilder.Entity<AbpEdition>(entity =>
            {
                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<AbpEntityChange>(entity =>
            {
                entity.HasIndex(e => e.EntityChangeSetId, "IX_AbpEntityChanges_EntityChangeSetId");

                entity.HasIndex(e => new { e.EntityTypeFullName, e.EntityId }, "IX_AbpEntityChanges_EntityTypeFullName_EntityId");

                entity.Property(e => e.EntityId).HasMaxLength(48);

                entity.Property(e => e.EntityTypeFullName).HasMaxLength(192);

                entity.HasOne(d => d.EntityChangeSet)
                    .WithMany(p => p.AbpEntityChanges)
                    .HasForeignKey(d => d.EntityChangeSetId);
            });

            modelBuilder.Entity<AbpEntityChangeSet>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.CreationTime }, "IX_AbpEntityChangeSets_TenantId_CreationTime");

                entity.HasIndex(e => new { e.TenantId, e.Reason }, "IX_AbpEntityChangeSets_TenantId_Reason");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpEntityChangeSets_TenantId_UserId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.Reason).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpEntityPropertyChange>(entity =>
            {
                entity.HasIndex(e => e.EntityChangeId, "IX_AbpEntityPropertyChanges_EntityChangeId");

                entity.Property(e => e.NewValue).HasMaxLength(512);

                entity.Property(e => e.OriginalValue).HasMaxLength(512);

                entity.Property(e => e.PropertyName).HasMaxLength(96);

                entity.Property(e => e.PropertyTypeFullName).HasMaxLength(192);

                entity.HasOne(d => d.EntityChange)
                    .WithMany(p => p.AbpEntityPropertyChanges)
                    .HasForeignKey(d => d.EntityChangeId);
            });

            modelBuilder.Entity<AbpFeature>(entity =>
            {
                entity.HasIndex(e => new { e.EditionId, e.Name }, "IX_AbpFeatures_EditionId_Name");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "IX_AbpFeatures_TenantId_Name");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.AbpFeatures)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AbpLanguage>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Name }, "IX_AbpLanguages_TenantId_Name");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Icon).HasMaxLength(128);

                entity.Property(e => e.IsDisabled)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AbpLanguageText>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Source, e.LanguageName, e.Key }, "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<AbpNotification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataTypeName).HasMaxLength(512);

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<AbpNotificationSubscription>(entity =>
            {
                entity.HasIndex(e => new { e.NotificationName, e.EntityTypeName, e.EntityId, e.UserId }, "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName_EntityId_UserId");

                entity.HasIndex(e => new { e.TenantId, e.NotificationName, e.EntityTypeName, e.EntityId, e.UserId }, "IX_AbpNotificationSubscriptions_TenantId_NotificationName_EntityTypeName_EntityId_UserId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName).HasMaxLength(96);
            });

            modelBuilder.Entity<AbpOrganizationUnit>(entity =>
            {
                entity.HasIndex(e => e.ParentId, "IX_AbpOrganizationUnits_ParentId");

                entity.HasIndex(e => new { e.TenantId, e.Code }, "IX_AbpOrganizationUnits_TenantId_Code");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(95);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId);
            });

            modelBuilder.Entity<AbpOrganizationUnitRole>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.OrganizationUnitId }, "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId");

                entity.HasIndex(e => new { e.TenantId, e.RoleId }, "IX_AbpOrganizationUnitRoles_TenantId_RoleId");
            });

            modelBuilder.Entity<AbpPermission>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AbpPermissions_RoleId");

                entity.HasIndex(e => new { e.TenantId, e.Name }, "IX_AbpPermissions_TenantId_Name");

                entity.HasIndex(e => e.UserId, "IX_AbpPermissions_UserId");

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AbpPermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AbpRole>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId, "IX_AbpRoles_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId, "IX_AbpRoles_DeleterUserId");

                entity.HasIndex(e => e.LastModifierUserId, "IX_AbpRoles_LastModifierUserId");

                entity.HasIndex(e => new { e.TenantId, e.NormalizedName }, "IX_AbpRoles_TenantId_NormalizedName");

                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(128);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.NormalizedName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.AbpRoleCreatorUsers)
                    .HasForeignKey(d => d.CreatorUserId);

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.AbpRoleDeleterUsers)
                    .HasForeignKey(d => d.DeleterUserId);

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.AbpRoleLastModifierUsers)
                    .HasForeignKey(d => d.LastModifierUserId);
            });

            modelBuilder.Entity<AbpRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AbpRoleClaims_RoleId");

                entity.HasIndex(e => new { e.TenantId, e.ClaimType }, "IX_AbpRoleClaims_TenantId_ClaimType");

                entity.Property(e => e.ClaimType).HasMaxLength(256);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AbpRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AbpSetting>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.Name, e.UserId }, "IX_AbpSettings_TenantId_Name_UserId")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_AbpSettings_UserId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpSettings)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpTenant>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId, "IX_AbpTenants_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId, "IX_AbpTenants_DeleterUserId");

                entity.HasIndex(e => e.EditionId, "IX_AbpTenants_EditionId");

                entity.HasIndex(e => e.LastModifierUserId, "IX_AbpTenants_LastModifierUserId");

                entity.HasIndex(e => e.TenancyName, "IX_AbpTenants_TenancyName");

                entity.Property(e => e.ConnectionString).HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TenancyName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.AbpTenantCreatorUsers)
                    .HasForeignKey(d => d.CreatorUserId);

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.AbpTenantDeleterUsers)
                    .HasForeignKey(d => d.DeleterUserId);

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.AbpTenants)
                    .HasForeignKey(d => d.EditionId);

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.AbpTenantLastModifierUsers)
                    .HasForeignKey(d => d.LastModifierUserId);
            });

            modelBuilder.Entity<AbpTenantNotification>(entity =>
            {
                entity.HasIndex(e => e.TenantId, "IX_AbpTenantNotifications_TenantId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataTypeName).HasMaxLength(512);

                entity.Property(e => e.EntityId).HasMaxLength(96);

                entity.Property(e => e.EntityTypeAssemblyQualifiedName).HasMaxLength(512);

                entity.Property(e => e.EntityTypeName).HasMaxLength(250);

                entity.Property(e => e.NotificationName)
                    .IsRequired()
                    .HasMaxLength(96);
            });

            modelBuilder.Entity<AbpUser>(entity =>
            {
                entity.HasIndex(e => e.CreatorUserId, "IX_AbpUsers_CreatorUserId");

                entity.HasIndex(e => e.DeleterUserId, "IX_AbpUsers_DeleterUserId");

                entity.HasIndex(e => e.LastModifierUserId, "IX_AbpUsers_LastModifierUserId");

                entity.HasIndex(e => new { e.TenantId, e.NormalizedEmailAddress }, "IX_AbpUsers_TenantId_NormalizedEmailAddress");

                entity.HasIndex(e => new { e.TenantId, e.NormalizedUserName }, "IX_AbpUsers_TenantId_NormalizedUserName");

                entity.Property(e => e.AuthenticationSource).HasMaxLength(64);

                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(128);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmationCode).HasMaxLength(328);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.NormalizedEmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PasswordResetCode).HasMaxLength(328);

                entity.Property(e => e.PhoneNumber).HasMaxLength(32);

                entity.Property(e => e.SecurityStamp).HasMaxLength(128);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CreatorUser)
                    .WithMany(p => p.InverseCreatorUser)
                    .HasForeignKey(d => d.CreatorUserId);

                entity.HasOne(d => d.DeleterUser)
                    .WithMany(p => p.InverseDeleterUser)
                    .HasForeignKey(d => d.DeleterUserId);

                entity.HasOne(d => d.LastModifierUser)
                    .WithMany(p => p.InverseLastModifierUser)
                    .HasForeignKey(d => d.LastModifierUserId);
            });

            modelBuilder.Entity<AbpUserAccount>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress, "IX_AbpUserAccounts_EmailAddress");

                entity.HasIndex(e => new { e.TenantId, e.EmailAddress }, "IX_AbpUserAccounts_TenantId_EmailAddress");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserAccounts_TenantId_UserId");

                entity.HasIndex(e => new { e.TenantId, e.UserName }, "IX_AbpUserAccounts_TenantId_UserName");

                entity.HasIndex(e => e.UserName, "IX_AbpUserAccounts_UserName");

                entity.Property(e => e.EmailAddress).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpUserClaim>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.ClaimType }, "IX_AbpUserClaims_TenantId_ClaimType");

                entity.HasIndex(e => e.UserId, "IX_AbpUserClaims_UserId");

                entity.Property(e => e.ClaimType).HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpUserLogin>(entity =>
            {
                entity.HasIndex(e => new { e.ProviderKey, e.TenantId }, "IX_AbpUserLogins_ProviderKey_TenantId")
                    .IsUnique()
                    .HasFilter("([TenantId] IS NOT NULL)");

                entity.HasIndex(e => new { e.TenantId, e.LoginProvider, e.ProviderKey }, "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserLogins_TenantId_UserId");

                entity.HasIndex(e => e.UserId, "IX_AbpUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpUserLoginAttempt>(entity =>
            {
                entity.HasIndex(e => new { e.TenancyName, e.UserNameOrEmailAddress, e.Result }, "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Result");

                entity.HasIndex(e => new { e.UserId, e.TenantId }, "IX_AbpUserLoginAttempts_UserId_TenantId");

                entity.Property(e => e.BrowserInfo).HasMaxLength(512);

                entity.Property(e => e.ClientIpAddress).HasMaxLength(64);

                entity.Property(e => e.ClientName).HasMaxLength(128);

                entity.Property(e => e.TenancyName).HasMaxLength(64);

                entity.Property(e => e.UserNameOrEmailAddress).HasMaxLength(256);
            });

            modelBuilder.Entity<AbpUserNotification>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.State, e.CreationTime }, "IX_AbpUserNotifications_UserId_State_CreationTime");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AbpUserOrganizationUnit>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.OrganizationUnitId }, "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserOrganizationUnits_TenantId_UserId");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<AbpUserRole>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.RoleId }, "IX_AbpUserRoles_TenantId_RoleId");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserRoles_TenantId_UserId");

                entity.HasIndex(e => e.UserId, "IX_AbpUserRoles_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpUserToken>(entity =>
            {
                entity.HasIndex(e => new { e.TenantId, e.UserId }, "IX_AbpUserTokens_TenantId_UserId");

                entity.HasIndex(e => e.UserId, "IX_AbpUserTokens_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(512);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AbpUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AbpWebhookEvent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.WebhookName).IsRequired();
            });

            modelBuilder.Entity<AbpWebhookSendAttempt>(entity =>
            {
                entity.HasIndex(e => e.WebhookEventId, "IX_AbpWebhookSendAttempts_WebhookEventId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.WebhookEvent)
                    .WithMany(p => p.AbpWebhookSendAttempts)
                    .HasForeignKey(d => d.WebhookEventId);
            });

            modelBuilder.Entity<AbpWebhookSubscription>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Secret).IsRequired();

                entity.Property(e => e.WebhookUri).IsRequired();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CourseCategoryID");
            });

            modelBuilder.Entity<CourseAccessLevel>(entity =>
            {
                entity.ToTable("CourseAccessLevel", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseAccessLevels)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseAccessLevel_CourseID");
            });

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.ToTable("CourseCategory", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryIdentifier)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CourseRecording>(entity =>
            {
                entity.ToTable("CourseRecordings", "CRS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseRecordings)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CourseRecordingCourseID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
