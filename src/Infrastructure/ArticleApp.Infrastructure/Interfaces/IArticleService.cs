using ArticleApp.Infrastructure.Entities;

namespace ArticleApp.Infrastructure.Interfaces
{
    public interface IArticleService : IAsyncRepository<Article>
    {
    }
}
