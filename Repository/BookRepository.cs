using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Repositories.Extencions;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateBook(Book book) => Create(book);


        public void DeleteOneBook(Book book) => Delete(book);


        public IQueryable<Book> GetAllBooks() => GetAll();
        

        public Book GetOneBook(int id)
        {
            return FindByCondition(p => p.BookId.Equals(id));
        }

        public void UpdateBook(Book book) => Update(book);

        public IQueryable<Book> GetAllBooksWithDetails(BookRequestParameters bookRequestParameters)
        {
            return _context.Books
                .FilterByCategory(bookRequestParameters.CategoryId)
                .FilterByPrice(bookRequestParameters.MinPrice, 
                 bookRequestParameters.MaxPrice, bookRequestParameters.IsValidPrice)
                .FilterBySearch(bookRequestParameters.SearchString);
        }
        
    }
}
