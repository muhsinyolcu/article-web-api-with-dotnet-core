using System;

namespace ArticleApp.Infrastructure.Entities
{
    public class Comment : BaseEntity
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
