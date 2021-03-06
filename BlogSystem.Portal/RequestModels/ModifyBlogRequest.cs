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
        [Required]
        public string Content { get; set; }
        [Range(typeof(DateTime), "01/01/2000", "01/01/2100", ErrorMessage="Date is out of Range")]
        public DateTime LastUpdateTime { get; set; }
    }
}