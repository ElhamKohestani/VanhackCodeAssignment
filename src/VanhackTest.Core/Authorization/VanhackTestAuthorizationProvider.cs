﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace VanhackTest.Authorization
{
    public class VanhackTestAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
             Permission CourseP= context.CreatePermission(PermissionNames.Pages_Courses, L("Courses"), multiTenancySides: MultiTenancySides.Host);
            Permission CourseCreatorP = CourseP.CreateChildPermission(PermissionNames.Pages_Courses + ".Creator", multiTenancySides: MultiTenancySides.Host);
           

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, VanhackTestConsts.LocalizationSourceName);
        }
    }
}
