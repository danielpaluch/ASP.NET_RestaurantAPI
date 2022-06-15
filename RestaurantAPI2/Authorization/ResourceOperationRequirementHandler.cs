﻿using Microsoft.AspNetCore.Authorization;
using RestaurantAPI2.Authorization;
using RestaurantAPI2.Entities;
using System.Security.Claims;

namespace RestaurantAPI2.Authorization

{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Restaurant>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            ResourceOperationRequirement requirement, Restaurant restaurant)
        {
            if(requirement.ResourceOperation == ResourceOperation.Read 
                || requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (restaurant.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
