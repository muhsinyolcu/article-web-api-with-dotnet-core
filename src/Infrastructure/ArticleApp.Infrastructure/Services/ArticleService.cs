using ArticleApp.Common.Helpers;
using ArticleApp.Infrastructure.Entities;
using ArticleApp.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleApp.Infrastructure.Services
{
    class ArticleService : IArticleService
    {
        //TODO Articleservice
        public Task<ServiceResult<Article>> AddArticle(Article article)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<int>> DeleteArticle(int articleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<IReadOnlyList<Article>>> GetArticleListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<Article>> UpdateArticle(Article article)
        {
            throw new System.NotImplementedException();
        }
    }
}
