using RestaurantAPI2.Entities;
namespace RestaurantAPI2
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }

            IEnumerable<Role> GetRoles()
            {
                var roles = new List<Role>()
                {
                    new Role()
                    {
                        Name="User"
                    },
                    new Role()
                    {
                        Name="Manager"
                    },
                    new Role()
                    {
                        Name="Admin"
                    }
                };

                return roles;
            }

            IEnumerable<Restaurant> GetRestaurants()
            {
                var restaurants = new List<Restaurant>()
                {
                    new Restaurant()
                    {
                        Name = "KFC",
                        Category = "Fast Food",
                        Description = "KFC (short for Kentucky Fried Chicken) is American fast food.",
                        ContactEmail = "contact@kfc.com",
                        ContactNumber = "123123123",
                        HasDelivery = true,
                        Dishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                Name = "Nashville Hot Chicken",
                                Description= "Spicy meal",
                                Price = 10.30M
                            },
                            new Dish()
                            {
                                Name = "Chicken Nuggets",
                                Description = "Best price",
                                Price = 5.30M
                            }
                        },
                        Address = new Address()
                        {
                            City = "Katowice",
                            Street = "Chorzowska",
                            PostalCode = "30-001"
                        }
                    },
                    new Restaurant()
                    {
                        Name = "McDonald",
                        Category = "Fast Food",
                        Description = "McDonald had clown as their logo.",
                        ContactEmail = "contact@mcd.com",
                        ContactNumber = "321321312",
                        HasDelivery = true,
                        Dishes = new List<Dish>()
                        {
                            new Dish()
                            {
                                Name = "Cheeseburger",
                                Description = "With cheese",
                                Price = 6.30M
                            },
                            new Dish()
                            {
                                Name = "Fries",
                                Description = "Salty",
                                Price = 2.30M
                            }
                        },
                        Address = new Address()
                        {
                            City = "Katowice",
                            Street = "Malinowa",
                            PostalCode = "30-001"
                        }
                    }
                };
                return restaurants;
            }
        }
    }
}
