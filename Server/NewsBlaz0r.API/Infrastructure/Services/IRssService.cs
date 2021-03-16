using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsBlaz0r.Shared.Models;

namespace NewsBlaz0r.API.Infrastructure.Services
{
    public interface IRssService
    {
        Task<List<Article>> GetArticles(string endpoint);
        Task<List<Article>> GetFromBing(string endpoint);
    }
}
