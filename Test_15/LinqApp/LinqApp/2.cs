using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    internal class _2
    {
        public void Start()
        {
            List<string> list = new List<string>()
            {
                "WERT",
                "WET",
                "FRTY",
                "FRTY",
                "FRTYRTETRE",
                "YYTYRRTY",
                "ASDE",
                "RRTTY",
                "EERRTYYRTYTYY",
                "ASDEWWEW",
                "AEQEQW"
            };
            var res = list
                .GroupBy(x => x[0])
                .Select(x => new { x, sum = x.Sum(n => n.Length) })
                .OrderBy(c => c.sum)
                .ThenBy(v => v.x.Key.GetHashCode())
                .Select(r => $"{r.x.Key} {r.sum}");
            Console.WriteLine("2");
            foreach (string item in res) Console.WriteLine(item);
        }
    }
}
