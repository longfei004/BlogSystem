using BlogSystem.DataAccess;

namespace BlogSystem.Business
{
    public class Blog
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        // ? Should it be a extension method?
        public BlogEntity ToBlogEntity()
        {
            if (this == null)
                return null;

            return new BlogEntity
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content
            };
        }
    }
}