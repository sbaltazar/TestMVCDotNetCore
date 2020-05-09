﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Test.Security
{
    public class CanEditOnlyOtherAdminRolesAndClaimsHandler : AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirement requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;

            if (authFilterContext == null)
            {
                return Task.CompletedTask;
            }

            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            string adminIdBeingEdited = authFilterContext.HttpContext.Request.Query["userId"];

            bool userIsInAdminRole = context.User.IsInRole("Admin");
            bool userHasValidClaim = context.User.HasClaim(claim => claim.Type == "Edit Role" && claim.Value == "true");
            bool isUserTheSameEditing = adminIdBeingEdited.ToLower() == loggedInAdminId.ToLower();

            if (userIsInAdminRole && userHasValidClaim && !isUserTheSameEditing)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
