﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI2.Entities;
using RestaurantAPI2.Exceptions;
using RestaurantAPI2.Models;

namespace RestaurantAPI2.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        DishDto GetById(int restaurantId, int dishId);
        List<DishDto> GetAll(int restaurantId);
        void RemoveAll(int restaurantId);
        void RemoveById(int restaurantId, int dishId);
    }
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public DishService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public int Create(int restaurantId, CreateDishDto dto)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var dishEntity = _mapper.Map<Dish>(dto);

            dishEntity.RestaurantId = restaurantId;

            _context.dishes.Add(dishEntity);
            _context.SaveChanges();

            return dishEntity.ID;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var dish = _context.dishes.FirstOrDefault(d => d.ID == dishId);
            if (dish is null || dish.RestaurantId != restaurantId)
                throw new NotFoundException("Dish not found");

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var dishesDto = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishesDto;
        }
        public void RemoveAll(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            _context.RemoveRange(restaurant.Dishes);
            _context.SaveChanges();
        }

        public void RemoveById(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurantById(restaurantId);
            var dish = _context.dishes.FirstOrDefault(d => d.ID == dishId);

            if (dish is null || restaurantId != dish.RestaurantId)
                throw new NotFoundException("Dish not found");

            _context.Remove(dish);
            _context.SaveChanges();
        }


        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _context.restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(e => e.Id == restaurantId);

            if (restaurant is null)
                throw new NotFoundException("Restaurant not found");

            return restaurant;
        }
    }
}
