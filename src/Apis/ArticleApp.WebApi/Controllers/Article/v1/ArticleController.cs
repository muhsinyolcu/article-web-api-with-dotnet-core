using ArticleApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleApp.WebApi.Controllers.Article.v1
{
    //TODO
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticleController : BaseApiController
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet()]
        [Route("getallarticles")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articleService.ListAllAsync();

            return HttpEntity(articles);
        }
    }
}