using System;
using System.Collections.Generic;
using System.Linq;
using Brog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Brog.Services
{
    public interface IArticleData
        {
            IEnumerable<Article> GetAll();
            Article Get(int Id);
            Article Add(Article newArticle);
        }

    public class SQLiteArticleData : IArticleData
    {
        private BrogDbContext _context;

        public SQLiteArticleData(BrogDbContext context)
        {
            _context = context;
            //_context.Database.Migrate();
        }

        public Article Add(Article newArticle)
        {
            _context.Add(newArticle);
            _context.SaveChanges();
            return newArticle;
        }

        public Article Get(int Id)
        {
            return _context.Articles.FirstOrDefault(a => a.id == Id);
        }

        public IEnumerable<Article> GetAll()
        {
            return _context.Articles;
        }
    }
}
