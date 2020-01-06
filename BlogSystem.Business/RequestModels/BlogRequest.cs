using System.ComponentModel.DataAnnotations;
using BlogSystem.DataAccess;

namespace BlogSystem.Business
{
    public class BlogRequest
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public BlogEntity ToBlogEntity()
        {
            if (this == null)
                return null;

            return new BlogEntity
            {
                Title = this.Title,
                Content = this.Content
            };
        }
    }
}