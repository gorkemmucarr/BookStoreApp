using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
    public class BookRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
