using System.Threading.Tasks;
using System.Collections.Generic;
using BlogSystem.Business.Domain;

namespace BlogSystem.Business.Interface
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogsAsync();

        Task<Blog> GetBlogAsync(long id);

        Task<Blog> CreateBlogAsync(Blog blog);

        Task ModifyBlogAsync(Blog blog);

        Task<Blog> DeleteBlogAsync(long id);
    }
}