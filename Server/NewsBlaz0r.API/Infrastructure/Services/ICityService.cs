using System.Collections.Generic;
using System.Threading.Tasks;
using NewsBlaz0r.Shared.Models;

namespace NewsBlaz0r.API.Infrastructure.Services
{
    public interface ICityService
    {
        Task InitAsync();
        List<City> FilterByName(string name);
        string GetSlug(string name);
        string GetName(string slug);
    }
}