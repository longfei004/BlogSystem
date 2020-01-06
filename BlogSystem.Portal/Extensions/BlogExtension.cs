using BlogSystem.Business;

namespace BlogSystem.Portal
{
    public static class BlogExtension
    {
        public static BlogResponse ToBlogResponse(this Blog blog)
        {
            if(blog == null)
                return null;

            return new BlogResponse
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content
            };
        }
    }
}