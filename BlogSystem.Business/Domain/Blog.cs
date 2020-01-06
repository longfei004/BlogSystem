using BlogSystem.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Business
{
    public class Blog
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}