using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    internal class _5
    {
        public void Start()
        {
            List<(int SchoolNumber, int Year, string Name)> abiturients = new()
            {
                (12, 2009, "trew"),
                (14, 2003, "trew"),
                (12, 2003, "trew"),
                (1, 2003, "trew"),
                (16, 2003, "trew"),
                (12, 2009, "trew"),
                (14, 2007, "trew"),
                (12, 2005, "trew"),
                (16, 2003, "trew"),
                (12, 2003, "trew"),
                (12, 2009, "trew"),
                (14, 2007, "trew"),
                (16, 2003, "trew"),
            };
            Dictionary<int, List<string>> res =abiturients
                .GroupBy(y => y.Year)
                .ToDictionary(el => el.Key,el=> el.Select(s => s.Name).ToList());
            foreach(var item in res)
            {
                Console.WriteLine($"Year: {item.Key}");
                foreach (string name in item.Value) Console.Write($"{name}, ");
                Console.WriteLine();
            }
        }
    }
}
