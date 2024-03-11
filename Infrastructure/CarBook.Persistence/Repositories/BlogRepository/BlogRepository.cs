using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarbookContext _context;

        public BlogRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _context.Blogs
                .Include(x => x.Author)
                .Where(x => x.BlogId == id)
                .ToList();
            return values;
        }

        List<Blog> IBlogRepository.GetBlogsWithAuthors()
        {
            var values = _context.Blogs
                .Include(x => x.Author)
                .ToList();
            return values;
        }

        List<Blog> IBlogRepository.GetLast3BlogsWithAuthors()
        {
            var values = _context.Blogs
                .Include(x => x.Author)
                .OrderByDescending(x => x.BlogId)
                .Take(3)
                .ToList();
            return values;
        }
    }
}
