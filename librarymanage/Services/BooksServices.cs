using librarymanage.Models;
using System.Collections.Generic;
namespace librarymanage.Services
{
    public class BooksServices
    {
        private readonly List<Books> _book = new List<Books>();

        public BooksServices()
        {
            _book.Add(new Books { Id = 1, Title = "300 bai code thieu nhi", author = "cuong tran", publishyear = 2005 });
            _book.Add(new Books { Id = 2, Title = "web api co ban", author = "cuong tran", publishyear = 2006 });
        }
        public IEnumerable<Books> GetAllBooks() => _book;
        public Books GetBookById(int id) => _book.Find(b => b.Id == id);
        public void AddBook(Books book)
        {
            book.Id = _book.Count + 1;
            _book.Add(book);
        }
        public void UpdateBook(int id, Books book)
        {
            var sachcansua = _book.Find(b => b.Id == id);
            if (sachcansua != null)
            {
                sachcansua.Title = book.Title;
                sachcansua.author = book.author;
                sachcansua.publishyear = book.publishyear;
            }
        }
        public void DeleteBook(int id) => _book.RemoveAll(b => b.Id == id);
    }
}
