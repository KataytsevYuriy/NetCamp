using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Services
{
    internal class StatusPolitics
    {
        public static int GetUserPriority(Person person)
        {
            int priority = 5;
            switch (person.Status)
            {
                case 2: priority = 3;
                    break;
                case 3: priority = 1;
                    break;
            }
            return priority;
        }
    }
}
