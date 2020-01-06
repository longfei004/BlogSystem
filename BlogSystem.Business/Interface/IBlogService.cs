using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlogSystem.Business
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogsAsync();

        Task<Blog> GetBlogAsync(long id);

        Task<Blog> CreateBlogAsync(Blog blog);

        Task ModifyBlogAsync(Blog blog);
    }
}