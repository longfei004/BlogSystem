using System;

namespace BlogSystem.Business.Domain
{
    public class Blog
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}