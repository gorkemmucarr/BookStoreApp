using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public void AddItem(Book book,int quantity)
        {
            CartLine? line = Lines.Where(p => p.Book.BookId.Equals(book.BookId))
            .FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Book book)
        {
            Lines.RemoveAll(p => p.Book.BookId.Equals(book.BookId));
        }
        public decimal ComputeTotalValue()
        {
           return Lines.Sum(p => p.Book.Price * p.Quantity);
        }
        public void Clear()
        {
            Lines.Clear();
        }
    }
}
