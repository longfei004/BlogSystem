using System.ComponentModel.DataAnnotations;
using BlogSystem.Business;

namespace BlogSystem.Portal
{
    public class BlogRequest
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public Blog ToBlog()
        {
            if(this == null)
                return null;

            return new Blog
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content
            };
        }
    }
}