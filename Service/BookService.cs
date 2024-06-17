using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService : IBookService
    {
        private IRepositoryManager _manager;

        public BookService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void Create(BookDtoForCreate bookDtoForCreate)
        {
            Book book = new Book()
            {
                BookName = bookDtoForCreate.BookName,
                Writer = bookDtoForCreate.Writer,
                Price = bookDtoForCreate.Price,
                CategoryId = bookDtoForCreate.CategoryId,
                ImageUrl = bookDtoForCreate.ImageUrl
            };
            //Book book = _mapper.Map<Book>(bookDtoForCreate);
            _manager.BookRepository.Create(book);
            _manager.Save();
        }

        public void Delete(int id)
        {
            var book = _manager.BookRepository.GetOneBook(id);
            if (book is null)
            {
                throw new Exception("Book could not found");
            }
            _manager.BookRepository.DeleteOneBook(book);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBook()
        {
            var books = _manager.BookRepository.GetAllBooks();
            return books;
        }

        public IEnumerable<Book> GetAllBooksWithDetails(BookRequestParameters bookRequestParameters)
        {
            return _manager.BookRepository.GetAllBooksWithDetails(bookRequestParameters);
        }

        public Book GetOneBook(int id)
        {
            var book = _manager.BookRepository.GetOneBook(id);
            if (id == null)
            {
                throw new Exception("Book could not found");
            }
            return book;
        }

        public void Update(BookDtoForUpdate bookDtoForUpdate)
        {
            var book = _manager.BookRepository.GetOneBook(bookDtoForUpdate.BookId);
            book.BookName = bookDtoForUpdate.BookName;
            book.Writer = bookDtoForUpdate.Writer;
            book.Price = bookDtoForUpdate.Price;
            book.ImageUrl = bookDtoForUpdate.ImageUrl;
            book.CategoryId = bookDtoForUpdate.CategoryId;
            _manager.BookRepository.UpdateBook(book);
            _manager.Save();
        }
    }
}
