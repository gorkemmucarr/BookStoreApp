using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Extencions
{
    public static class ProductRepositoryExtencion
    {
        public static IQueryable<Book> FilterByCategory(this IQueryable<Book> books, int? categoryId)
        {
            if (categoryId is null)
            {
                return books;
            }
            else
            {
                return books.Where(p => p.CategoryId.Equals(categoryId));
            }
        }
        public static IQueryable<Book> FilterBySearch(this IQueryable<Book> books, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return books;
            }
            else
            {
                return books.Where(p => p.BookName.ToLower().Contains(searchString.ToLower()));
            }
        }

        public static IQueryable<Book> FilterByPrice(this IQueryable<Book> books
            , int minPrice, int maxPrice, bool isValidPrice)
        {
            if (isValidPrice)
            {
                return books.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            }
            else
            {
                return books;
            }
        }

        
    }
}
