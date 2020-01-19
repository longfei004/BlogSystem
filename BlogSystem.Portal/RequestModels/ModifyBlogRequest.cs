using System;
using System.ComponentModel.DataAnnotations;
using BlogSystem.Business.Domain;

namespace BlogSystem.Portal.RequestModles
{
    public class ModifyBlogRequest
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
        [Range(typeof(DateTime), "01/01/2000", "01/01/2100", ErrorMessage="Date is out of Range")]
        public DateTime LastUpdateTime { get; set; }

        public Blog ToBlog()
        {
            if(this == null)
                return null;

            return new Blog
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content,
                LastUpdateTime = this.LastUpdateTime
            };
        }
    }
}