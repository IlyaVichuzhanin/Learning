using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class Book2 : IComparable
    {
        public int Theme;
        public string Title;

        public int CompareTo(object obj)
        {
            var book = (Book2)obj;
            if (Theme.CompareTo(book.Theme) == 0)
                return Title.CompareTo(book.Title);
            else
                return Theme.CompareTo(book.Theme);
        }
    }
}
