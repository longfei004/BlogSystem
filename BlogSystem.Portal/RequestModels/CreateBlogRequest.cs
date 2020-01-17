using System;
using System.ComponentModel.DataAnnotations;
using BlogSystem.Business.Domain;

namespace BlogSystem.Portal.RequestModles
{
    public class CreateBlogRequest
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
        [Required]
        public DateTime? LastUpdateTime { get; set; }

        public Blog ToBlog()
        {
            if(this == null)
                return null;

            return new Blog
            {
                Title = this.Title,
                Content = this.Content,
                LastUpdateTime = this.LastUpdateTime
            };
        }
    }
}