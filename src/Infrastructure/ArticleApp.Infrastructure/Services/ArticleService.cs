using ArticleApp.Common.Enums;
using ArticleApp.Common.Helpers;
using ArticleApp.Infrastructure.Data.SqlServer.CodeFirst;
using ArticleApp.Infrastructure.Entities;
using ArticleApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.Infrastructure.Services
{
    public class ArticleService : IArticleService
    {

        protected readonly ArticleAppContext _dbContext;
        public ArticleService(ArticleAppContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<ServiceResult<Article>> AddAsync(Article entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult<int>> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult<IReadOnlyList<Article>>> ListAllAsync()
        {
            var serviceResult = new ServiceResult<IReadOnlyList<Article>>();
            try
            {
                var result = await _dbContext.Set<Article>().ToListAsync();
                if (result.Any())
                {
                    serviceResult.Result = result;
                    serviceResult.TotalItemCount = result.Count();
                }
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.ErrorCode = (int)ErrorCodeEnum.SystemException;
                serviceResult.ValidationMessages.Add(ex.Message);
                //LOG
            }
            return serviceResult;
        }

        public Task<ServiceResult<Article>> UpdateAsync(Article entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
