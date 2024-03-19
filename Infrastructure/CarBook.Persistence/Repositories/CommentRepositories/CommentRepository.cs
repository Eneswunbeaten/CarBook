using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarbookContext _context;

        public CommentRepository(CarbookContext context)
        {
            _context = context;
        }

        void IGenericRepository<Comment>.Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        List<Comment> IGenericRepository<Comment>.GetAll()
        {
            var values = _context.Comments.Select(x => new Comment
            {
                CommentId = x.CommentId,
                BlogId=x.BlogId,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Description = x.Description
            }).ToList();
            return values;
        }

        Comment IGenericRepository<Comment>.GetById(int id)
        {
            var value = _context.Comments.Find(id);
            return value;
        }

        void IGenericRepository<Comment>.Remove(int id)
        {
            var value = _context.Comments.Find(id);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        void IGenericRepository<Comment>.Update(Comment entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
