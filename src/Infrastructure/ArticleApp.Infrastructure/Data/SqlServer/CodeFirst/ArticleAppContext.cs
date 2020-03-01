using ArticleApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Infrastructure.Data.SqlServer.CodeFirst
{
    public class ArticleAppContext : DbContext
    {
        protected readonly string connectionString = "data source=den1.mssql8.gear.host;initial catalog=mydefaultproject;persist security info=True;user id=mydefaultproject;password=Ty4L8lg-z9l-;MultipleActiveResultSets=True;App=EntityFramework&quot;";
        public ArticleAppContext(DbContextOptions<ArticleAppContext> options) : base(options)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
