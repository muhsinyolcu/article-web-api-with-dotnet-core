using System;

namespace ArticleApp.Infrastructure.Entities
{
    public class Article : BaseEntity
    {
        public string ArticleSummary { get; set; }
        public string ArticleContent { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
