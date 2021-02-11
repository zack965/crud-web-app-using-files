using pdf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf.Models.Repos
{
    public class BookRepos : IOperations<Book>
    {
        AppDbContext db;

        public BookRepos(AppDbContext _db)
        {
            db = _db;
        }
        public void Add(Book entity)
        {
            db.books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Book entity)
        {
            db.books.Remove(entity);
            db.SaveChanges();
        }

        public Book Find(int id)
        {
            var authfind = db.books.SingleOrDefault(x => x.BookId == id);
            return authfind;
        }

        public IList<Book> List()
        {
            return db.books.ToList();
        }



        public void Update(int id, Book entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }

    }
}
