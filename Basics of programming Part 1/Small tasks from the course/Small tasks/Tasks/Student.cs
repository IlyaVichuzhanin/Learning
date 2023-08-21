using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class Student
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null) throw new ArgumentException();
                name = value;
            }
        }
    }
}
