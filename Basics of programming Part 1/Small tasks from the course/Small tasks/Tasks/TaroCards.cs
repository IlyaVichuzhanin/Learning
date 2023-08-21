using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks

{
    enum Suits
    {
        Wands,
        Coins,
        Cups,
        Swords
    }

    public class Taro
    {
        public static void GetSuit()
        {
            Console.WriteLine(GetSuit(Suits.Wands));
            Console.WriteLine(GetSuit(Suits.Coins));
            Console.WriteLine(GetSuit(Suits.Cups));
            Console.WriteLine(GetSuit(Suits.Swords));
        }

        private static string GetSuit(Suits suit)
        {
            return new[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit];
        }

    }


}
