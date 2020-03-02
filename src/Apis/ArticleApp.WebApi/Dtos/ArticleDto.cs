using System;

namespace ArticleApp.WebApi.Dtos
{
    public class ArticleDto
    {
        public string ArticleSummary { get; set; }
        public string ArticleContent { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
