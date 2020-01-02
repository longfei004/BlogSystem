using System.Threading.Tasks;
using System.Collections.Generic;
using BlogSystem.Models;

namespace BlogSystem.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogsAsync();

        Task<Blog> GetBlogAsync(long id);

        Task<Blog> CreateBlogAsync(Blog blog);
    }
}