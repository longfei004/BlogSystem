using System;

namespace BlogSystem.DataAccess.Entities
{
    public class BlogEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}