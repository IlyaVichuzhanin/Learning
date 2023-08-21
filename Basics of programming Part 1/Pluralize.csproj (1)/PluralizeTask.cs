namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
          // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
            if (10 <= (count % 100) && (count % 100) <= 20)
            {
                return "рублей";
            }
            else if (count % 10 == 0)
            {
                return "рублей";
            }
            else if (count % 10 == 1)
            {
                return "рубль";
            }
            else if (count % 10 == 2 || count % 10 == 3 || count % 10 == 4)
            {
                return "рубля";
            }
            else
            {
                return "рублей";
            }
        }
    }
}