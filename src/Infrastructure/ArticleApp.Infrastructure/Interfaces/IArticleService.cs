using ArticleApp.Common.Helpers;
using ArticleApp.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleApp.Infrastructure.Interfaces
{
    public interface IArticleService : IAsyncRepository<Article>
    {
        Task<ServiceResult<Article>> AddArticle(Article article);
        Task<ServiceResult<Article>> UpdateArticle(Article article);
        Task<ServiceResult<int>> DeleteArticle(int articleId);
        Task<ServiceResult<IReadOnlyList<Article>>> GetArticleListAsync();
    }
}
