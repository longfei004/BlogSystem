using System;
using System.Collections.Generic;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Exceptions;
using BlogSystem.Business.Implements;
using BlogSystem.DataAccess.Entities;
using BlogSystem.DataAccess.Repository;
using Moq;
using Xunit;
using AutoMapper;

namespace BlogSystem.Business.Tests.Implements
{
    public class BlogServiceTests
    {
        private Mock<IRepository<BlogEntity>> _blogRepository;
        private Mock<IMapper> _mapper;
        private BlogService _service;

        public BlogServiceTests()
        {
            _blogRepository = new Mock<IRepository<BlogEntity>>();
            _mapper = new Mock<IMapper>();
            _service = new BlogService(_blogRepository.Object, _mapper.Object);
        }

        private List<BlogEntity> MockSeedDataItems()
        {
            List<BlogEntity> blogEntities = new List<BlogEntity>();
            blogEntities.Add(new BlogEntity{Id = 1, Title="foo1", Content="bar1", LastUpdateTime=new DateTime()});
            blogEntities.Add(new BlogEntity{Id = 2, Title="foo2", Content="bar2", LastUpdateTime=new DateTime()});
            blogEntities.Add(new BlogEntity{Id = 3, Title="foo3", Content="bar3", LastUpdateTime=new DateTime()});
            return blogEntities;
        }

        [Fact]
        public void GetBlogs_Should_Return_BlogList()
        {
            _blogRepository.Setup(repo => repo.GetAll(It.IsAny<Func<BlogEntity, bool>>()))
                .Returns(MockSeedDataItems());
            
            var result = _service.GetBlogs();

            var blogs = Assert.IsAssignableFrom<List<Blog>>(result);
            Assert.Equal(3, blogs.Count);
        }

        [Fact]
        public void GetBlog_Should_Return_Assigned_Blog()
        {
            _blogRepository.Setup(repo => repo.Get(It.IsAny<Func<BlogEntity, bool>>()))
                .Returns(new BlogEntity{Id = 1, Title="foo"});
            _mapper.Setup(mapper => mapper.Map<Blog>(It.IsAny<BlogEntity>()))
                .Returns(new Blog{Title = "foo"});
            
            var result = _service.GetBlog(1);

            Assert.Equal("foo", result.Title);
        }

        [Fact]
        public void ModifyBlog_Should_Throw_NoSuchBlogException_When_Assigned_Blog_Is_Not_Exist()
        {
            _blogRepository.Setup(repo => repo.SaveChanges())
                .Throws(new Exception());

            Assert.Throws<NoSuchBlogException>(() => _service.ModifyBlog(new Blog()));
        }

        [Fact]
        public void DeleteBlog_Should_Return_Null_When_Assigned_Blog_Is_Not_Exist()
        {
            Assert.Throws<NoSuchBlogException>(() => _service.DeleteBlog(1));
        }
    }
}