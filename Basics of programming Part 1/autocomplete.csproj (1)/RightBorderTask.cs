using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы. 
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            int m;
            while (right - left > 1)
            {
                m = left + (right - left) / 2;
                if (string.Compare(prefix, phrases[m], StringComparison.OrdinalIgnoreCase) > 0
                    || phrases[m].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    left = m;
                }
                else right = m;
            }
            if (right - left == 1)
                return right;
            return -1;
        }
    }
}