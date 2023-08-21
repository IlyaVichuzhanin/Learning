using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class Contacts
    {
        private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var dictionary = new Dictionary<string, List<string>>();
            var contact = new string[2];
            string firstLetters;
            foreach (var item in contacts)
            {
                contact = item.Split(':');
                if (item.Split(':')[0].Length > 1)
                    firstLetters = item.Split(':')[0].Substring(0, 2);
                else
                    firstLetters = item.Split(':')[0].Substring(0, 1);
                if (!dictionary.ContainsKey(firstLetters))
                {
                    List<string> emails = new List<string>();
                    emails.Add(item);
                    dictionary[firstLetters] = emails;
                }
                else
                {
                    dictionary[firstLetters].Add(item);
                }
            }
            return dictionary;
        }
    }
}
