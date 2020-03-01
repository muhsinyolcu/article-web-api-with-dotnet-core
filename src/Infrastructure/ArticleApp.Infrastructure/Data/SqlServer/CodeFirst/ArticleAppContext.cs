using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Infrastructure.Data.SqlServer.CodeFirst
{
    public class ArticleAppContext: DbContext
    {
        public ArticleAppContext(DbContextOptions<ArticleAppContext> options): base(options)
        {

        }
        //TODO DbSets
    }
}
