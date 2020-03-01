using ArticleApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Infrastructure.Data.SqlServer.CodeFirst
{
    public class ArticleAppContext: DbContext
    {
        public ArticleAppContext(DbContextOptions<ArticleAppContext> options): base(options)
        {

        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //TODO connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("");
        }
    }
}
