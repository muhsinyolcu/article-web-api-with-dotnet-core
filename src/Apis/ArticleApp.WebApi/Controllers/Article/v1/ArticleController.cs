using Microsoft.AspNetCore.Mvc;

namespace ArticleApp.WebApi.Controllers.Article.v1
{
    //TODO
    public class ArticleController : BaseApiController
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}