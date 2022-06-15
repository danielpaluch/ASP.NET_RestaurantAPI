using Microsoft.AspNetCore.Authorization;
using RestaurantAPI2.Entities;
using System.Security.Claims;

namespace RestaurantAPI2.Authorization
{
    public class MinimumRestaurantsRequirementHandler : AuthorizationHandler<MinimumRestaurantsRequirement>
    {
        private readonly RestaurantDbContext _context;

        public MinimumRestaurantsRequirementHandler(RestaurantDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MinimumRestaurantsRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var restaurants = _context.restaurants.Count(r => r.CreatedById == userId);

            if(restaurants >= requirement.MinimumRestaurants)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
