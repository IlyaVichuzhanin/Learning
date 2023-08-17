using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Chapter_1
{
    internal class Bitcoins
    {
        public static void CountBitcoins()
        {
            double amount = 1.11; //количество биткоинов от одного человека
            int peopleCount = 60; // количество человек
            int totalMoney = (int)Math.Round(amount * peopleCount); // ← исправьте ошибку в этой строке
            Console.WriteLine(totalMoney);
        }
    }
}
