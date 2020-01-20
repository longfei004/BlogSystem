using System;
using System.Collections.Generic;
using System.Linq;
using BlogSystem.DataAccess.Entities;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Exceptions;
using BlogSystem.Business.Interface;
using BlogSystem.DataAccess.Repository;
using AutoMapper;

namespace BlogSystem.Business.Implements
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<BlogEntity> _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IRepository<BlogEntity> blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public List<Blog> GetBlogs()
        {
            List<BlogEntity> _blogs = _blogRepository.GetAll().OrderByDescending(b => b.Id).ToList();

            return _blogs.Select(blogEntity => _mapper.Map<Blog>(blogEntity)).ToList();
        }

        public Blog GetBlog(long id)
        {
            BlogEntity _blog = _blogRepository.Get(b => id == b.Id);
            if (_blog == null)
                throw new NoSuchBlogException();
            return _mapper.Map<Blog>(_blog);
        }

        public Blog CreateBlog(Blog blog)
        {
            BlogEntity createdBlog = _blogRepository.Add(_mapper.Map<BlogEntity>(blog));
            _blogRepository.SaveChanges();

            return _mapper.Map<Blog>(createdBlog);
        }

        public void ModifyBlog(Blog blog)
        {
            _blogRepository.Update(_mapper.Map<BlogEntity>(blog));

            try
            {
                _blogRepository.SaveChanges();
            }
            catch (Exception)
            {
                if (!_blogRepository.IsExists(_mapper.Map<BlogEntity>(blog)))
                    throw new NoSuchBlogException();
                else
                    throw;
            }
        }

        public Blog DeleteBlog(long id)
        {
            var blogEntity = _blogRepository.Get(b => id == b.Id);
            if(blogEntity == null)
                throw new NoSuchBlogException();

            _blogRepository.Delete(blogEntity);
            _blogRepository.SaveChanges();

            return _mapper.Map<Blog>(blogEntity);
        }
    }
}