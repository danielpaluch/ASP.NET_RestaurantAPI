﻿using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI2.Authorization
{
    public enum ResourceOperation
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get; }
        public ResourceOperationRequirement(ResourceOperation resourceOparation)
        {
            ResourceOperation = resourceOparation;
        }
    }
}
