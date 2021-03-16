using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsBlaz0r.API.Infrastructure.Services;

namespace NewsBlaz0r.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IRssService _rssService;
        
        public ArticlesController(IRssService rssService)
        {
            _rssService = rssService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery] string endpoint)
        {
            return Ok(await _rssService.GetArticles(endpoint));
        }
    }
}