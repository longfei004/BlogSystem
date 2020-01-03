using BlogSystem.DataAccess;

namespace BlogSystem.Business
{
    public static class BlogEntityExtension
    {
        public static Blog ToBlog(this BlogEntity blogEntity)
        {
            if (blogEntity == null)
                return null;

            return new Blog
            {
                Id = blogEntity.Id,
                Title = blogEntity.Title,
                Content = blogEntity.Content
            };
        }
    }
}