using ArticleApp.Common.Helpers;
using ArticleApp.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleApp.Infrastructure.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<ServiceResult<T>> AddAsync(T entity);
        Task<ServiceResult<T>> UpdateAsync(T entity);
        Task<ServiceResult<int>> DeleteAsync(int id);
        Task<ServiceResult<IReadOnlyList<T>>> ListAllAsync();
    }
}