using AutoMapper;
using BlogSystem.Portal.RequestModles;
using BlogSystem.Portal.ResponseModels;
using BlogSystem.Business.Domain;

namespace BlogSystem.Portal.AutoMaping
{
    public class BlogMapper : Profile
    {
        public BlogMapper()
        {
            CreateMap<CreateBlogRequest, Blog>();
            CreateMap<ModifyBlogRequest, Blog>();
            CreateMap<Blog, BlogResponse>();
        }
    }
}