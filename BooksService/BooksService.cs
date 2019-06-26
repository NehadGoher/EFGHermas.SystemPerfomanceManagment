using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksService
{
    class BooksService : IBooksService
    {
        public string GetBook()
        {
            return "Book";
        }
    }
}
