using AutoMapper;
using RestaurantAPI2.Entities;
using RestaurantAPI2.Models;

namespace RestaurantAPI2
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(e => e.City, x => x.MapFrom(s => s.Address.City))
                .ForMember(e => e.Street, x => x.MapFrom(s => s.Address.Street))
                .ForMember(e => e.PostalCode, x => x.MapFrom(s => s.Address.PostalCode));
            //reszta automatycznie sie zmapuje

            CreateMap<Dish, DishDto>(); //jak chcesz wypisac uzytkownikowwi

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(e => e.Address, x => x.MapFrom(dto => new Address()
                { 
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode 
                })); //jak tworzysz encje w bazie danych
            CreateMap<CreateDishDto, Dish>();
        }
    }
}
