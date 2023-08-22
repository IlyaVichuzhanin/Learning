using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        int stackLimit { get; set; }
        LinkedList<T> stack = new LinkedList<T>();   /// where T : IList
        public LimitedSizeStack(int limit)
        {
            stackLimit = limit;
        }

        public void Push(T item)
        {
            if (stackLimit == 0) return;
            if (stack.Count == stackLimit)
            {
                stack.RemoveFirst();
                stack.AddLast(item);
            }
            else
            {
                stack.AddLast(item);
            }
        }

        public T Pop()
        {
            var value = stack.Last.Value;   //ElementAt(stack.Count - 1);
            stack.RemoveLast();
            return value;
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }
    }
}