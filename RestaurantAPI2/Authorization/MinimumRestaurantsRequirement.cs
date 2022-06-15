using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI2.Authorization
{
    public class MinimumRestaurantsRequirement : IAuthorizationRequirement
    {
        public int MinimumRestaurants { get; }

        public MinimumRestaurantsRequirement(int minimumRestaurants)
        {
            MinimumRestaurants = minimumRestaurants;
        }
    }
}
