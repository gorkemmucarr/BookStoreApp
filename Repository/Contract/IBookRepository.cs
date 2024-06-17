using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        IQueryable<Book> GetAllBooks();
        Book GetOneBook(int id);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteOneBook(Book book);
        IQueryable<Book> GetAllBooksWithDetails(BookRequestParameters bookRequestParameters);
    }
}
