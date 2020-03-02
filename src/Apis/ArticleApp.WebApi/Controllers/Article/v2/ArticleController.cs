using Microsoft.AspNetCore.Mvc;

namespace ArticleApp.WebApi.Controllers.Article.v2
{
    //This controller is for version 2
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArticleController : BaseApiController
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}