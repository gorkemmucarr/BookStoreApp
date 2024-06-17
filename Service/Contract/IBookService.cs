using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBook();
        Book GetOneBook(int id);
        void Create(BookDtoForCreate bookDtoForCreate);
        void Update(BookDtoForUpdate bookDtoForUpdate);
        void Delete(int id);
        IEnumerable<Book> GetAllBooksWithDetails(BookRequestParameters bookRequestParameters);
    }
}
