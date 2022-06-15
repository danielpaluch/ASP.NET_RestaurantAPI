using Microsoft.AspNetCore.Authorization;

namespace RestaurantAPI2.Authorization
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }
        public MinimumAgeRequirement(int minAge)
        {
            MinimumAge = minAge;
        }
    }
}
