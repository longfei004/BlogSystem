using System;
using BlogSystem.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Business.Domain
{
    public class Blog
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public BlogEntity ToBlogEntity()
        {
            if(this == null)
                return null;

            return new BlogEntity
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content,
                LastUpdateTime = this.LastUpdateTime
            };
        }
    }
}