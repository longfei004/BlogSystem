using AutoMapper;
using BlogSystem.Business.Domain;
using BlogSystem.DataAccess.Entities;

namespace BlogSystem.Business.AutoMapping
{
    public class BlogEntityMapper : Profile
    {
        public BlogEntityMapper()
        {
            CreateMap<Blog, BlogEntity>();
            CreateMap<BlogEntity, Blog>();
        }
    }
}