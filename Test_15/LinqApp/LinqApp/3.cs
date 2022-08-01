using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    internal class _3
    {
        public void Start()
        {
            List<(string Name, int Year, int School)> students = new()
            {
                ("str", 2002, 15),
                ("str", 2002, 13),
                ("str", 2003, 15),
                ("str", 2003, 14),
                ("str", 2003, 14),
                ("str", 2002, 13),
                ("str", 2002, 15),
                ("str", 2002, 13),
                ("str", 2003, 15),
                ("str", 2003, 14),
                ("str", 2003, 14),
                ("str", 2004, 13),
                ("str", 2004, 15),
                ("str", 2004, 13),
                ("str", 2004, 15),
                ("str", 2004, 14),
                ("str", 2004, 14),
                ("str", 2004, 13),
            };
            List<int> years = new() { 2002, 2003, 2004,2005 };
            List<(int Year, int schoolCount)> lst = new();
            foreach(int year in years)
            {
                lst.Add((year, students
                    .Where(y => y.Year == year)
                    .GroupBy(sc => sc.School)
                    .Count()));
            }
            IEnumerable<(int Year, int schoolCount)> res = lst
                .OrderBy(t => t.schoolCount)
                .ThenBy(s=>s.Year);
            Console.WriteLine("3");
            foreach (var item in res) Console.WriteLine($"{item.Year} - {item.schoolCount}");
        }
    }
}
