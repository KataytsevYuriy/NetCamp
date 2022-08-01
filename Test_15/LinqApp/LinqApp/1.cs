using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqApp
{
    internal class _1
    {
        public void Start()
        {
            Console.WriteLine("1");
            List<int> nums = new List<int>() { 2, 4, 8 };
            List<string> listStrings = new()
            {
                "test",
                "pi",
                "1e",
                "123",
                "2w",
                "3ert",
                "ert7doi8",
                "233456rt",
                "wewe",
                "11"
            };
            List<string> res = new();
            foreach (int num in nums)
            {
                res.Add(listStrings.Where(n => Char.IsDigit(n[0]) && n.Length == num).FirstOrDefault() ?? "Не знайдено");
            }
            foreach (string item in res) Console.WriteLine(item);
        }
    }
}
