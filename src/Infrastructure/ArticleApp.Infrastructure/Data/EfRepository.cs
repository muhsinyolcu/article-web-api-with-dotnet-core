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

namespace ArticleApp.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ArticleAppContext _dbContext;
        public EfRepository(ArticleAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<T>> AddAsync(T entity)
        {
            var serviceResult = new ServiceResult<T>();
            try
            {
                _dbContext.Set<T>().Add(entity);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    serviceResult.Result = entity;
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

        public async Task<ServiceResult<int>> DeleteAsync(int id)
        {
            var serviceResult = new ServiceResult<int>();
            try
            {
                var result = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                if (result != null)
                {
                    _dbContext.Set<T>().Remove(result);
                    serviceResult.Result = await _dbContext.SaveChangesAsync();
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

        public async Task<ServiceResult<IReadOnlyList<T>>> ListAllAsync()
        {
            var serviceResult = new ServiceResult<IReadOnlyList<T>>();
            try
            {
                var result = await _dbContext.Set<T>().ToListAsync();
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

        public async Task<ServiceResult<T>> UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
