using System.Collections.Generic;
using BlogSystem.Business.Domain;

namespace BlogSystem.Business.Interface
{
    public interface IBlogService
    {
        List<Blog> GetBlogs();

        Blog GetBlog(long id);

        Blog CreateBlog(Blog blog);

        void ModifyBlog(Blog blog);

        Blog DeleteBlog(long id);
    }
}