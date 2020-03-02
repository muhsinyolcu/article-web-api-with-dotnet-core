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
        public async Task<ServiceResult<Article>> AddAsync(Article entity)
        {
            var serviceResult = new ServiceResult<Article>();
            try
            {
                _dbContext.Set<Article>().Add(entity);
                var result = await _dbContext.SaveChangesAsync();

                if (result > decimal.Zero)
                    serviceResult.Result = entity;
                else
                    serviceResult.ErrorCode = (int)ErrorCodeEnum.BadRequest;
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

        public async Task<ServiceResult<int>> DeleteAsync(int id)
        {
            var serviceResult = new ServiceResult<int>();
            try
            {
                var article = await _dbContext.Set<Article>().FirstOrDefaultAsync(a => a.Id == id);
                if (article != null)
                {
                    _dbContext.Set<Article>().Remove(article);
                    var result = await _dbContext.SaveChangesAsync();

                    if (result > decimal.Zero)
                        serviceResult.Result = result;
                    else
                        serviceResult.ErrorCode = (int)ErrorCodeEnum.BadRequest;
                }
                else
                {
                    serviceResult.HasError = true;
                    serviceResult.ErrorCode = (int)ErrorCodeEnum.BadRequest;
                    serviceResult.ValidationMessages.Add("Article not found");
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

        public async Task<ServiceResult<Article>> UpdateAsync(Article entity)
        {
            var serviceResult = new ServiceResult<Article>();
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                var result = await _dbContext.SaveChangesAsync();

                if (result > decimal.Zero)
                    serviceResult.Result = entity;
                else
                    serviceResult.ErrorCode = (int)ErrorCodeEnum.BadRequest;
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
    }
}
