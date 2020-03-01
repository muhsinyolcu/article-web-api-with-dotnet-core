using ArticleApp.Infrastructure.Entities;

namespace ArticleApp.Infrastructure.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
    }
}