using BookLibrary.Data;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    public class BookServiceImpl
    {

        private readonly ApplicationDbContext data;

        public BookServiceImpl(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<Book> GetAll() => this.data.Books.ToList();
        public void Add(Book book) {
            this.data.Books.Add(book);
            this.data.SaveChanges();
        }

        public void Delete(int id) {
            Book book = findById(id);
           

            this.data.Books.Remove(book);
            this.data.SaveChanges();
        }
        public void Update(int id, Book book)
        {
            Book _book = findById(id);

            this.data.Entry<Book>(_book).CurrentValues.SetValues(book);
            this.data.SaveChanges();
         }
        private Book findById(int id)
        {
          Book book=this.data.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("Book with does not exist");
            }
            return book;
        }
    }


}
