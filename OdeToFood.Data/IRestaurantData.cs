using System.Linq;
using OdeToFood.Core;
using System.Collections.Generic;


namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Panchita", Location="Cochabamba", Cuisine=CuisineType.Pollos},
                new Restaurant { Id = 2, Name = "Pollos Copacabana", Location="La Paz", Cuisine=CuisineType.Pollos},
                new Restaurant { Id = 3, Name = "Pollos KFC", Location = "Santa Cruz de la Sierra", Cuisine=CuisineType.Pollos},
                new Restaurant { Id = 4, Name = "Star Bucks", Location = "Santa Cruz de la Sierra", Cuisine=CuisineType.Cafe}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
