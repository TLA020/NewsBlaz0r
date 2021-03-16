using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using NewsBlaz0r.Shared.Models;

namespace NewsBlaz0r.API.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private List<City> Cities { get; set; }

        public async Task InitAsync()
        {
            var file = await File.ReadAllTextAsync("./places.json");
            Cities =  JsonSerializer.Deserialize<List<City>>(file);
        }

        public List<City> FilterByName(string name)
        {
            return Cities;
        }

        public string GetSlug(string name)
        {
            return Cities.FirstOrDefault(c => c.Name == name)?.Slug;
        }
        
        public string GetName(string slug)
        {
            return Cities.FirstOrDefault(c => c.Slug == slug)?.Name;
        }
    }   
}