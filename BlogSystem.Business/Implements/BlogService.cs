using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BlogSystem.DataAccess.Entities;
using BlogSystem.Business.Domain;
using BlogSystem.Business.Extensions;
using BlogSystem.Business.Exceptions;
using BlogSystem.Business.Interface;
using BlogSystem.DataAccess.Repository;

namespace BlogSystem.Business.Implements
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<BlogEntity> _blogRepository;

        public BlogService(IRepository<BlogEntity> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> GetBlogs()
        {
            List<BlogEntity> _blogs = _blogRepository.GetAll().OrderByDescending(b => b.Id).ToList();

            return _blogs.Select(blogEntity => blogEntity.ToBlog()).ToList();
        }

        public Blog GetBlog(long id)
        {
            BlogEntity _blog = _blogRepository.Get(b => id == b.Id);
            if (_blog == null)
                throw new NoSuchBlogException();
            return _blog.ToBlog();
        }

        public Blog CreateBlog(Blog blog)
        {
            blog.Id = 0; // To prevent the blog id be assigned by over post.
            BlogEntity createdBlog = _blogRepository.Add(blog.ToBlogEntity());
            _blogRepository.SaveChanges();

            return createdBlog.ToBlog();
        }

        public void ModifyBlog(Blog blog)
        {
            _blogRepository.Update(blog.ToBlogEntity());

            try
            {
                _blogRepository.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_blogRepository.IsExists(blog.ToBlogEntity()))
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

            return blogEntity.ToBlog();
        }
    }
}