using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class PrintLine
    {
        public static void MainPrint()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }
        public static void Print(params object[] onPrintObjects)
        {
            for (var i = 0; i < onPrintObjects.Length; i++)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(onPrintObjects.ElementAt(i));
            }
            Console.WriteLine();
        }
        public static Array Combine(params Array[] arr)
        {
            if (arr.Length == 0) return null;
            int totalLength = 0;
            var elementType = arr[0].GetType().GetElementType();
            foreach (Array array in arr)
            {
                totalLength += array.Length;
            }
            var myArray = Array.CreateInstance(elementType, totalLength);
            int position = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].GetType().GetElementType() == elementType)
                {
                    arr[i].CopyTo(myArray, position);
                    position += arr[i].Length;
                }
                else
                    return null;
            }
            return myArray;
        }
    }
}
